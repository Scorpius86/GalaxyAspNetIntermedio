import { Component, OnInit, Input, ViewChild, AfterViewInit, Output, EventEmitter } from '@angular/core';
import { Order } from 'src/app/ordermanager/models/order';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { debug } from 'util';
import { OrderService } from 'src/app/ordermanager/services/order.service';
import { OrderListViewModel } from './list.viewmodel';
import { OrderEditComponent } from '../edit/edit.component';

@Component({
  selector: 'app-order-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class OrderListComponent implements OnInit, AfterViewInit {
  @Input() ViewModel: OrderListViewModel;
  @Output() RowDblClick = new EventEmitter<Order>();

  displayedColumns = ['OrderId', 'FullUserName', 'FullClientName', 'TotalPrice','OrderDate'];
  dataSource: MatTableDataSource<Order>;

  constructor(
    private orderService: OrderService,
    private dialog: MatDialog) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  ngAfterViewInit() {
    
  }

  ngOnInit() {
    this.LoadOrders();
  }

  LoadOrders() {
    this.orderService.getOrdersByUserId(this.ViewModel.User.UserId).subscribe(orders => {
      this.ViewModel.OrdersCount = orders.length;
      this.ViewModel.OrdersTotalMount = 0;
      orders.forEach(order => {
        this.ViewModel.OrdersTotalMount += order.TotalPrice;
      });
      this.dataSource = new MatTableDataSource<Order>(orders);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });    
  }

  openAddOrderDialog(): void {
    let dialogRef = this.dialog.open(OrderEditComponent, {
      width: '450px',
      disableClose: true,
      data: {
        userId:this.ViewModel.User.UserId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.LoadOrders();
      }
    });
  }
}
