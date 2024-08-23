using ShopingApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopingApi.ViewModels.Product
{
    public class ProductDetails
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Size>? Size { get; set; }

        public List<Color>? Colors { get; set; }
        public int Quantity { get; set; } 
        public decimal Price { get; set; }

        public string? ImageURL { get; set; }
        public string productTypeId { get; set; }


        public string Category { get; set; }

        // Navigation property for ProductType
        public string? ProductType { get; set; }
    }
}
