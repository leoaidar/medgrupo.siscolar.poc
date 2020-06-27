using System;
using System.Collections.Generic;

namespace Medgrupo.Siscolar.Domain.Entities
{
    public class School : Entity
    {
        public School(string name, int maxSchoolClass, int maxSchoolStudents, string schoolPrincipal)
        {
            Name = name;
            MaxSchoolClass = maxSchoolClass;
            MaxSchoolStudents = maxSchoolStudents;
            SchoolPrincipal = schoolPrincipal;
            CreateDate = LastUpdateDate = DateTime.Now;
        }

        public string Name { get; private set; }
        public int MaxSchoolClass { get; private set; }
        public int MaxSchoolStudents { get; private set; }
        public string SchoolPrincipal { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public IEnumerable<SchoolClass> SchoolClasses { get; private set; }


        public void UpdateName(string name)
        {
            if (Name.Equals(name)) return;

            Name = name;
            EntityModified();
        }

        public void ChangeSchoolPrincipal(string schoolPrincipal)
        {
            if (SchoolPrincipal.Equals(schoolPrincipal)) return;

            SchoolPrincipal = schoolPrincipal;
            EntityModified();
        }

        public void EntityModified()
        {
            LastUpdateDate = DateTime.Now;
        }

        public void SetMaximumSchoolClass(int maxSchoolClass)
        {
            if (MaxSchoolClass.Equals(maxSchoolClass)) return;

            MaxSchoolClass = maxSchoolClass;
            EntityModified();
        }

        public void SetMaximumSchoolStudents(int maxSchoolStudents)
        {
            if (MaxSchoolStudents.Equals(maxSchoolStudents)) return;

            MaxSchoolStudents = maxSchoolStudents;
            EntityModified();
        }
    }
}