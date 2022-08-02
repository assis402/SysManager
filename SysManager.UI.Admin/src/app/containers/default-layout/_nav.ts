import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    badge: {
      color: 'info',
      text: 'NEW'
    }
  },
  {
    name:'Modulos',
    title: true
  },
  {
    name:'Produto',
    url:'/product',
    iconComponent:{name:'cil-Inbox'},
    children:[
      {
       iconComponent:{name:'cil-Menu'},
       name:'Meus produtos',
       url:'/product/product'
      },
      {
        iconComponent:{name:'cil-Spreadsheet'},
        name:'Novo produto',
        url:'/product/maintenance'
       }
    ]
  },
  {
    name:'Cadastros auxiliares',
    title: true
  },
  {
    name:'Unidade de medida',
    url:'/unity',
    iconComponent:{name:'cil-List'},
    children:[
      {
       iconComponent:{name:'cil-Menu'},
       name:'Minhas unidades',
       url:'/unity/unity'
      },
      {
        iconComponent:{name:'cil-Spreadsheet'},
        name:'Nova unidade',
        url:'/unity/maintenance'
       }
    ]
  },
  {
    name:'Tipo de produto',
    url:'/product-type',
    iconComponent:{name:'cil-List'},
    children:[
      {
       iconComponent:{name:'cil-Menu'},
       name:'Meus tipos',
       url:'/product-type/product-type'
      },
      {
        iconComponent:{name:'cil-Spreadsheet'},
        name:'Novo tipo',
        url:'/product-type/maintenance'
      }
    ]
  },
  {
    name:'Categoria',
    url:'/category',
    iconComponent:{name:'cil-Tags'},
    children:[
      {
       iconComponent:{name:'cil-Menu'},
       name:'Minhas categorias',
       url:'/category/category'
      },
      {
        iconComponent:{name:'cil-Spreadsheet'},
        name:'Nova categoria',
        url:'/category/maintenance'
       }
    ]
  },
  {
    name:'Logout',
    title:true
  },
  {
    name:'Sair',
    url:'/login',
    iconComponent:{name:'cil-AccountLogout'}
  }

];
