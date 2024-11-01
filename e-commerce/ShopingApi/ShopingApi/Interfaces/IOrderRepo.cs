using ShopingApi.Models.order;
using ShopingApi.ViewModels;

namespace ShopingApi.Interfaces
{
    public interface IOrderRepo
    {
        bool AddOrder(Order vm );
        bool AddShipping(Shipping vm );
        bool Save();
    }
}
