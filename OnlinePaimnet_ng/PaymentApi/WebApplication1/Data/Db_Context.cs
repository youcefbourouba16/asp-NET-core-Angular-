using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Db_Context : DbContext
    {
        public Db_Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PaymentDetail> paymentDetails { get; set; }
    }
}
