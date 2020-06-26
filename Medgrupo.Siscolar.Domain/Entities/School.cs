using System;

namespace Medgrupo.Siscolar.Domain.Entities
{
    public class School : Entity
    {
        public School(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int MaxSchoolClass { get; set; }
        public int MaxSchoolStudents { get; set; }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}