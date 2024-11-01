using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopingApi.Models.order
{
    public class Shipping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public string State { get; set; }
        public string Postal_code { get; set; }
        public string Country { get; set; }
        public string phone { get; set; }
        public string EmailAdress { get; set; }





    }
}
