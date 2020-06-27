using System;
using Flunt.Notifications;
using Flunt.Validations;
using Medgrupo.Siscolar.Domain.Commands.Contracts;

namespace Medgrupo.Siscolar.Domain.Commands
{
    public class UpdateSchoolClassCommand : Notifiable, ICommand
    {
        public UpdateSchoolClassCommand() { }

        public UpdateSchoolClassCommand(Guid id,string name, int schoolYear, string shift)
        {
            Id = id;
            Name = name;
            SchoolYear = schoolYear;
            Shift = shift;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SchoolYear { get; set; }
        public string Shift { get; set; }

        public void Validate()
        {
            DateTime dateTimeYear;

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Turma sem identificador!")
                    .HasMinLen(Name, 5, "Name", "Por favor, digite o nome da turma!")
                    .HasMinLen(Shift, 5, "Shift", "Por favor, digite o turno do dia da turma!")
                    .HasExactLengthIfNotNullOrEmpty(SchoolYear.ToString(), 4, "SchoolYear", "Por favor, digite o ano letivo da turma!")
                    .IsTrue(DateTime.TryParse(string.Format("1/1/{0}", SchoolYear), out dateTimeYear), "SchoolYear", "Por favor, digite um ano válido!")
            );
        }
    }
}