import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Client } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private clientsUrl = 'https://localhost:44389/api/clients';

  constructor(private http: HttpClient) { }

  getClients() {
    return this.http.get<Client[]>(this.clientsUrl);
  }
}
