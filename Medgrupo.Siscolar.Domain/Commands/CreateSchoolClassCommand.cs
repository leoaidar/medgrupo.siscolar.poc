using System;
using Flunt.Notifications;
using Flunt.Validations;
using Medgrupo.Siscolar.Domain.Commands.Contracts;

namespace Medgrupo.Siscolar.Domain.Commands
{
    public class CreateSchoolClassCommand : Notifiable, ICommand
    {
        public CreateSchoolClassCommand() { }

        public CreateSchoolClassCommand(string name, int schoolYear, string shift, Guid schoolId)
        {
            Name = name;
            SchoolYear = schoolYear;
            Shift = shift;
            SchoolId = schoolId;
        }

        public string Name { get; set; }
        public int SchoolYear { get; set; }
        public string Shift { get; set; }
        public Guid SchoolId { get; private set; }


        public void Validate()
        {
            DateTime dateTimeYear;

            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 5, "Name", "Por favor, digite o nome da turma!")
                    .HasMinLen(Shift, 5, "Shift", "Por favor, digite o turno do dia da turma!")
                    .HasExactLengthIfNotNullOrEmpty(SchoolYear.ToString(), 4, "SchoolYear", "Por favor, digite o ano letivo da turma!")
                    .IsTrue(DateTime.TryParse(string.Format("1/1/{0}", SchoolYear), out dateTimeYear), "SchoolYear", "Por favor, digite um ano válido!")
                    .IsNotEmpty(SchoolId, "SchoolId", "Escolha desta turma sem identificador!")
            );            
        }
    }
}