using Microsoft.EntityFrameworkCore;
using STGeneticsProject.Models.Entities;

namespace STGeneticsProject.Database
{
    public class STGeneticsDBContext : DbContext
    {
        public STGeneticsDBContext(DbContextOptions<STGeneticsDBContext> options) : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
    }
}
