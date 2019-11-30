import { Product } from '../../../../models/product';
import { Order } from "../../../../models/order";

export class OrderProductEditViewModel {
  public Products: Product[];
  public Order: Order;
  public ProductId: number;
  public Quantity: number;

  constructor() {
    this.Products = new Array<Product>();
    this.Order = new Order();
    this.ProductId = 0;
    this.Quantity = 0;
  }
}
