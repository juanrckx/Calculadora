using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Comun.Utils
{
    public static class Serializador
    {
        public static byte[] Serialier(Mensaje mensaje)
        {
            string json = JsonConvert.SerializeObject(mensaje);
            return Encoding.UTF8.GetBytes(json);
        }

        public static Mensaje Deserializar(byte[] datos)
        {
            string json = Encoding.UTF8.GetString(datos);
            return JsonConvert.DeserializeObject<Mensaje>(json);
        }
    }
}