import { Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { ServiceBase} from '../service-base/service-base';
import { CategoryView } from '../components/category/models/category-view';

@Injectable()
export class CategoryService extends ServiceBase<CategoryView> {
    constructor() {
        super({
            endpoint: `${environment.url_api}category`
        });
    }
}
