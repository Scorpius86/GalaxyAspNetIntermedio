import { Component, OnInit, Input, Inject, ViewChild } from '@angular/core';
import { forkJoin, Observable } from 'rxjs';
import { ProductService } from '../../../../services/product.service';
import { OrderProductEditViewModel } from './edit.viewmodel';
import { OrderService } from 'src/app/ordermanager/services/order.service';
import { MAT_DIALOG_DATA, MatDialogRef, MatAutocompleteSelectedEvent, MatAutocomplete } from '@angular/material';
import { OrderProductEdit } from 'src/app/ordermanager/models/order-product-edit';
import { FormControl } from '@angular/forms';
import { Product } from 'src/app/ordermanager/models/product';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-order-product-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class OrderProductEditComponent implements OnInit {
  @Input() ViewModel: OrderProductEditViewModel = new OrderProductEditViewModel();
  @ViewChild(MatAutocomplete) matAutocomplete: MatAutocomplete;
  productCtrl = new FormControl();
  filteredProducts: Observable<Product[]>;
  displayedColumns = [
    'BrandDescription',
    'Description'
  ]

  constructor(
    private dialogRef: MatDialogRef<OrderProductEditComponent>,
    private productService: ProductService,
    private orderService: OrderService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.filteredProducts = this.productCtrl.valueChanges
      .pipe(
        startWith(''),
        map(product => product ? this._filterProducts(product) : this.ViewModel.Products.slice())
      );
  }

  ngOnInit() {
    forkJoin(
      this.productService.getProducts(),
      this.orderService.getOrder(this.data.orderId)
    ).subscribe(results => {
      this.ViewModel.Products = results[0];
      this.ViewModel.Order = results[1];
    });

    if (this.data.orderProduct) {
      this.ViewModel.Quantity = this.data.orderProduct.Quantity;
      this.ViewModel.ProductId = this.data.orderProduct.ProductId;

      let product: Product = new Product();
      product.Description = this.data.orderProduct.Description;
      product.ProductId = this.data.orderProduct.ProductId;
      product.BrandDescription = this.data.orderProduct.BrandDescription;
      product.Price = this.data.orderProduct.Price;
      product.Unit = this.data.orderProduct.UnitDescription;
      this.productCtrl.setValue(product);
    }
  }

  save() {
    let orderProductEdit: OrderProductEdit = {
      ProductId: this.ViewModel.ProductId,
      Quantity: this.ViewModel.Quantity
    }
    if (this.data.orderProduct) {
      this.orderService.updateOrderProduct(this.ViewModel.Order.OrderId, this.data.orderProduct.OrderProductId, orderProductEdit).subscribe(orderProduct => {
        this.dialogRef.close(orderProduct);
      });
    } else {
      this.orderService.createOrderProduct(this.ViewModel.Order.OrderId, orderProductEdit).subscribe(orderProduct => {
        this.dialogRef.close(orderProduct);
      });
    }
  }

  dismiss() {
    this.dialogRef.close(null);
  }

  isDisabled(): boolean {
    return this.ViewModel.ProductId == 0 || this.ViewModel.Quantity == 0;
  }

  private _filterProducts(value: any): Product[] {
    let filterValue:string;

    if (typeof value == "object") {
      filterValue = (value as Product).Description;
    } else {
      filterValue = (value as string).toLowerCase();      
    }

    return this.ViewModel.Products.filter(product => product.Description.toLowerCase().includes(filterValue));
  }

  optionSelected(e:MatAutocompleteSelectedEvent) {
    this.ViewModel.ProductId = (e.option.value as Product).ProductId; 
  }

  displayFn(product?: Product): string | undefined {
    return product? product.Description : undefined;
  }

  changeInputProduct(e): void {
    if (this.ViewModel.ProductId !=0) {
      this.ViewModel.ProductId=0
    }
  }

}
