using ShopingApi.Data;
using ShopingApi.Models;
using ShopingApi.ViewModels.Product;

namespace ShopingApi.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetByIdAsyc(int id);

        bool Add(Item item);
        bool Add(CreateProductViewModel item);
        bool Delete(int id);
        bool Update(CreateProductViewModel item);
        bool Save();

        Task AddItemColors(List<Color> colors,int itemID);
        Task AddItemSizes(List<Size> sizes,int itemID);
    }
}
