export class UnityFilter {
  name: string;
  active: string;
  page: number;
  pageSize: number;

  constructor(name: string, active: string, page: number, pageSize: number){
    this.name = name,
    this.active = active,
    this.page = page,
    this.pageSize = pageSize
  }
}
