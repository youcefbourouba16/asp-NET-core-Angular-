using ShopingApi.Data;
using ShopingApi.Interfaces;
using ShopingApi.Models;
using ShopingApi.Models.order;
using ShopingApi.ViewModels;

namespace ShopingApi.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly Db_Context _context;
        public OrderRepo(Db_Context db_Context)
        {
            _context = db_Context;
        }
        public bool AddOrder(Order vm)
        {
            _context.Orders.Add(vm);
            return Save();
        }

        public bool AddShipping(Shipping vm)
        {
            _context.Shippings.Add(vm);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
