using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using ServidorCore.Data;

namespace Servidor.Network
{
    public class ServidorTCP
    {
        private TcpListener _listener;                                              // Objeto que escucha conexiones
        private bool _activo;                                                       // Bandera de estado
        private ConcurrentDictionary<string, TcpClient> _clientesConectados;        // Diccionario seguro para hilos
        private CSVManager _csvManager;                                             // Referencia al manager de CSV
        public event Action<string> LogEvent;                                       // Evento para logging

        public ServidorTCP(int puerto = 8080, CSVManager csvManager = null)
        {
            // Inicializar el listener en todas las IPs (IPAdress.Any) y el puerto especificado
            _listener = new TcpListener(IPAddress.Any, puerto);

            //Diccionario thread-safe
            _clientesConectados = new ConcurrentDictionary<string, TcpClient>();

            // Usar el manager proporcionado o crear uno nuevo
            _csvManager = csvManager ?? new CSVManager("historial.csv");
        }

        public void Iniciar()
        {
            _activo = true;
            _listener.Start();                                                                                
            LogEvent?.Invoke($"Servidor iniciado en puerto {((IPEndPoint)_listener.LocalEndpoint).Port}");

            Task.Run(() => AceptarConexiones());    // Ejecutar aceptación de conexiones en un hilo separado
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

                    // Crear un manejador para este cliente
                    var manejador = new ManejadorCliente(cliente, _csvManager);

                    // Suscribirse a los eventos del manejador
                    manejador.OnLogMensaje += (msg) => LogEvent?.Invoke(msg);
                    manejador.OnClienteDesconectado += (id) =>
                    {
                        _clientesConectados.TryRemove(id, out _);               // Remover cliente del diccionario
                        LogEvent?.Invoke($"Cliente {id} desconectado");
                    };

                    _clientesConectados[manejador.IdCliente] = cliente;         // Agregar cliente al diccionario

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