using System;
using Flunt.Notifications;
using Flunt.Validations;
using Medgrupo.Siscolar.Domain.Commands.Contracts;

namespace Medgrupo.Siscolar.Domain.Commands
{
    public class DeleteSchoolClassCommand : Notifiable, ICommand
    {
        public DeleteSchoolClassCommand() { }

        public DeleteSchoolClassCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id,"Id","Turma sem identificador!")
            );
        }
    }
}