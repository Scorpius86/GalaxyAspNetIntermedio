import { Component, OnInit, NgZone, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { MatSidenav } from '@angular/material';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { OrderService } from '../../services/order.service';

const SMALL_WIDTH_BREAKPOINT = 720;

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  private mediaMatcher: MediaQueryList =
    matchMedia(`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`);

  users: Observable<User[]>;
  public isDarkTheme: boolean = false;
  dir: string = 'ltr';

  constructor(
    zone: NgZone,
    private userService: UserService,
    private orderService: OrderService,
    private router: Router) {
    this.mediaMatcher.addListener(mql =>
      zone.run(() => this.mediaMatcher = matchMedia(`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`)));
  }

  @ViewChild(MatSidenav) sidenav: MatSidenav;

  public toggleTheme() {
    this.isDarkTheme = !this.isDarkTheme;
  }

  public toggleDir() {
    this.dir = this.dir == 'ltr' ? 'rtl' : 'ltr';
    this.sidenav.toggle().then(() => this.sidenav.toggle());
  }

  ngOnInit() {
    this.users = this.userService.users;
    this.userService.loadAll();

    this.router.events.subscribe(() => {
      if (this.isScreenSmall())
        this.sidenav.close();
    })
  }

  public isScreenSmall(): boolean {
    return this.mediaMatcher.matches;
  }

  public clickSeller(userId: number) {

    //[routerLink] = "['/ordermanager', user.UserId]

  }
}
