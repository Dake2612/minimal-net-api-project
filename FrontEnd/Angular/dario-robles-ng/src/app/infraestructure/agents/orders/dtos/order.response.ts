import { AutoMap } from "@automapper/classes";

export class OrderResponse {
  constructor() {
    this.OrderId = '';
    this.Code = '';
    this.CreatedAt = new Date();
    this.DeliverAt = new Date();
    this.State = '';
  }
  @AutoMap()
  public OrderId: string;
  @AutoMap()
  public Code: string;
  @AutoMap()
  public CreatedAt: Date;
  @AutoMap()
  public DeliverAt: Date;
  @AutoMap()
  public State: string;

}
