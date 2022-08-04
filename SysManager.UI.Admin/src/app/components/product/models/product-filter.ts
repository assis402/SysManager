export class ProductFilter{
    name: string;
    active: string;
    page: number;
    pageSize: number;
    productTypeId: string;
    categoryId: string;
    unityId: string;

    constructor(_name:string, _activbe:string, _page:number, _pageSize:number, _productTypeId: string, _categoryId: string, _unityId: string)
    {
        this.name = _name;
        this.active = _activbe;
        this.page = _page;
        this.pageSize = _pageSize;
        this.productTypeId = _productTypeId;
        this.categoryId = _categoryId;
        this.unityId = _unityId;
    }
}
