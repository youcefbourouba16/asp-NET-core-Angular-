using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ShopingApi.Models;

namespace ShopingApi.Models.order
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string AspNetUsersId { get; set; }

        // Navigation property for AspNetUsers
        public virtual AppUser AspNetUsers { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public decimal Total_Amount { get; set; }

        public string Note { get; set; }

        public Order()
        {
            OrderDate = DateTime.Today; // Set default value
        }
    }
}
