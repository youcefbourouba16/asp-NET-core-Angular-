namespace ShopingApi.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string AspNetUsersId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; } // Match Angular model `TotalAmount`

        public string Note { get; set; } // Order Notes

        public List<OrderItemViewModel> OrderItems { get; set; } // List of items in the order

        public ShippingViewModel ShippingDetails { get; set; } // Shipping details for the order
    }

    public class OrderItemViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; } // Assuming `Item` has a `Name` property in the `Item` model

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }

    public class ShippingViewModel
    {
        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string EmailAddress { get; set; }
    }
}
