import { InMemoryDbService } from 'angular-in-memory-web-api';
import { School } from './pages/schools/shared/school-model';

export class InMemoryDatabase implements InMemoryDbService {

 createDb() {
  const schools = School[0] = [
   { id: '6D1E0197-90AF-4985-A5FE-828F28CFB06D', name: 'Escola João', schoolPrincipal: 'Sr. Aidar', maxSchoolClass: 10, maxSchoolStudents: 150 },
   { id: '4985A5FE-90AF-4985-A5FE-828F28CFB06D', name: 'Escola Silva', schoolPrincipal: 'Sr. Léo', maxSchoolClass: 10, maxSchoolStudents: 100 },
   { id: '828F28CF-90AF-4985-A5FE-828F28CFB06D', name: 'Escola Maria', schoolPrincipal: 'Sr. Arthur', maxSchoolClass: 10, maxSchoolStudents: 200 }
  ];

  return { schools };

 }

}
