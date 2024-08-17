using ShopingApi.Data;
using ShopingApi.Interfaces;
using ShopingApi.Models;
using ShopingApi.ViewModels;

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
    }
}
