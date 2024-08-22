using ShopingApi.Enum;
using ShopingApi.Models;

namespace ShopingApi.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Category { get; set; }

        public decimal Price { get; set; } = 1;

        public string ImageURL { get; set; }
    }
}
