using System;
using Flunt.Notifications;
using Flunt.Validations;
using Medgrupo.Siscolar.Domain.Commands.Contracts;

namespace Medgrupo.Siscolar.Domain.Commands
{
    public class CreateSchoolCommand : Notifiable, ICommand
    {
        public CreateSchoolCommand() { }

        public CreateSchoolCommand(string name, int maxSchoolClass, int maxSchoolStudents, string schoolPrincipal)
        {
            Name = name;
            MaxSchoolClass = maxSchoolClass;
            MaxSchoolStudents = maxSchoolStudents;
            SchoolPrincipal = schoolPrincipal;
        }

        public string Name { get; set; }
        public int MaxSchoolClass { get; set; }
        public int MaxSchoolStudents { get; set; }
        public string SchoolPrincipal { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 6, "Name", "Por favor, digite o nome da escola!")
                    .HasMinLen(SchoolPrincipal, 3, "SchoolPrincipal", "Por favor, digite o nome do diretor da escola!")
            );
        }
    }
}