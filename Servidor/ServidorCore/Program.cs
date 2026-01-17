using System;
using Servidor.Network;
using ServidorCore.Data;

namespace ServidorCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Servidor Calculadora Distribuida ===");
            Console.WriteLine("Iniciando servidor en puerto 8080...");
            
            // Crear manager de CSV
            var csvManager = new CSVManager("historial.csv");
            
            // Iniciar servidor
            var servidor = new ServidorTCP(8080, csvManager);
            
            servidor.LogEvent += (mensaje) => 
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {mensaje}");
            };
            
            servidor.Iniciar();
            
            Console.WriteLine("Servidor activo. Presiona Enter para detener.");
            Console.WriteLine("Esperando conexiones de clientes...");
            Console.WriteLine();
            
            // Mantener el servidor corriendo
            Console.ReadLine();
            servidor.Detener();
        }
    }
}