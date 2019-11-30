import {  MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
import { Component, OnInit, Inject, Input } from "@angular/core";
import { OrderProductDeleteViewModel } from "./delete.viewmodel";
import { OrderService } from "../../../../services/order.service";

@Component({
  selector: 'app-order-product-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss']
})
export class OrderProductDeleteComponent implements OnInit {
  @Input() ViewModel: OrderProductDeleteViewModel = new OrderProductDeleteViewModel();

  constructor(
    private dialogRef: MatDialogRef<OrderProductDeleteComponent>,
    private orderService: OrderService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {

  }

  ngOnInit() {
    this.ViewModel.Order.OrderId = this.data.orderId;
    this.ViewModel.Quantity = this.data.orderProduct.Quantity
    this.ViewModel.Product.Description = this.data.orderProduct.Description;
    this.ViewModel.OrderProductId = this.data.orderProduct.OrderProductId;
  }

  dismiss() {
    this.dialogRef.close(null);
  }

  delete() {
    this.orderService.deleteOrderProduct(this.ViewModel.Order.OrderId, this.ViewModel.OrderProductId).subscribe(orderProduct => {
      this.dialogRef.close(orderProduct);
    });
  }
}
