using FruteriaAPI.Models;

namespace FruteriaAPI.Extensions
{
    public static class FrutaExtention
    {
        public static string ToCustomString(this Fruta myFruta)
        {
            return $"Nombre={myFruta.Nombre}\nPrecio={myFruta.Precio:C}";
        }
    }
}
