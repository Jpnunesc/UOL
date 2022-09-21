import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { LoadingService } from '../../service/loading.service';
import { AuthenticationService } from '../../service/authentication.service';



@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private loadingService: LoadingService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.authenticationService.logout();
    this.loginForm = this.formBuilder.group({
      nome: ['', Validators.required],
      senha: ['', Validators.required]
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/notification';
  }
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.loadingService.start();
    this.authenticationService.login(this.f.nome.value, this.f.senha.value)
      .pipe(first())
      .subscribe(
        data => {
          this.loadingService.stop();
          if (data.success) {
            this.toastr.success(data.message);
            this.router.navigate([this.returnUrl]);
          } else {
            this.toastr.error(data.message);
          }
          this.loading = false;
        }, () => { this.loadingService.stop(); });
  }
}
