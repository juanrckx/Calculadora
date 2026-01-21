using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using Comun.Models;

namespace Comun.Utils
{
    public static class Serializador        // Clase estática (no necesita instancia)
    {
        public static byte[] Serializar(Mensaje mensaje)
        {
            string json = JsonConvert.SerializeObject(mensaje);     // Objeto -> JSON
            return Encoding.UTF8.GetBytes(json);                    // JSON -> bytes 
        }

        public static Mensaje Deserializar(byte[] datos)
        {
            string json = Encoding.UTF8.GetString(datos);           // bytes -> JSON
            return JsonConvert.DeserializeObject<Mensaje>(json);    // JSON -> Objeto
        }
    }
}