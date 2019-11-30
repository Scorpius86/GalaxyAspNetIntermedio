import { User } from '../../../models/user';

export class OrderListViewModel {
  public User: User;
  public OrdersCount: number;
  public OrdersTotalMount: number;

  constructor() {
    this.User = new User();
    this.OrdersCount = 0;
    this.OrdersTotalMount = 0;
  }
}
