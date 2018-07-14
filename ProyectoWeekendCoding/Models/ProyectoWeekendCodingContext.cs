using System.Data.Entity;

namespace ProyectoWeekendCoding.Models
{
    public class ProyectoWeekendCodingContext : DbContext
    {
        public ProyectoWeekendCodingContext() : base("name=ProyectoWeekendCodingContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
