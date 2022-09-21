import { Component} from '@angular/core';
import { Subscription } from 'rxjs';
import { LoadingService } from './service/loading.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  subscription: Subscription[] = [];
  isloading = false;
  constructor(public loader: LoadingService) {}

  ngOnInit() {
    this.subscription.push(this.loader.changes().subscribe((data) => {
        this.isloading = data.value;
    }));
}
}
