import { Component, OnInit } from '@angular/core';
import { ICause } from '../shared/interfaces/cause';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  selectedCause: ICause;

  selectedCauseHandler(cause: ICause) {
    this.selectedCause = cause;
  }
}
