using Microsoft.EntityFrameworkCore;
using racing_webApp.Models;

namespace racing_webApp.Data
{
    public class Db_context : DbContext
    {
        public Db_context(DbContextOptions<Db_context> options) : base(options)
        {
                
        }
        public DbSet<Club> Clubs { get; set; }

        public DbSet<Race> Races { get; set; }
        public DbSet<Address>  Addresses { get; set; }

    }
}
