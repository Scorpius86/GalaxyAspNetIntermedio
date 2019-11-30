import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdermanagerAppComponent } from './ordermanager-app.component';
import { MainContentComponent } from './components/main-content/main-content.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { MaterialModule } from '../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { OrderListComponent } from './components/order/list/list.component';
import { OrderEditComponent } from './components/order/edit/edit.component';
import { UserService } from './services/user.service';
import { OrderService } from './services/order.service';
import { OrderProductListComponent } from './components/order/product/list/list.component';
import { OrderProductEditComponent } from './components/order/product/edit/edit.component';
import { ClientService } from './services/client.service';
import { OrderProductDeleteComponent } from './components/order/product/delete/delete.component';


const routes: Routes = [
  {
    path: '', component: OrdermanagerAppComponent,
    children: [
      { path: ':userId', component: MainContentComponent },
      { path: '', component: MainContentComponent }
    ]
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  declarations: [
    OrdermanagerAppComponent,
    ToolbarComponent,
    MainContentComponent,
    SidenavComponent,
    OrderListComponent,
    OrderEditComponent,
    OrderProductDeleteComponent,
    OrderProductListComponent,
    OrderProductEditComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    UserService,
    ClientService,
    OrderService
  ],
  entryComponents: [
    OrderEditComponent,
    OrderProductEditComponent,
    OrderProductDeleteComponent
  ]
})
export class OrdermanagerModule { }
