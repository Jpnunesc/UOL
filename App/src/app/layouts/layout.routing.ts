import { Routes } from '@angular/router';
import { AuthGuard } from '../components/auth/auth.guard';
import { NotificationFormComponent } from './notification/notification-form/notification-form.component';
import { NotificationListComponent } from './notification/notification-list/notification-list.component';

export const LayoutRoutes: Routes = [
    
    { path: 'notification/create', canActivate: [AuthGuard], component: NotificationFormComponent },
    { path: 'notification/edit/:id', canActivate: [AuthGuard], component: NotificationFormComponent },
    { path: 'notification/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: NotificationFormComponent },
    { path: 'notification/list', canActivate: [AuthGuard], component: NotificationListComponent },

];
