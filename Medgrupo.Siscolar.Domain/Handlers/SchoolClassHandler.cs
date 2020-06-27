using Flunt.Notifications;
using Medgrupo.Siscolar.Domain.Commands;
using Medgrupo.Siscolar.Domain.Commands.Contracts;
using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Domain.Handlers.Contracts;
using Medgrupo.Siscolar.Domain.Repositories;

namespace Medgrupo.Siscolar.Domain.Handlers
{
    public class SchoolClassHandler :
        Notifiable,
        IHandler<CreateSchoolClassCommand>
    {
        private readonly ISchoolClassRepository _repository;
        private readonly string _genericErrorText;
        private readonly string _genericSuccessText;

        public SchoolClassHandler(ISchoolClassRepository repository)
        {
            _repository = repository;
            _genericErrorText = "Ops, parece que os dados da escola turma errados!";
            _genericSuccessText = "Turma salva com sucesso!";
        }

        public ICommandResult Handle(CreateSchoolClassCommand command)
        {           
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, _genericErrorText, command.Notifications);

            var schoolClass = new SchoolClass(command.Name, command.SchoolYear, command.Shift, command.SchoolId);

            // Salva no banco
            _repository.Create(schoolClass);

            // Retorna o resultado
            return new GenericCommandResult(true, _genericSuccessText, schoolClass);
        }

        public ICommandResult Handle(UpdateSchoolClassCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, _genericErrorText, command.Notifications);

            // Recupera 
            var schoolClass = _repository.GetById(command.Id);

            // modificacoes
            schoolClass.UpdateName(command.Name);
            schoolClass.ChangeSchoolYear(command.SchoolYear);
            schoolClass.ChangeShift(command.Shift);

            // salva no banco
            _repository.Update(schoolClass);

            // Retorna o resultado
            return new GenericCommandResult(true, _genericSuccessText, schoolClass);
        }

        public ICommandResult Handle(DeleteSchoolClassCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, _genericErrorText, command.Notifications);

            // Recupera 
            var school = _repository.GetById(command.Id);
            
            // apaga no banco
            _repository.Delete(school);

            // Retorna o resultado
            return new GenericCommandResult(true, "Escola apagada com sucesso!", school);
        }



    }
}