import { AutoMap } from "@automapper/classes";

export class OrderForCreationRequest {
  constructor() {
    this.Code = '';
    this.CreatedAt = new Date();
    this.State = '';
  }
  @AutoMap()
  public Code: string;
  @AutoMap()
  public CreatedAt: Date;
  @AutoMap()
  public State: string;
}
