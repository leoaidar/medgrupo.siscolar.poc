import { Component, OnInit } from '@angular/core';

import { School } from '../shared/school-model';
import { SchoolService } from '../shared/school.service';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.less']
})
export class SchoolListComponent implements OnInit {

  schools: School[] = [];
  // schools: School[] = [School];
  // schools: School[] = new Array<School>();

  constructor(private schoolService: SchoolService) { }

  ngOnInit(): void {
    this.schoolService.getAll().subscribe(
      schools => this.schools = schools,
      error => alert('Erro ao carregar a lista de Escolas')
    );
  }

  clickFunction(txt): void {
    alert(txt);
  }

  deleteSchool(school): void {
    const mustDelete = confirm('Deseja realmante apagar a escola?');

    if (mustDelete) {
      this.schoolService.delete(school.id).subscribe(
        () => this.schools = this.schools.filter(element => element !== school),
        () => alert('Erro ao tentar excluir uma escola')
      );
    }
  }

}
