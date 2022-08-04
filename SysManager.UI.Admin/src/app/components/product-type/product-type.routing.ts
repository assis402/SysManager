import {Routes} from '@angular/router';
import {ProductTypeViewComponent} from './models/product-type-view-component';
import {ProductTypeComponent} from './product-type.component';
import {ProductTypeMaintenanceComponent} from './product-type-maintenance/product-type-maintenance.component';

export const ProductTypeRoutes: Routes = [
{
path:'',
component: ProductTypeViewComponent,
children: [
           {
               path:'product-type',
               component: ProductTypeComponent,
               data:{name:'Pesquisar tipo de produto', title: 'Pesquisar tipo de produto'}
           },
           {
               path:'maintenance',
               component: ProductTypeMaintenanceComponent,
               data:{name:'Inserir tipo de produto', title: 'Inserir tipo de produto'}
           },
           {
               path:'maintenance/:id',
               component: ProductTypeMaintenanceComponent,
               data:{name:'Inserir tipo de produto', title: 'Inserir tipo de produto'}
           }
          ]
}
];
