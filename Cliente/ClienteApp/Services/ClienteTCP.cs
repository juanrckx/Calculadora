using System.Net.Sockets;
using Comun.Models;
using Comun.Utils;

namespace ClienteApp.Services
{
    public class ClienteTCP
    {
        private TcpClient _cliente;
        private NetworkStream _stream;
        private string _idCliente;

        public event Action<Mensaje> MensajeRecibido;
        public event Action<string> EstadoCambiado;

        public async Task<bool> Conectar(string ip = "152.231.170.2", int puerto = 5000)
        {
            try
            {
                _cliente = new TcpClient();
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
    }
}