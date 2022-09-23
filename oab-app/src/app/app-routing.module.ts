import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './components/auth/auth.guard';
import { ProductListComponent } from './layouts/product/product-list/product-list.component';
import { LoginComponent } from './layouts/user/login/login.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    canActivate: [AuthGuard], component: ProductListComponent,
    children:
      [
        {
          path: '',
          loadChildren: () => import('../app/layouts/layout.module').then(m => m.LayoutModule)
        }
      ]
  }
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [],
})
export class AppRoutingModule { }