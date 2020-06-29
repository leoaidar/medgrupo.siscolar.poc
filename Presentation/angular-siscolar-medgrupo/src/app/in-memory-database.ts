import { InMemoryDbService } from 'angular-in-memory-web-api';

import { School } from './pages/schools/shared/school-model';
import { SchoolClass } from './pages/schoolclasses/shared/schoolclass.model';

export class InMemoryDatabase implements InMemoryDbService {  

 createDb() {
  const schools = School[0] = [
   { id: '6D1E0197-90AF-4985-A5FE-828F28CFB06D', name: 'Escola João', schoolPrincipal: 'Sr. Aidar', maxSchoolClass: 10, maxSchoolStudents: 150 },
   { id: '4985A5FE-90AF-4985-A5FE-828F28CFB06D', name: 'Escola Silva', schoolPrincipal: 'Sr. Léo', maxSchoolClass: 10, maxSchoolStudents: 100 },
   { id: '828F28CF-90AF-4985-A5FE-828F28CFB06D', name: 'Escola Maria', schoolPrincipal: 'Sr. Arthur', maxSchoolClass: 10, maxSchoolStudents: 200 }
  ];

  const schoolclasses = SchoolClass[0] = [
    { id: 'BC6F1F78-6E9B-4DA3-8588-0C337FB3525A', name: 'Turma da 7ª Série', shift: 'Vespertino', schoolYear: 1970, schoolClassCode: 'V206E9B883', schoolId: '8B005216-1B99-43F0-AF3D-E1A01FBE18E4'  },
    { id: '4A7572B4-A4A5-4116-BD29-4B34FE6D6746', name: 'Turma da 5ª Série', shift: 'Matutino', schoolYear: 2020, schoolClassCode: 'M20A4A5965', schoolId: '950C9298-737F-4562-AE74-ADF53EF099EC' },
    { id: '25C7DB59-45D5-4997-AE7C-A7EC12DEE034', name: 'Turma do Didi', shift: 'Noturno', schoolYear: 2019,  schoolClassCode: 'V7045D5927', schoolId: '8B005216-1B99-43F0-AF3D-E1A01FBE18E4' }
   ];

   return { schools, schoolclasses };

 }

}
