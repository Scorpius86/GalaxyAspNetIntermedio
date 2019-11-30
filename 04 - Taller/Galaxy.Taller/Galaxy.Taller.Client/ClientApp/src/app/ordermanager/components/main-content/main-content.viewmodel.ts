import { User } from "../../models/user";
import { OrderListViewModel } from "../order/list/list.viewmodel";
import { OrderProductListViewModel } from "../order/product/list/list.viewmodel";

export class MainContentViewModel{
  public User: User;
  public OrderListViewModel: OrderListViewModel;
  public OrderProductListViewModel: OrderProductListViewModel;

  constructor() {
    this.User = new User();
    this.OrderListViewModel = new OrderListViewModel();
    this.OrderProductListViewModel = new OrderProductListViewModel();
  }
}
