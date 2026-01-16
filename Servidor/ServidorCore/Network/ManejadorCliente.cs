using System.Net.Sockets;
using Comun.Models;
using ComunUtils;

namespace Servidor.Network
{
    public class ManejadorCliente
    {
        private TcpClient _cliente;
        private NetworkStream _stream;
        private string _idCliente;

        public ManejadorCliente(TcpClient cliente)
        {
            _cliente = cliente;
            _stream = cliente.GetStream();
            _idCliente = Guid.NewGuid().ToString();
        }

        public async Task ManejarConexion()
        {
            try
            {
                // Enviar confirmación de conexión
                var mensajeConexion = new Mensaje
                {
                    Tipo = TipoMensaje.ConexionEstablecida,
                    IdCliente = _idCliente,
                    Contenido = "Conexión establecida con éxito",
                    Fecha = DateTime.Now
                };

                await EnviarMensaje(mensajeConexion);

                // Escuchar mensajes del cliente
                while (_cliente.Connected)
                {
                    var mensaje = await RecibirMensaje();
                    if (mensaje != null)
                    {
                        await ProcesarMensaje(mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error con cliente {_idCliente}: {ex.Message}");
            }
            finally
            {
                _cliente.Close();
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
            catch { }

            return null;
        }
    }
}