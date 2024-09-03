using Microsoft.EntityFrameworkCore;
using ShopingApi.Data;
using ShopingApi.Interfaces;
using ShopingApi.Models;
using ShopingApi.ViewModels.Product;

namespace ShopingApi.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly Db_Context _context;

        public ProductRepo(Db_Context db_Context)
        {
            _context=db_Context;
        }

        public bool Add(Item item)
        {
            _context.Items.Add(item);
            return Save();
        }

        public bool Add(CreateProductViewModel item)
        {
            throw new NotImplementedException();
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetByIdAsyc(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(CreateProductViewModel item)
        {
            throw new NotImplementedException();
        }

        public async Task AddItemColors(List<Color> colors, int itemID)
        {
            foreach (var item in colors)
            {
                _context.ItemColors.AddRange(
                        new ItemColors { ItemID = itemID, ColorId = item.Name });
            }
            Save();
        }
        public async Task AddItemSizes(List<Size> sizes, int itemID)
        {
            foreach (var item in sizes)
            {
                _context.ItemSizes.AddRange(
                        new ItemSizes { ItemID = itemID, SizeID = item.Name });
            }
            Save();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductViewModelsAsync()
        {
            var products = await _context.Items
            .Select(p => new ProductViewModel
            {
                Name = p.Name,
                Id = p.Id,
                Category = p.Category,
                Price = p.Price,
                ImageURL = p.ImageURL
            })
            .ToListAsync();

            return products;
        }
    }
}
