using FruteriaAPI.Domain.Models;

namespace FruteriaAPI.Business.Extensions
{
    public static class CustomExtentions
    {   
        public static string ToCustomPrecio(this decimal precio)
        {
            return $"{precio:C}";
        }
    }
}
