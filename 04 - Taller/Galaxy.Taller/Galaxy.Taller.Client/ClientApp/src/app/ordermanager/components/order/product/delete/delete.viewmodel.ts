import { Product } from '../../../../models/product';
import { Order } from "../../../../models/order";

export class OrderProductDeleteViewModel {
  public OrderProductId: number;
  public Product: Product;
  public Order: Order;
  public Quantity: number;

  constructor() {
    this.OrderProductId = 0;
    this.Product = new Product();
    this.Order = new Order();
    this.Quantity = 0;
  }
}
