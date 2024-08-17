using ShopingApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ShopingApi.Enum;

namespace ShopingApi.ViewModels
{
    public class CreateProductViewModel
    {



        public string Name { get; set; }
        public string? Description { get; set; }
        public TshirtSize_enum Size { get; set; }
        public List<Color>? Colors { get; set; }

        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }

        public IFormFile? Image { get; set; }
        public Category_enum Category { get; set; }

        public string ProductTypeId { get; set; }
    }
}
