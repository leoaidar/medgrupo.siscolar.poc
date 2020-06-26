using Flunt.Notifications;
using Medgrupo.Siscolar.Domain.Commands;
using Medgrupo.Siscolar.Domain.Commands.Contracts;
using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Domain.Handlers.Contracts;
using Medgrupo.Siscolar.Domain.Repositories;

namespace Medgrupo.Siscolar.Domain.Handlers
{
    public class SchoolHandler :
        Notifiable,
        IHandler<CreateSchoolCommand>
    {
        private readonly ISchoolRepository _repository;

        public SchoolHandler(ISchoolRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateSchoolCommand command)
        {           
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que os dados da escola estão errados!", command.Notifications);
                        
            var school = new School(command.Name);

            // Salva no banco
            _repository.Create(school);

            // Retorna o resultado
            return new GenericCommandResult(true, "Escola salva", school);
        }

    }
}