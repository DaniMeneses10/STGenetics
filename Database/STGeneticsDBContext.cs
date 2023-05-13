using Microsoft.EntityFrameworkCore;
using STGeneticsProject.Models.Entities;
using STGeneticsProject.Models.Responses;

namespace STGeneticsProject.Database
{
    public class STGeneticsDBContext : DbContext
    {
        public STGeneticsDBContext(DbContextOptions<STGeneticsDBContext> options) : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemDetails> OrdersDetails { get; set; }
    }
}
