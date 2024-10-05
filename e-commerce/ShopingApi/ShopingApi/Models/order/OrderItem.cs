using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopingApi.Models.order
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }


        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public Item Item { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }











    }
}
