import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LayoutRoutes } from './layout.routing';
import { ChartsModule } from 'ng2-charts';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from '../user/login/login.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { ComponentsModule } from '../components/components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserComponent } from '../user/user.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { NotificationFormComponent } from './notification/notification-form/notification-form.component';
import { NotificationListComponent } from './notification/notification-list/notification-list.component'; 



@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(LayoutRoutes),
    ChartsModule,
    NgbModule,
    ComponentsModule,
    ReactiveFormsModule,
    FormsModule,
    NgxPaginationModule
  ],
  declarations: [
    UserComponent,
    LoginComponent,
    AdminLayoutComponent,
    NotificationFormComponent,
    NotificationListComponent,
  ]
})

export class LayoutModule {}
