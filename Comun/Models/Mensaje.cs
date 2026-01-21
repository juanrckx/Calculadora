using System;
using Comun.Enums;

namespace Comun.Models
{
    [Serializable]      // Atributo que indica que se puede serializar
    public class Mensaje
    {
        public TipoMensaje Tipo { get; set; }
        public string Contenido { get; set; }
        public string IdCliente { get; set; }
        public DateTime Fecha { get; set; }
    }
}