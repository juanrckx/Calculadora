using System.Diagnostics.CodeAnalysis;

namespace Comun.Models
{
    public class HistorialItem
    {
        public string Fecha { get; set; }
        public string Expresion { get; set; }
        public string Resultado { get; set; }

        public HistorialItem() { }  // Constructor vacío necesario para deserialización

        public HistorialItem(string fecha, string expresion, string resultado)
        {
            Fecha = fecha;
            Expresion = expresion;
            Resultado = resultado;
        }
    }
}