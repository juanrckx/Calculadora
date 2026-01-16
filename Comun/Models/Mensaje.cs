using System;

namespace Comun.Models
{
    [Serializable]
    public class Mensaje
    {
        public TipoMensaje Tipo { get; set; }
        public string Contenido { get; set; }
        public string IdCliente { get; set; }
        public DateTime Fecha { get; set; }
    }
}

namespace Comun.Enums
{
    public enum TipoMensaje
    {
        ConexionEstablecida,
        ExpresionParaEvaluar,
        ResultadoCalculado,
        Error,
        HistorialSolicitado,
        HistorialEnviado
    }
}