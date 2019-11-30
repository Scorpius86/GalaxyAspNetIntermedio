import { Component, OnInit, ViewChild, Input, EventEmitter, Output } from '@angular/core';
import { OrderProduct } from 'src/app/ordermanager/models/order-product';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatBottomSheet } from '@angular/material';
import { OrderService } from 'src/app/ordermanager/services/order.service';
import { OrderProductListViewModel } from './list.viewmodel';
import { OrderProductEditComponent } from '../edit/edit.component';
import { debug } from 'util';
import { OrderProductDeleteComponent } from '../delete/delete.component';

@Component({
  selector: 'app-order-product-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class OrderProductListComponent implements OnInit {
  displayedColumns = [
    'OrderProductId',
    'ProductId',
    'Description',
    'BrandDescription',
    'UnitDescription',
    'Quantity',
    'Price',
    'TotalPrice',
    'Delete'
  ];
  dataSource: MatTableDataSource<OrderProduct>;
  @Input() ViewModel: OrderProductListViewModel = new OrderProductListViewModel();
  @Output() LoadOrders: EventEmitter<void> = new EventEmitter<void>();

  constructor(
    private orderService: OrderService,
    private dialog: MatDialog,
    private dialogDelete: MatDialog
  ) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
  }

  LoadOrderDetail() {
    this.orderService.getOrderDetail(this.ViewModel.Order.OrderId).subscribe(orderProducts => {
      this.dataSource = new MatTableDataSource<OrderProduct>(orderProducts);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;

    });
  }

  openAddOrderProductDialog(orderProduct: OrderProduct): void {
    let dialogRef = this.dialog.open(OrderProductEditComponent, {
      width: '450px',
      disableClose: true,
      data: {
        orderId: this.ViewModel.Order.OrderId,
        orderProduct: orderProduct
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.LoadOrderDetail();
        this.LoadOrders.emit();
      }
    });
  }

  openDeleteOrderProductBottomSheet(orderProduct:OrderProduct): void {
    let dialogRef = this.dialogDelete.open(OrderProductDeleteComponent, {
      width: '450px',
      disableClose: true,
      data: {
        orderId: this.ViewModel.Order.OrderId,
        orderProduct: orderProduct
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.LoadOrderDetail();
        this.LoadOrders.emit();
      }
    });
  }  

  RowDblClick(orderProduct: OrderProduct): void{
    this.openAddOrderProductDialog(orderProduct);
  }
}
