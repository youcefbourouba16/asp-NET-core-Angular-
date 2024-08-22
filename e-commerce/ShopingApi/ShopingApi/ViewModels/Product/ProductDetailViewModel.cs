using ShopingApi.Enum;
using ShopingApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopingApi.ViewModels.Product
{
    public class ProductDetailViewModel
    {
        
        public int Id { get; set; }

       
        public string Name { get; set; }

        
        public string? Description { get; set; }


        public List<Size>? Size { get; set; }

        public List<Color>? Colors { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } = 1;

        public decimal Price { get; set; }

        public string? ImageURL { get; set; }


        public Category_enum Category { get; set; }

        // Navigation property for ProductType
        public ProductType? ProductType { get; set; }
    }
}
