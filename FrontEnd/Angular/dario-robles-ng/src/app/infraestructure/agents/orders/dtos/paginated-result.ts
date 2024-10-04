import { PaginationInfo } from "./pagination-info";

export class PaginatedResult<T> {
  constructor() {
    this.data = new Array<T>();
    this.pagination = new PaginationInfo();
  }

  public data: T[];
  public pagination: PaginationInfo;
}
