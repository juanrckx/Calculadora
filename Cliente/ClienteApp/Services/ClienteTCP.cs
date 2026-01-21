using System.Net.Sockets;
using Comun.Models;
using Comun.Utils;
using System.Text;
using Comun.Enums;
using Newtonsoft.Json;

namespace ClienteApp.Services
{
    public class ClienteTCP
    {
        private TcpClient _tcpCliente;
        private NetworkStream _stream;
        private string _idCliente;

        public event Action<string> OnConexionEstablecida;
        public event Action<string> OnResultadoRecibido;
        public event Action<string> OnError;
        public event Action<List<HistorialItem>> OnHistorialRecibido;
        public event Action<string> OnEstadoCambiado; 

        public async Task<bool> Conectar(string ip = "127.0.0.1", int puerto = 8080)
        {
            try
            {
                _tcpCliente = new TcpClient();
                await _tcpCliente.ConnectAsync(ip, puerto);     // Conexión asíncrona
                _stream = _tcpCliente.GetStream();
                _idCliente = Guid.NewGuid().ToString();

                OnEstadoCambiado?.Invoke("Conectado al servidor");

                // Iniciar escucha de mensajes
                Task.Run(() => EscucharMensajes());

                return true;
            }
            catch (Exception ex)
            {
                OnEstadoCambiado?.Invoke($"Error de conexión {ex.Message}");
                OnError?.Invoke($"No se pudo conectar al servidor: {ex.Message}");

                return false;
            }
        }

        public async Task EnviarExpresion(string expresion)
        {
            try
            {
                var mensaje = new Mensaje
                {
                    Tipo = TipoMensaje.ExpresionParaEvaluar,
                    Contenido = expresion,
                    IdCliente = _idCliente,
                    Fecha = DateTime.Now
                };

                await EnviarMensaje(mensaje);
                OnEstadoCambiado?.Invoke("Expresión enviada para evaluación...");
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error enviando expresión: {ex.Message}");
            }
        }

        public async Task SolicitarHistorial()
        {
            try
            {
                var mensaje = new Mensaje
                {
                    Tipo = TipoMensaje.HistorialSolicitado,
                    IdCliente = _idCliente,
                    Fecha = DateTime.Now
                };

                await EnviarMensaje(mensaje);
                OnEstadoCambiado?.Invoke("Solicitando historial...");
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error solicitando historial: {ex.Message}");
            }
        }

        private async Task EscucharMensajes()
        {
            try
            {
                while (_tcpCliente?.Connected == true)
                {
                    var mensaje = await RecibirMensaje();
                    if (mensaje != null)
                    {
                        ProcesarMensaje(mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                
                OnError?.Invoke($"Error de conexión: {ex.Message}");
                OnEstadoCambiado?.Invoke("Desconectado del servidor");
            }
        }

        private void ProcesarMensaje(Mensaje mensaje)
        {
            switch (mensaje.Tipo)
            {
                case TipoMensaje.ConexionEstablecida:
                    _idCliente = mensaje.IdCliente;                             // Actualizar ID con el del servidor
                    OnConexionEstablecida?.Invoke(mensaje.Contenido);
                    OnEstadoCambiado?.Invoke($"Conectado (ID: {_idCliente})");
                    break;

                case TipoMensaje.ResultadoCalculado:
                    OnResultadoRecibido?.Invoke(mensaje.Contenido);
                    OnEstadoCambiado?.Invoke("Resultado recibido");
                    break;

                case TipoMensaje.HistorialEnviado:
                    ProcesarHistorial(mensaje.Contenido);
                    OnEstadoCambiado?.Invoke("Historial recibido");
                    break;
                
                case TipoMensaje.Error:
                    OnError?.Invoke(mensaje.Contenido);
                    OnEstadoCambiado?.Invoke("Error recibido");
                    break;
            }
        }

        private void ProcesarHistorial(string contenido)
        {
            try
            {
                var historialItems = new List<HistorialItem>();
                
                try
                {
                    historialItems = JsonConvert.DeserializeObject<List<HistorialItem>>(contenido);
                }
                catch (JsonException)
                {
                    // Si falla, intentar como formato simple
                    var lineas = contenido.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var linea in lineas)
                    {
                        var partes = linea.Split('|');
                        if (partes.Length >= 3)
                        {
                            historialItems.Add(new HistorialItem
                            {
                                Fecha = partes[0],
                                Expresion = partes[1],
                                Resultado = partes[2]
                            });
                        }
                    }
                }

                OnHistorialRecibido?.Invoke(historialItems);
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error procesando historial: {ex.Message}");
            }
        }

        private async Task<Mensaje> RecibirMensaje()
        {
            try
            {
                byte[] buffer = new byte[4096];
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    return Serializador.Deserializar(buffer.Take(bytesRead).ToArray());
                }
            }
            catch (Exception ex)
            {
                OnEstadoCambiado?.Invoke($"Error recibiendo mensaje: {ex.Message}");      
            }
            return null;
        }

        private async Task EnviarMensaje(Mensaje mensaje)
        {
            try
            {
                byte[] datos = Serializador.Serializar(mensaje);
                await _stream.WriteAsync(datos, 0, datos.Length);
            }
            catch (Exception ex)
            {
                OnEstadoCambiado?.Invoke($"Error enviando mensaje: {ex.Message}");
                throw;   
            }
        }

        public void Desconectar()
        {
            try
            {
                _stream?.Close();
                _tcpCliente?.Close();
                OnEstadoCambiado?.Invoke("Desconectado");
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error desconectando: {ex.Message}");
            }
        }

        public bool EstaConectado()
        {
            return _tcpCliente?.Connected == true;
        }

        public string ObtenerIdCliente()
        {
            return _idCliente;
        }
    }
}