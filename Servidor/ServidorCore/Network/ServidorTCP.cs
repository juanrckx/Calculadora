using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;

namespace Servidor.Network
{
    public class ServidorTCP
    {
        private TcpListener _listener;
        private bool _activo;
        private ConcurrentDictionary<string, TcpClient> _clientesConectados;

        public event Action<string> LogEvent;

        public ServidorTCP(int puerto = 5000, CSVManager csvManager = null)
        {
            _listener = new TcpListener(IPAddress.Any, puerto);
            _clientesConectados = new ConcurrentDictionary<string, TcpClient>();

            _csManager = csvManager ?? new CSVManager("historial.csv");
        }

        public void Iniciar()
        {
            _activo = true;
            _listener.Start();
            LogEvent?.Invoke($"Servidor iniciado en puerto {((IPEndPoint)_listener.LocalEndpoint).Port}");

            Task.Run(() => AceptarConexiones());
        }

        private async Task AceptarConexiones()
        {
            while (_activo)
            {
                try
                {
                    var cliente = await _listener.AcceptTcpClientAsync();
                    var clienteEndPoint = cliente.Client.RemoteEndPoint as IPEndPoint;

                    LogEvent?.Invoke($"Nueva conexión desde {clienteEndPoint.Address}:{clienteEndPoint.Port}");

                    var manejador = new ManejadorCliente(cliente);
                    Task.Run(() => manejador.ManejarConexion());
                }
                catch (Exception ex)
                {
                    LogEvent?.Invoke($"Error aceptando conexión: {ex.Message}");
                }
            }
        }

        public void Detener()
        {
            _activo = false;
            _listener.Stop();
            LogEvent?.Invoke("Servidor detenido");
        }
    }
}