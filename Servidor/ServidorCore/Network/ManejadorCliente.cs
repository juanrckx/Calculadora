using System.Net.Sockets;
using System.Net;
using Comun.Models;
using Comun.Enums;
using Comun.Utils;
using ServidorCore.ExpressionTree;
using ServidorCore.Data;
using System.Text;

namespace Servidor.Network
{
    public class ManejadorCliente
    {
        private TcpClient _cliente;
        private NetworkStream _stream;
        private string _idCliente;
        private CSVManager _csvManager;
        private readonly IPEndPoint _clienteEndpoint;

        // Eventos para logging
        public event Action<string> OnLogMensaje;
        public event Action<string> OnClienteDesconectado;

        public ManejadorCliente(TcpClient cliente, CSVManager csvManager)
        {
            _cliente = cliente;
            _stream = cliente.GetStream();
            _idCliente = Guid.NewGuid().ToString();
            _csvManager = csvManager;
            _clienteEndpoint = (IPEndPoint)cliente.Client.RemoteEndPoint;

            Log($"Cliente conectado desde {_clienteEndpoint.Address}:{_clienteEndpoint.Port}");
        }

        public async Task ManejarConexion()
        {
            try
            {
                // 1. Enviar confirmación de conexión
                await EnviarConfirmacionConexion();

                // 2. Escuchar mensajes del cliente
                await EscucharMensajes();
            }
            catch (Exception ex)
            {
                Log($"Error con cliente {_idCliente}: {ex.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        private async Task EnviarConfirmacionConexion()
        {
            var mensajeConexion = new Mensaje
            {
                Tipo = TipoMensaje.ConexionEstablecida,
                IdCliente = _idCliente,
                Contenido = "Conexión establecida con éxito",
                Fecha = DateTime.Now
            };

            await EnviarMensaje(mensajeConexion);
            Log($"Enviado ID de cliente: {_idCliente}");
        }

        private async Task EscucharMensajes()
        {
            while (_cliente.Connected)
            {
                try
                {
                    var mensaje = await RecibirMensaje();
                    if (mensaje != null)
                    {
                        Log($"Mensaje recibido: {mensaje.Tipo}");
                        await ProcesarMensaje(mensaje);
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error procesando mensaje: {ex.Message}");
                    break;
                }
            }
        }

        private async Task ProcesarMensaje(Mensaje mensaje)
        {
            try
            {
                switch (mensaje.Tipo)
                {
                    case TipoMensaje.ExpresionParaEvaluar:
                        await EvaluarExpresion(mensaje.Contenido);
                        break;

                    case TipoMensaje.HistorialSolicitado:
                        await EnviarHistorial();
                        break;

                    default:
                        Log($"Tipo de mensaje no reconocido: {mensaje.Tipo}");
                        await EnviarError($"Tipo de mensaje no soportado: {mensaje.Tipo}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Log($"Error procesando {mensaje.Tipo}: {ex.Message}");
                await EnviarError($"Error interno: {ex.Message}");
            }
        }

        private async Task EvaluarExpresion(string expresion)
        {
            try
            {
                Log($"Evaluando expresión: {expresion}");

                // Usar el árbol de expresión de tu compañero
                var arbol = new ArbolExpresion(expresion);
                
                // Evaluar
                double resultado = arbol.Evaluar();
                Log($"Resultado: {resultado}");

                // Guardar en CSV
                _csvManager.GuardarRegistro(_idCliente, expresion, resultado.ToString());

                // Enviar resultado
                await EnviarResultado(resultado.ToString());
            }
            catch (Exception ex)
            {
                Log($"Error evaluando expresión: {ex.Message}");
                await EnviarError($"Error evaluando expresión: {ex.Message}");
            }
        }

        private async Task EnviarHistorial()
        {
            try
            {
                Log($"Enviando historial para cliente {_idCliente}");

                var registros = _csvManager.ObtenerRegistrosPorCliente(_idCliente);
                var historial = new StringBuilder();

                foreach (var registro in registros)
                {
                    historial.AppendLine($"{registro[3]}|{registro[1]}|{registro[2]}");
                }

                var mensajeHistorial = new Mensaje
                {
                    Tipo = TipoMensaje.HistorialEnviado,
                    IdCliente = _idCliente,
                    Contenido = historial.ToString(),
                    Fecha = DateTime.Now
                };

                await EnviarMensaje(mensajeHistorial);
                Log($"Historial enviado ({registros.Count} registros)");
            }
            catch (Exception ex)
            {
                Log($"Error enviando historial: {ex.Message}");
                await EnviarError($"Error obteniendo historial: {ex.Message}");
            }
        }

        private async Task EnviarResultado(string resultado)
        {
            var mensaje = new Mensaje
            {
                Tipo = TipoMensaje.ResultadoCalculado,
                IdCliente = _idCliente,
                Contenido = resultado,
                Fecha = DateTime.Now
            };

            await EnviarMensaje(mensaje);
        }

        private async Task EnviarError(string mensajeError)
        {
            var mensaje = new Mensaje
            {
                Tipo = TipoMensaje.Error,
                IdCliente = _idCliente,
                Contenido = mensajeError,
                Fecha = DateTime.Now
            };

            await EnviarMensaje(mensaje);
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
                Log($"Error recibiendo mensaje: {ex.Message}");
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
                Log($"Error enviando mensaje: {ex.Message}");
                throw;
            }
        }

        private void Desconectar()
        {
            try
            {
                _stream?.Close();
                _cliente?.Close();
                OnClienteDesconectado?.Invoke(_idCliente);
                Log($"Cliente desconectado");
            }
            catch (Exception ex)
            {
                Log($"Error desconectando: {ex.Message}");
            }
        }

        private void Log(string mensaje)
        {
            string log = $"[Cliente {_idCliente}] {mensaje}";
            OnLogMensaje?.Invoke(log);
            Console.WriteLine(log);
        }

        // Propiedades públicas
        public string IdCliente => _idCliente;
        public IPEndPoint ClienteEndpoint => _clienteEndpoint;
        public bool EstaConectado => _cliente?.Connected == true;
    }
}