import { Order } from '../../../../models/order';

export class OrderProductListViewModel {
  public Order: Order;

  constructor() {
    this.Order = new Order();
  }
}
