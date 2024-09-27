import { AutoMap } from "@automapper/classes";

export class Order {
  constructor() {
    this.OrderId = '';
    this.Code = '';
    this.DeliverAt = new Date();
    this.CreatedAt = new Date();
    this.State = '';
  }
  @AutoMap()
  public OrderId: string;
  @AutoMap()
  public Code: string;
  @AutoMap()
  public DeliverAt: Date;
  @AutoMap()
  public CreatedAt: Date;
  @AutoMap()
  public State: string;
}
