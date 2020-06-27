using System;
using System.Collections.Generic;
using System.Linq;
using Medgrupo.Siscolar.Domain.Commands;
using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Domain.Handlers;
using Medgrupo.Siscolar.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Medgrupo.Siscolar.Api.Controllers
{
    [ApiController]
    [Route("v1/schoolclasses")]
    public class SchoolClassController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<SchoolClass> GetAll(
            [FromServices]ISchoolClassRepository repository
        )
        {
            return repository.GetAll();
        }


        [Route("{id}")]
        [HttpGet]
        public SchoolClass Get(
            [FromRoute]Guid id,
            [FromServices] ISchoolClassRepository repository)
        {
            return repository.GetById(id);
        }

        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateSchoolClassCommand command,
            [FromServices] SchoolClassHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        [HttpPut]
        public GenericCommandResult Update(
           [FromBody] UpdateSchoolClassCommand command,
           [FromServices] SchoolClassHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpDelete]
        public GenericCommandResult Delete(
           [FromBody] DeleteSchoolClassCommand command,
           [FromServices] SchoolClassHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }


    }
}