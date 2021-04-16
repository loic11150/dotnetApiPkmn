using Microsoft.EntityFrameworkCore;
namespace PkmnApi.Models
{
    public class PkmnContext : DbContext
    {
        public PkmnContext(DbContextOptions<PkmnContext> options)
            : base(options)
        {
        }
        public DbSet<Pkmn> Pkmn { get; set; }
    }
}