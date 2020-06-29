import { Component, OnInit } from '@angular/core';

import { SchoolClass } from '../shared/schoolclass.model';
import { SchoolclassService } from '../shared/schoolclass.service';

@Component({
  selector: 'app-schoolclass-list',
  templateUrl: './schoolclass-list.component.html',
  styleUrls: ['./schoolclass-list.component.less']
})
export class SchoolclassListComponent implements OnInit {

  schoolclasses: SchoolClass[] = [];
  // schools: School[] = [School];
  // schools: School[] = new Array<School>();

  constructor(private schoolclassService: SchoolclassService) { }

  ngOnInit(): void {
    console.log('chegou aqui getAll()');
    this.schoolclassService.getAll().subscribe(
      schoolclasses => this.schoolclasses = schoolclasses,
      error => alert('Erro ao carregar a lista de Escolas')
    );
  }

  clickFunction(txt): void {
    alert(txt);
  }

  deleteSchool(schoolclass): void {
    const mustDelete = confirm('Deseja realmante apagar a turma?');

    if (mustDelete) {
      this.schoolclassService.delete(schoolclass.id).subscribe(
        () => this.schoolclasses = this.schoolclasses.filter(element => element !== schoolclass),
        () => alert('Erro ao tentar excluir uma turma')
      );
    }
  }
}
