export class ProductDetails {
    id: number  | undefined;
    name: string | undefined;
    description?: string  | undefined;
    sizes?: Size[]  | undefined;
    colors?: Color[]  | undefined;
    quantity: number  | undefined;
    price: number  | undefined;
    imageURL?: string  | undefined;
    productTypeId: string  | undefined;
    category: string  | undefined;
    productType?: string  | undefined;
    
}
export class Size {
    name: string | undefined;
  }
  
  export class Color {
    name: string | undefined;
    hexValue: string | undefined;
  }
