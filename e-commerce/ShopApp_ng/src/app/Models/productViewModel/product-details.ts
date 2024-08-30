import { Color } from "./color_size/color";
import { Size } from "./color_size/size";

export class ProductDetails {
    id: number  | undefined;
    name: string | undefined;
    description?: string  | undefined;
    sizes?: Size[]  | undefined;
    colors?: Color[]  | undefined;
    quantity: number =0 ;
    price: number  =1;
    imageURL?: string  | undefined;
    productTypeId: string  | undefined;
    category: string  | undefined;
    productType?: string  | undefined;
    
}
