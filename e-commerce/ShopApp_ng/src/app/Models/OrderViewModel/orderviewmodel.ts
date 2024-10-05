import { CartViewModel } from "../productViewModel/cart-view-model";

// Assuming CartViewModel and OrderItemViewModel have similar structure.
// If not, update the mapping accordingly.
export class OrderViewModel {
    id: number = 0;
    aspNetUsersId: string = '';
    orderDate: Date = new Date();
    totalAmount: number = 0;
    note: string = '';
    orderItems: OrderItemViewModel[] = [];  // Use OrderItemViewModel instead of CartViewModel
    shippingDetails: ShippingViewModel = new ShippingViewModel();
}

export class OrderItemViewModel {
    itemId: number = 0;
    itemName: string = '';  // Including itemName if needed
    quantity: number = 0;
    price: number = 0;
}

export class ShippingViewModel {
    state: string = '';
    postalCode: string = '';
    country: string = '';
    phone: string = '';
    emailAddress: string = '';
}
