

namespace Cesar.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Cesar.Models.Fairy> Fairies { get; set; }
    }
}