import { InMemoryDbService } from "angular-in-memory-web-api";

export class InMemoryDatabase implements InMemoryDbService {

 createDb(){
  const schools = [
   { id: '6D1E0197-90AF-4985-A5FE-828F28CFB06D', name: 'Escola João', schoolPrincipal: 'Sr. Aidar', maxSchoolClass: 10 },
   { id: '6D1E0197-90AF-4985-A5FE-828F28CFB06D', name: 'Escola João', schoolPrincipal: 'Sr. Aidar', maxSchoolClass: 10 },
   { id: '6D1E0197-90AF-4985-A5FE-828F28CFB06D', name: 'Escola João', schoolPrincipal: 'Sr. Aidar', maxSchoolClass: 10 }
  ];

  return { schools };

 }

}
