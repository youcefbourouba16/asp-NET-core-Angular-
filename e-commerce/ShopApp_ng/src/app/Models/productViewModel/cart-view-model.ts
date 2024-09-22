import { ProductViewModel } from "./product-view-model";

export class CartViewModel {
    id: number=0;
    name?: string;
    description?: string;
    size?: string;
    color?: string;
    quantityBuying: number = 1;
    quantity: number = 1;
    price: number = 1;
    imageURL?: string;
    productTypeId?: string;
    category?: string;
    productType?: string;
}
