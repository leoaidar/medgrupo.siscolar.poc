import { Component, OnInit, AfterContentChecked } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { SchoolclassService } from '../shared/schoolclass.service';
import { SchoolClass } from '../shared/schoolclass.model';

import { switchMap } from 'rxjs/operators';

import toastr from 'toastr';

@Component({
  selector: 'app-schoolclass-form',
  templateUrl: './schoolclass-form.component.html',
  styleUrls: ['./schoolclass-form.component.less']
})
export class SchoolclassFormComponent implements OnInit, AfterContentChecked {

  currentAction: string;
  schoolclassForm: FormGroup;
  pageTitle: string;
  serverErrorMessages: string[] = null;
  submittingForm = false;
  schoolclass: SchoolClass = new SchoolClass();

  constructor(
    private schoolClassService: SchoolclassService,
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
    const school: SchoolClass = Object.assign(new SchoolClass(), this.schoolclassForm.value);

    this.schoolClassService.create(school).subscribe(
                          schoolclass => this.actionForSuccess(schoolclass),
                          error => this.actionsFormError(error)
                        );
  }

  updateSchool(): void {
    const schoolclass: SchoolClass = Object.assign(new SchoolClass(), this.schoolclassForm.value);

    this.schoolClassService.update(schoolclass).subscribe(
                          schoschoolclassol => this.actionForSuccess(schoolclass),
                          error => this.actionsFormError(error)
                        );
  }

  actionForSuccess(school: SchoolClass): void {
    toastr.success('Solicitaçao processada com sucesso!');
    // redirecting and reloading compoment
    this.router.navigateByUrl('schoolclasses', {skipLocationChange: true}).then(
      () => this.router.navigate(['schoolclasses', school.id, 'edit'], {relativeTo: this.route, skipLocationChange: true})
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
      this.pageTitle = this.creationPageTitle();
    }
    else{
      this.pageTitle = this.editionPageTitle();
    }
  }

  private creationPageTitle(): string{
    return 'Cadastrar Nova Turma';
  }

  private editionPageTitle(): string{
    const schoolName = this.schoolclass.name || '';
    this.pageTitle = 'Editando Turma: ' + schoolName;
    return this.pageTitle;
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
    this.schoolclassForm = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.minLength(5)]],
      shift: [null, [Validators.required, Validators.minLength(3)]],
      schoolYear: new FormControl(0),
      schoolClassCode: [null],
      schoolId: new FormControl(0)
    });
  }

  private loadSchool(): void {
     if (this.currentAction === 'edit') {
       this.route.paramMap.pipe(
         switchMap(params => this.schoolClassService.getById(params.get('id')))
       )
        .subscribe(
          (schoolclass) => {
            this.schoolclass = schoolclass;
            this.schoolclassForm.patchValue(schoolclass); // binds buildSchoolForm loaded school data form
          },
          (error) => alert('Ocorreu um erro no servidor, tenta mais tarde')
        );
     }
  }

}

