import { Injectable} from '@angular/core';
import { environment } from '../../environments/environment';
import { ServiceBase} from '../service-base/service-base';
import { UnityView } from '../components/unity/models/unity-view';

@Injectable()
export class UnityService extends ServiceBase<UnityView> {
    constructor() {
        super({
            endpoint: `${environment.url_api}unity`
        }); 
    }
}