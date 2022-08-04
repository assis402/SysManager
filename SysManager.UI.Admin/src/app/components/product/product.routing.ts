import {Routes} from '@angular/router';
import {ProductViewComponent} from './models/product-view-component';
import {ProductComponent} from './product.component';
import {ProductMaintenanceComponent} from './product-maintenance/product-maintenance.component';

export const ProductRoutes: Routes = [
{
path:'',
component: ProductViewComponent,
children: [
           {
               path:'product',
               component: ProductComponent,
               data:{name:'Pesquisar produto', title: 'Pesquisar produto'}
           },
           {
               path:'maintenance',
               component: ProductMaintenanceComponent,
               data:{name:'Inserir produto', title: 'Inserir produto'}
           },
           {
               path:'maintenance/:id',
               component: ProductMaintenanceComponent,
               data:{name:'Inserir produto', title: 'Inserir produto'}
           }
          ]
}
];
