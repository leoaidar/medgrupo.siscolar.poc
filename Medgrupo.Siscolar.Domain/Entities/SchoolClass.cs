using System;

namespace Medgrupo.Siscolar.Domain.Entities
{
    public class SchoolClass : Entity
    {
        public SchoolClass(string name, int schoolYear, string shift)
        {
            Name = name;
            SchoolYear = schoolYear;
            Shift = shift;
            CreateDate = LastUpdateDate = DateTime.Now;
            GenerateSchoolClassCode();
        }

        public string Name { get; private set; }
        public int SchoolYear { get; private set; }
        public string Shift { get; private set; }
        public string SchoolClassCode { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }


        public void UpdateName(string name)
        {
            if (Name.Equals(name)) return;

            Name = name;
            EntityModified();
        }

        public void ChangeShift(string shift)
        {
            if (Shift.Equals(shift)) return;

            Shift = shift;
            EntityModified();
        }

        public void EntityModified()
        {
            LastUpdateDate = DateTime.Now;
        }

        public void SetMaximumSchoolClass(int schoolYear)
        {
            if (SchoolYear.Equals(schoolYear)) return;

            SchoolYear = schoolYear;
            EntityModified();
        }

        private void GenerateSchoolClassCode()
        {
            string secondDataGuid = Id.ToString().Split('-')[1];
            string firstLetterShift = Shift.Substring(0, 1);
            string shortYear = SchoolYear.ToString().Substring(2, 2);
            string lastFourMilisecondsCreation = CreateDate.Millisecond.ToString().Substring(3, 4);

            string automaticSystemCode = secondDataGuid + firstLetterShift + shortYear + lastFourMilisecondsCreation;

            SchoolClassCode = automaticSystemCode;
        }
    }
}