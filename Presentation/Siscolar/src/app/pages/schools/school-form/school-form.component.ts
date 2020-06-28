import { Component, OnInit, AfterContentChecked } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { School } from '../shared/school-model';
import { SchoolService } from '../shared/school.service';

import { switchMap } from 'rxjs/operators';

import toastr from 'toastr';

@Component({
  selector: 'app-school-form',
  templateUrl: './school-form.component.html',
  styleUrls: ['./school-form.component.less']
})
export class SchoolFormComponent implements OnInit, AfterContentChecked {

  currentAction: string;
  schoolForm: FormGroup;
  pageTitle: string;
  serverErrorMessages: string[] = null;
  submittingForm = false;
  school: School = new School();

  constructor(
    private schoolService: SchoolService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.setCurrentAction();
    this.buildSchoolForm();
    this.loadSchool();
  }

  ngAfterContentChecked(): void {
    this.setPageTitle();
  }

  submitForm(): void {
    this.submittingForm = true;

    if (this.currentAction === 'new') {
      this.createSchool();
    } else {
      this.updateSchool();
    }
  }

  createSchool(): void {
    const school: School = Object.assign(new School(), this.schoolForm.value);

    this.schoolService.create(school).subscribe(
                          school => this.actionForSuccess(school),
                          error => this.actionsFormError(error)
                        );
  }

  updateSchool(): void {
    const school: School = Object.assign(new School(), this.schoolForm.value);

    this.schoolService.update(school).subscribe(
                          school => this.actionForSuccess(school),
                          error => this.actionsFormError(error)
                        );
  }

  actionForSuccess(school: School): void {
    toastr.success('Solicitaçao processada com sucesso!');
    // redirecting and reloading compoment
    this.router.navigateByUrl('schools', {skipLocationChange: true}).then(
      // () => this.router.navigate(['school'], school.id, 'edit')
      () => this.router.navigate(['schools', school.id, 'edit'], {relativeTo: this.route, skipLocationChange: true})
    );
  }
  
  actionsFormError(error: any): void {
    toastr.error('Ocorreu um erro ao processsar a sua solicitação!');
    this.submittingForm = false;

    if (error.status === 422) {
      this.serverErrorMessages = JSON.parse(error._body).errors;
    }
    else {
      this.serverErrorMessages = ['Falha na comunicação com o servidor. Por favor, tente mais tarde'];
    }
  }

  private setPageTitle(): void {
    if (this.currentAction === 'new') {
      this.pageTitle = 'Cadastrar Nova Escola';
    } else {
      const schoolName = this.school.name || '';
      this.pageTitle = 'Editando Escolar: ' + this.school.name;
    }
  }

  private setCurrentAction(): void {
    if (this.route.snapshot.url[0].path === 'new') {
      this.currentAction = 'new';
    }
    else {
      this.currentAction = 'edit';
    }
  }

  private buildSchoolForm(): void {
    this.schoolForm = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.minLength(5)]],
      schoolPrincipal: [null, [Validators.required, Validators.minLength(3)]],
      maxSchoolClass: new FormControl(0),
      maxSchoolStudents: new FormControl(0)
    });
  }

  private loadSchool(): void {
     if (this.currentAction === 'edit') {
       this.route.paramMap.pipe(
         switchMap(params => this.schoolService.getById(params.get('id')))
       )
        .subscribe(
          (school) => {
            this.school = school;
            this.schoolForm.patchValue(school); // binds buildSchoolForm loaded school data form
          },
          (error) => alert('Ocorreu um erro no servidor, tenta mais tarde')
        );
     }
  }

}
