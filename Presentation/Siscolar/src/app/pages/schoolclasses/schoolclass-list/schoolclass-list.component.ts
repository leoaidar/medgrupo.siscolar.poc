import { Component, OnInit } from '@angular/core';

import { SchoolClass } from '../shared/schoolclass-model';
import { SchoolClassService } from '../shared/schoolclass.service';

@Component({
  selector: 'app-schoolclass-list',
  templateUrl: './schoolclass-list.component.html',
  styleUrls: ['./schoolclass-list.component.less']
})
export class SchoolclassListComponent implements OnInit {

  schoolClasses: SchoolClass[] = [];

  constructor(private schoolClassService: SchoolClassService) { }

  ngOnInit(): void {
    this.schoolClassService.getAll().subscribe(
      schoolClasses => this.schoolClasses = schoolClasses,
      error => alert('Erro ao carregar a lista das Turmas')
    );    
  }

  deleteSchool(schoolClass): void {
    const mustDelete = confirm('Deseja realmante apagar a escola?');

    if (mustDelete) {
      this.schoolClassService.delete(schoolClass.id).subscribe(
        () => this.schoolClasses = this.schoolClasses.filter(element => element !== schoolClass),
        () => alert('Erro ao tentar excluir uma escola')
      );
    }
  }  

}
