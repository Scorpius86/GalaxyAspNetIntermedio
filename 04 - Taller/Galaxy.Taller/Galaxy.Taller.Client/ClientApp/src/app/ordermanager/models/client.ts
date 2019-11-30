export class Client {
  public ClientId: number;
  public Name: string;
  public FullName: string;
  public LastName: string;
  public SurName: string;
  public Age: number;
  public SexDescription: string;

  constructor() {
    this.ClientId = 0;
    this.Name = '';
    this.FullName = '';
    this.LastName = '';
    this.SurName = '';
    this.Age = 0;
    this.SexDescription = '';
  }
}
