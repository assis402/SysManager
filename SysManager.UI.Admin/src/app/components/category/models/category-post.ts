import {CategoryView} from './category-view';

export class CategoryPost{
    name: string;
    active: boolean;

    constructor(obj: CategoryView) {
      this.name = obj.name;
      this.active = obj.active;
    }
}
