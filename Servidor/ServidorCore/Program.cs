using System;
using Servidor.Network;
using ServidorCore.Data;

// Punto de entrada del servidor
// Crea un CSVManager para manejar el archivo "historial.csv"
// Usa eventos para mostrar logs en consola

namespace ServidorCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Servidor Calculadora Distribuida ===");
            Console.WriteLine("Iniciando servidor en puerto 8080...");
            
            // Crear manager de CSV para guardar el historial
            var csvManager = new CSVManager("historial.csv");
            
            // Crear servidor TCP en puerto 8'8' y pasarle el CSV manager
            var servidor = new ServidorTCP(8080, csvManager);
            
            // Suscribirse al evento de logging para ver mensajes en consola
            servidor.LogEvent += (mensaje) => 
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {mensaje}");
            };
            
            // Iniciar el servidor, (comienza a escuchar conexiones)
            servidor.Iniciar();
            
            Console.WriteLine("Servidor activo. Presiona Enter para detener.");
            Console.WriteLine("Esperando conexiones de clientes...");
            Console.WriteLine();
            
            // Mantener el servidor corriendo hasta que el usuario presione Enter
            Console.ReadLine();
            servidor.Detener();
        }
    }
}