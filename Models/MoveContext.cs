using Microsoft.EntityFrameworkCore;
namespace PkmnApi.Models
{
    public class MoveContext : DbContext
    {
        public MoveContext(DbContextOptions<MoveContext> options)
            : base(options)
        {
           
        }
        public DbSet<Move> Move { get; set; }
    }
}