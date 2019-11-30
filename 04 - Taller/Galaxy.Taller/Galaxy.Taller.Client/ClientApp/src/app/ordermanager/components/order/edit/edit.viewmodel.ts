import { Client } from '../../../models/client';
import { User } from '../../../models/user';

export class OrderEditViewModel {
  public Clients: Client[];
  public User: User;
  public ClientId: number;

  constructor() {
    this.Clients = new Array<Client>();
    this.User = new User();
    this.ClientId = 0;
  }
}
