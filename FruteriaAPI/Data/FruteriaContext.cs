using FruteriaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FruteriaAPI.Data
{
    public class FruteriaContext : DbContext
    {
        public DbSet<Fruta> Frutas { get; set; }

        public FruteriaContext(DbContextOptions<FruteriaContext> options) : base(options)
        {            
        }


    }
}
