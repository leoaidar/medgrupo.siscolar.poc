import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.less']
})
export class SchoolListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  clickFunction(txt) {
    alert(txt);
  }

}
