using System.Net.Sockets;
using Comun.Models;
using Comun.Utils;
using System.Text;

namespace ClienteApp.Services
{
    public class ClienteTCP
    {
        private TcpClient _tcpCliente;
        private NetworkStream _stream;
        private string _idCliente;

        public event Action<Mensaje> OnConexionEstablecida;
        public event Action<string> OnResultadoRecibido;
        public event Action<string> OnError;
        public event Action<List<HistorialItem>> OnHistorialRecibido;

        public async Task<bool> Conectar(string ip = "152.231.170.2", int puerto = 5000)
        {
            try
            {
                _tcpCliente = new TcpClient();
                await _cliente.ConnectAsync(ip, puerto);
                _stream = _cliente.GetStream();
                _idCliente = Guid.NewGuid().ToString();

                EstadoCambiado?.Invoke("Conectado al servidor");

                // Iniciar escucha de mensajes
                Task.Run(() => EscucharMensajes());

                return true;
            }
            catch (Exception ex)
            {
                EstadoCambiado?.Invoke($"Error de conexión {ex.Message}");
                return false;
            }
        }

        public async Task EnviarExpresion(string expresion)
        {
            var mensaje = new Mensaje
            {
                Tipo = TipoMensaje.ExpresionParaEvaluar,
                Contenido = expresion,
                IdCliente = _idCliente,
                Fecha = DateTime.Now
            };

            await EnviarMensaje(mensaje);
        }

        public async Task SolicitarHistorial()
        {
            var mensaje = new Mensaje
            {
                Tipo = TipoMensaje.HistorialSolicitado,
                IdCliente = _idCliente,
                Fecha = DateTime.Now
            };

            await EnviarMensaje(mensaje);
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
            }
        }

        private void ProcesarMensaje(Mensaje mensaje)
        {
            switch (mensaje.Tipo)
            {
                case TipoMensaje.ConexionEstablecida:
                    _idCliente = mensaje.IdCliente;
                    OnConexionEstablecida?.Invoke(mensaje.Contenido);
                    break;

                case TipoMensaje.ResultadoCalculado:
                    OnResultadoRecibido?.Invoke(mensaje.Contenido);
                    break;

                case TipoMensaje.HistorialEnviado:
                    ProcesarHistorial(mensaje.Contenido);
                    break;
                
                case TipoMensaje.Error:
                    OnError?.Invoke(mensaje.Contenido);
                    break;
            }
        }

        private void ProcesarHistorial(string contenido)
        {
            var historialItems = new List<HistorialItem>();
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

            OnHistorialRecibido?.Invoke(historialItems);
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
            catch {  }

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
                OnError?.Invoke($"Error enviando mensaje: {ex.Message}");
            }
        }

        public void Desconectar()
        {
            _tcpCliente?.Close();
        }
    }
}