using CameraBazaar.Models.Models;

namespace CameraBazaar.Data
{
    using System.Data.Entity;

    public class CameraBazaarContext : DbContext
    {
      
        public CameraBazaarContext()
            : base("CameraBazaarContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Login> Logins { get; set; }

    }
}