import { School } from '../../schools/shared/school-model';

export class SchoolClass{
    constructor(
        public id?: string,
        public name?: string,
        public shift?: string,
        public schoolYear?: number,
        public schoolClassCode?: string,
        public schoolId?: string,
        public school?: School
    ){}

    static shifts = {
        morning: 'Matutino',
        evening: 'Vespertino',
        night: 'Noturno',
        daytime: 'Diurno'
    };
}