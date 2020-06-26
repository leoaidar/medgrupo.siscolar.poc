using System;
using Flunt.Notifications;
using Flunt.Validations;
using Medgrupo.Siscolar.Domain.Commands.Contracts;

namespace Medgrupo.Siscolar.Domain.Commands
{
    public class CreateSchoolCommand : Notifiable, ICommand
    {
        public CreateSchoolCommand() { }

        public CreateSchoolCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "Por favor, digite o nome da escola!")
            );
        }
    }
}