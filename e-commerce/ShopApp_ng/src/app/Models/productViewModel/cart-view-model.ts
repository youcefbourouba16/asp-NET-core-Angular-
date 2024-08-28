import { ProductViewModel } from "./product-view-model";

export class CartViewModel {
    id: number  | undefined;
    name: string | undefined;
    description?: string  | undefined;
    size: string  | undefined;
    color: string  | undefined;
    quantityBuying: number =1;
    quantity :number=1;
    price: number  =1;
    imageURL?: string  | undefined;
    productTypeId: string  | undefined;
    category: string  | undefined;
    productType?: string  | undefined;

}
