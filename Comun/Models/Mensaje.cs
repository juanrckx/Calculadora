using System;
using Comun.Enums;

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