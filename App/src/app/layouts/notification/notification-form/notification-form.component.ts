import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoadingService } from '../../../service/loading.service';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-notification-form',
  templateUrl: './notification-form.component.html',
  styleUrls: ['./notification-form.component.css']
})
export class NotificationFormComponent implements OnInit {

  form: FormGroup;
  disabled = false;
  retunrUrl = '../list'
  routerId = 0;
  listTipos = [{id:1, nome: 'E-mail'}, {id:2, nome: 'SMS'}]
  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private loadingService: LoadingService,
    private notificationService: NotificationService,
    public activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [],
      tipo: ['', [Validators.required]],
      mensagem: ['', [Validators.required, Validators.maxLength(250)]],
      emailDestinatario: [''],
      emailOrigem: [''],
      numDestinario: [''],
      assunto: ['', [Validators.required]],
      cliente: ['', [Validators.required]],
      nomeUsuario: ['', [Validators.required]]
    });
    this.routerId = this.activeRoute.snapshot.params.id;
    if (this.routerId) {
      this.disabled = this.activeRoute.snapshot.data.detail ? true : false;
      this.retunrUrl = '../../list'
      this.getById(this.routerId);
    }
  }
  getById(id) {
    this.loadingService.start();
    this.notificationService.httpGetId(id).subscribe(data => {
      this.loadingService.stop();
      if (data && data.status) {
        this.form.patchValue(data.object);
      }
    }), error => {
      this.loadingService.stop();
      console.log(error);
    };
  }
  save() {
    if (!this.form.valid) return;
    let body = this.form.value;
    body.tipo = Number(body.tipo);
    this.loadingService.start();
    if (this.activeRoute.snapshot.params.id) {
      this.notificationService.httpPut(body).subscribe((data) => {
        this.loadingService.stop();
        this.form.reset();
        if (data && data.status) {
          this.toastr.success(data.message);
        } else {
          this.toastr.error(data.message);
        }
      }), (error) => {
        this.toastr.error(error);
        this.loadingService.stop();
      }
    } else {
      this.notificationService.httpPost(body).subscribe(data => {
        this.loadingService.stop();
        this.form.reset();
        if (data && data.status) {
          this.toastr.success(data.message);
        } else {
          this.toastr.error(data.message);
        }
      }), (error) => {
        this.toastr.error(error);
        this.loadingService.stop();
      }
    }
  }
}