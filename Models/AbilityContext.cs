using Microsoft.EntityFrameworkCore;
namespace PkmnApi.Models
{
    public class AbilityContext : DbContext
    {
        public AbilityContext(DbContextOptions<AbilityContext> options)
            : base(options)
        {
        }
        public DbSet<Ability> Ability { get; set; }
    }
}