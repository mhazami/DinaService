using DataStructure;
using System.Data.Entity;

namespace DAL
{
    public class ConnectionHandler : DbContext
    {
        public ConnectionHandler() : base("name=DinaServiceConnectionString") { }

        public virtual DbSet<File> Files { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Content> Contents { get; set; }

        public virtual DbSet<Brands> Brands { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Request> Requests { get; set; }
    }
}
