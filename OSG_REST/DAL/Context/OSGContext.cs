using System.Data.Entity;
using DAL.DomainModel;

namespace DAL.Context
{
    public class OSGContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Comment> Comment { get; set; }

        // If DB or DbName database doesn't exist, it will be created using the dbInitializer.
        public OSGContext() : base("OSG")
        {
            Database.SetInitializer(new OSGContextDBInitializer());
            Configuration.ProxyCreationEnabled = false;
        }


    }
}
