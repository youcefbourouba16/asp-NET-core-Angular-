using ShopingApi.ViewModels;

namespace ShopingApi.Interfaces
{
    public interface IOrderRepo
    {
        Task AddOrder(OrderViewModel orderViewModel);
    }
}
