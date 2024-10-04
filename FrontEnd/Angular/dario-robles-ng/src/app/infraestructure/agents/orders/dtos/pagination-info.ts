export class PaginationInfo {
  constructor() {
    this.currentPage = 0;
    this.totalPages = 0;
    this.pageSize = 0;
    this.totalCount = 0;
    this.previousPageLink = null;
    this.nextPageLink = null;
  }

  public currentPage: number;
  public totalPages: number;
  public pageSize: number;
  public totalCount: number;
  public previousPageLink: string | null;
  public nextPageLink: string | null;
}
