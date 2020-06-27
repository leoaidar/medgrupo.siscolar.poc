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

            var school = new School(command.Name, command.MaxSchoolClass, command.MaxSchoolStudents, command.SchoolPrincipal);

            // Salva no banco
            _repository.Create(school);

            // Retorna o resultado
            return new GenericCommandResult(true, "Escola salva com sucesso!", school);
        }

        public ICommandResult Handle(UpdateSchoolCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que os dados da escola estão errados!", command.Notifications);

            // Recupera 
            var school = _repository.GetById(command.Id);

            // modificacoes
            school.UpdateName(command.Name);
            school.ChangeSchoolPrincipal(command.SchoolPrincipal);
            school.SetMaximumSchoolClass(command.MaxSchoolClass);
            school.SetMaximumSchoolStudents(command.MaxSchoolStudents);

            // salva no banco
            _repository.Update(school);

            // Retorna o resultado
            return new GenericCommandResult(true, "Escola salva com sucesso!", school);
        }

        public ICommandResult Handle(DeleteSchoolCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que os dados da escola estão errados!", command.Notifications);

            // Recupera 
            var school = _repository.GetById(command.Id);
            
            // apaga no banco
            _repository.Delete(school);

            // Retorna o resultado
            return new GenericCommandResult(true, "Escola apagada com sucesso!", school);
        }



    }
}