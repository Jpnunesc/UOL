import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/components/service/authentication.service';
import { LoadingService } from 'src/app/components/service/loading.service';



@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.css']
})

export class LoginComponent implements OnInit {
  loading = false;
  submitted = false;
  error = '';

  loginForm = new FormGroup({
    nome: new FormControl('', {nonNullable: true}),
    senha: new FormControl('', {nonNullable: true}),
});

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private loadingService: LoadingService,
  ) { }

  ngOnInit() {
    this.authenticationService.logout();
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    debugger;
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.loadingService.start();
    this.authenticationService.login(this.loginForm.get('nome')?.value , this.loginForm.get('senha')?.value)
      .pipe(first())
      .subscribe(
        data => {
          this.loadingService.stop();
          if (data.success) {
            // this.toastr.success(data.message);
           // this.router.navigate([this.returnUrl]);
          } else {
            // this.toastr.error(data.message);
          }
          this.loading = false;
        }, () => { this.loadingService.stop(); });
  }
}
