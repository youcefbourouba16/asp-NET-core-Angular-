using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopingApi.Models;
using System.Collections.Generic;

namespace ShopingApi.Data
{
    public class Db_Context : IdentityDbContext<AppUser>
    {
        public Db_Context(DbContextOptions<Db_Context> option) : base(option)
        {

        }
        public DbSet<AppUser> Clubs { get; set; }
    }
}
