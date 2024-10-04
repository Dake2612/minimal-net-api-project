import { AutoMap } from "@automapper/classes";

export class OrderForUpdateRequest {
  constructor() {
    this.Code = '';
    this.CreatedAt = new Date();
    this.DeliverAt = new Date();
    this.State = '';
  }
  @AutoMap()
  public Code: string;
  @AutoMap()
  public CreatedAt: Date;
  @AutoMap()
  public DeliverAt: Date;
  @AutoMap()
  public State: string;
}
