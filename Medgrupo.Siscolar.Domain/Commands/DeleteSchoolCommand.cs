using System;
using Flunt.Notifications;
using Flunt.Validations;
using Medgrupo.Siscolar.Domain.Commands.Contracts;

namespace Medgrupo.Siscolar.Domain.Commands
{
    public class DeleteSchoolCommand : Notifiable, ICommand
    {
        public DeleteSchoolCommand() { }

        public DeleteSchoolCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id,"Id","Escola sem identificador!")
            );
        }
    }
}