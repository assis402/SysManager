import { ProductView } from "./product-view";

export class ProductPut{
    id: string;
    name: string;
    productCode: string;
    productTypeId: string;
    categoryId: string;
    unityId: string;
    costPrice: number;
    percentage: number;
    price: number;
    active: boolean;

    constructor(obj: ProductView) {
        this.id = obj.id;
        this.name = obj.name;
        this.productCode = obj.productCode;
        this.productTypeId = obj.productTypeId;
        this.categoryId = obj.categoryId;
        this.unityId = obj.unityId;
        this.costPrice = obj.costPrice;
        this.percentage = obj.percentage;
        this.price = obj.price;
        this.active = obj.active;
      }
}
