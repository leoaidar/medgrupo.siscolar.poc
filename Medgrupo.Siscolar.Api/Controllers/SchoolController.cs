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
    [Route("v1/schools")]
    public class SchoolController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<School> GetAll(
            [FromServices]ISchoolRepository repository
        )
        {
            return repository.GetAll();
        }

        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]CreateSchoolCommand command,
            [FromServices]SchoolHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        
        [HttpPut]
        public GenericCommandResult Update(
           [FromBody] UpdateSchoolCommand command,
           [FromServices] SchoolHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpDelete]
        public GenericCommandResult Delete(
           [FromBody] DeleteSchoolCommand command,
           [FromServices] SchoolHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}