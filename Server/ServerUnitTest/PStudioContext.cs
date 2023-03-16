using System.Data.Entity;
using PStudioLibrary;

namespace Server
{
    public class PStudioContext : DbContext
    {
        public PStudioContext() : base("DBConnection") { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}