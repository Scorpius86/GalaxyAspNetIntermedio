import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user.service';
import { MainContentViewModel } from './main-content.viewmodel';
import { Order } from '../../models/order';
import { OrderProductListComponent } from '../order/product/list/list.component';
import { OrderListComponent } from '../order/list/list.component';

@Component({
  selector: 'app-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {
  ViewModel: MainContentViewModel;
  @ViewChild(OrderProductListComponent) orderProductListComponent: OrderProductListComponent;
  @ViewChild(OrderListComponent) orderListComponent: OrderListComponent;
  TabSelected: number = 0;
  isDisabled: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private service: UserService
  ) {
    
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.ViewModel = new MainContentViewModel();
      this.TabSelected = 0;

      let userId = params['userId'];
      if (!userId) userId = 1;
      this.ViewModel.User = null;

      this.service.users.subscribe(users => {
        if (users.length == 0) return;

        setTimeout(() => {
          this.ViewModel.User = this.service.userById(userId);
          this.ViewModel.OrderListViewModel.User = this.ViewModel.User;
        }, 500);
      });

    })
  }

  LoadOrderDetail(order: Order) {
    this.TabSelected = 1;
    this.ViewModel.OrderProductListViewModel.Order = order;
    this.isDisabled = false;

    this.orderProductListComponent.LoadOrderDetail();
  }

  LoadOrders() {
    this.orderListComponent.LoadOrders();
  }

  ChangeTab(tabSelected: number) {
    this.TabSelected = tabSelected;
  }

}
