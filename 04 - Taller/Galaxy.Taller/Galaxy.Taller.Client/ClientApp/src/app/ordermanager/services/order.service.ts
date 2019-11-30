import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order';
import { OrderProduct } from '../models/order-product';
import { OrderCreate } from '../models/order-create';
import { OrderProductEdit } from '../models/order-product-edit';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersUrl = 'https://localhost:44389/api/orders';

  constructor(private http: HttpClient) { }

  getOrdersByUserId(userId:number) {
    return this.http.get<Order[]>(this.ordersUrl+"?userId="+userId);
  }

  createOrder(orderCreate: OrderCreate) {
    return this.http.post<Order>(this.ordersUrl, orderCreate);
  }

  createOrderProduct(orderId:number,orderProductEdit: OrderProductEdit) {
    return this.http.post<OrderProduct>(this.ordersUrl + "/" + orderId + "/products", orderProductEdit);
  }

  updateOrderProduct(orderId: number, orderProductId: number, orderProductEdit: OrderProductEdit) {
    return this.http.put<OrderProduct>(this.ordersUrl + "/" + orderId + "/products/" + orderProductId , orderProductEdit);
  }

  deleteOrderProduct(orderId: number, orderProductId: number) {
    return this.http.delete<OrderProduct>(this.ordersUrl + "/" + orderId + "/products/" + orderProductId);
  }

  getOrder(orderId: number) {
    return this.http.get<Order>(this.ordersUrl + "/" + orderId);
  }

  getOrderDetail(orderId: number) {
    return this.http.get<OrderProduct[]>(this.ordersUrl + "/" + orderId + "/products");
  }
}
