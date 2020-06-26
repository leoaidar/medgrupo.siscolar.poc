
using System;

namespace Medgrupo.Siscolar.Domain.Entities
{
    public class SchoolClass : Entity
    {
        public SchoolClass(string name, string user, DateTime date)
        {
            Name = name;
            Done = false;
            Date = date;
            User = user;
        }

        public string Name { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public int numberStudents { get; set; }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUndone()
        {
            Done = false;
        }

        public void UpdateTitle(string title)
        {
            Name = title;
        }
    }
}