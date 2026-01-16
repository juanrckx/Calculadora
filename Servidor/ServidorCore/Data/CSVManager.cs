using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServidorCore.Data
{
    public class CSVManager
    {
        private string _filePath;

        public CSVManager(string filePath)
        {
            _filePath = filePath;

            // Crear archivo si no existe
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "ID_Cliente,Expresion,Resultado,Fecha\n");
            }
        }

        public void GuardarRegistro(string idCliente, string expresion, string resultado)
        {
            string registro = $"{idCliente},{expresion.Replace(",", ";")},{resultado},{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n";
            File.AppendAllText(_filePath, registro);
        }

        public List<string[]> ObtenerRegistrosPorCliente(string idCliente)
        {
            var registros = new List<string[]>();

            if (File.Exists(_filePath))
            {
                var lineas = File.ReadAllLines(_filePath).Skip(1);  // Saltar encabezado

                foreach (var linea in lineas)
                {
                    var campos = linea.Split(',');
                    if (campos.Length >= 4 && campos[0] == idCliente)
                    {
                        registros.Add(campos);
                    }
                }
            }
            
            return registros;
        }

        public List<string[]> ObtenerTodosRegistros()
        {
            var registros = new List<string[]>();

            if (File.Exists(_filePath))
            {
                var lineas = File.ReadAllLines(_filePath).Skip(1);
                registros.AddRange(lineas.Select(l => l.Split(',')));
            }

            return registros;
        }
    }
}