import { Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { ServiceBase} from '../service-base/service-base';
import { ProductTypeView } from '../components/product-type/models/product-type-view';

@Injectable()
export class ProductTypeService extends ServiceBase<ProductTypeView> {
    constructor() {
        super({
            endpoint: `${environment.url_api}producttype`
        });
    }
}
