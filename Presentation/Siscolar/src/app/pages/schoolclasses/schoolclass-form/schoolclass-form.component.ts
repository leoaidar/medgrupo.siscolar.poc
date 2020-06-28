import { Component, OnInit, AfterContentChecked } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { SchoolClass } from '../shared/schoolclass-model';
import { SchoolClassService } from '../shared/schoolclass.service';

import { switchMap } from 'rxjs/operators';
import toastr from 'toastr';

@Component({
  selector: 'app-schoolclass-form',
  templateUrl: './schoolclass-form.component.html',
  styleUrls: ['./schoolclass-form.component.less']
})
export class SchoolclassFormComponent implements OnInit, AfterContentChecked {
  currentAction: string;
  schoolClassForm: FormGroup;
  pageTitle: string;
  serverErrorMessages: string[] = null;
  submittingForm = false;
  schoolClass: SchoolClass = new SchoolClass();

  constructor(
    private schoolClassService: SchoolClassService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.setCurrentAction();
    this.buildSchoolClassForm();
    this.loadSchoolClass();
  }

  ngAfterContentChecked(): void {
    this.setPageTitle();
  }

  submitForm(): void {
    this.submittingForm = true;

    if (this.currentAction === 'new') {
      this.createSchoolClass();
    } else {
      this.updateSchoolClass();
    }
  }

  createSchoolClass(): void {
    const schoolClass: SchoolClass = Object.assign(new SchoolClass(), this.schoolClassForm.value);

    this.schoolClassService.create(schoolClass).subscribe(
                          schoolClass => this.actionForSuccess(schoolClass),
                          error => this.actionsFormError(error)
                        );
  }

  updateSchoolClass(): void {
    const schoolClass: SchoolClass = Object.assign(new SchoolClass(), this.schoolClassForm.value);

    this.schoolClassService.update(schoolClass).subscribe(
                          schoolClass => this.actionForSuccess(schoolClass),
                          error => this.actionsFormError(error)
                        );
  }

  actionForSuccess(schoolClass: SchoolClass): void {
    toastr.success('Solicitaçao processada com sucesso!');
    // redirecting and reloading compoment
    this.router.navigateByUrl('schoolclasses', {skipLocationChange: true}).then(
      // () => this.router.navigate(['schoolClass'], schoolClass.id, 'edit')
      () => this.router.navigate(['schoolclasses', schoolClass.id, 'edit'], {relativeTo: this.route, skipLocationChange: true})
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
      this.pageTitle = 'Cadastrar Nova Turma';
    } else {
      const schoolClassName = this.schoolClass.name || '';
      this.pageTitle = 'Editando Turma: ' + this.schoolClass.name;
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

  private buildSchoolClassForm(): void {
    this.schoolClassForm = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.minLength(5)]],
      shift: [null, [Validators.required, Validators.minLength(6)]],
      schoolYear: [null, [Validators.required, Validators.maxLength(4)]],
      schoolClassCode: new FormControl(null),
      schoolId: [null, [Validators.required]]
    });
  }

  private loadSchoolClass(): void {
     if (this.currentAction === 'edit') {
       this.route.paramMap.pipe(
         switchMap(params => this.schoolClassService.getById(params.get('id')))
       )
        .subscribe(
          (schoolClass) => {
            this.schoolClass = schoolClass;
            this.schoolClassForm.patchValue(schoolClass); // binds buildSchoolClassForm loaded schoolClass data form
          },
          (error) => alert('Ocorreu um erro no servidor, tenta mais tarde')
        );
     }
  }

}
