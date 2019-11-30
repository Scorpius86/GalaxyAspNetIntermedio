export class Product {
  public ProductId: number;
  public BrandDescription: string;
  public Description: string;
  public Price: number;
  public Unit: string;

  constructor() {
    this.ProductId = 0;
    this.BrandDescription = '';
    this.Description = '';
    this.Price = 0;
    this.Unit = '';
  }
}
