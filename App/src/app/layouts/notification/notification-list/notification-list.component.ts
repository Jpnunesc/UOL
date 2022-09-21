import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { LoadingService } from '../../../service/loading.service';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.css']
})
export class NotificationListComponent implements OnInit {

  data = [];
  opemModal = false;
  idItemDelete = 0;
  formFilter: FormGroup;
  totalItems = 0;
  listTipos = [{id:1, nome: 'E-mail'}, {id:2, nome: 'SMS'}]

  constructor(private notificationService: NotificationService,
    private fb: FormBuilder,
    private loadingService: LoadingService,
    private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.formFilter = this.fb.group({
      tipo: [],
      page:[],
      pageSize: []
    });
    this.formFilter.get('page').setValue('1');
    this.formFilter.get('pageSize').setValue('50');
    this.getNotification();

  }
  getNotification() {
    this.loadingService.start();
    this.notificationService.getByFilter(this.formFilter.value).subscribe((element) => {
      this.loadingService.stop();
      if (element && element.status) {
        this.data = element.object.notification;
        this.totalItems = element.object.totalItems;
      } else {
        this.data = [];
      }
    }), (error => {
      this.loadingService.stop();
      this.toastr.error(error);
    })
  }
  deleteItem() {
    if (this.idItemDelete) {
      this.loadingService.start();
      this.notificationService.httpDelete(this.idItemDelete).subscribe(data => {
        this.opemModal = false;
        this.loadingService.stop();
        if (data && data.status) {
          this.toastr.success(data.message);
          this.getNotification();
        } else {
          this.toastr.error(data.message);
        }
      }), (error) => {
        this.loadingService.stop();
        this.toastr.error('Internal error!');
        console.log(error);
      }
    }
  }
}
