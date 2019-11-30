import { Component, OnInit, Input, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { OrderEditViewModel } from './edit.viewmodel';
import { ClientService } from 'src/app/ordermanager/services/client.service';
import { debug } from 'util';
import { forkJoin } from 'rxjs';
import { UserService } from 'src/app/ordermanager/services/user.service';
import { OrderService } from 'src/app/ordermanager/services/order.service';
import { OrderCreate } from 'src/app/ordermanager/models/order-create';

@Component({
  selector: 'app-order-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class OrderEditComponent implements OnInit {
  @Input() ViewModel: OrderEditViewModel = new OrderEditViewModel();
  

  constructor(
    private dialogRef: MatDialogRef<OrderEditComponent>,
    private clientService: ClientService,
    private orderService: OrderService,
    private userService: UserService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit() {
    forkJoin(
      this.clientService.getClients(),
      this.userService.getUser(this.data.userId)
    ).subscribe(results => {
      this.ViewModel.Clients = results[0];
      this.ViewModel.User = results[1];
    });

    
  }

  save() {
    let orderCreate:OrderCreate = {
      UserId: this.ViewModel.User.UserId,
      ClientId: this.ViewModel.ClientId
    }

    this.orderService.createOrder(orderCreate).subscribe(order => {
      this.dialogRef.close(order);
    });
  }

  isDisabled(): boolean {
    return this.ViewModel.ClientId == 0;
  };

  dismiss() {
    this.dialogRef.close(null);
  }

}
