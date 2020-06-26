using System;
using System.Collections.Generic;
using Medgrupo.Siscolar.Domain.Entities;

namespace Medgrupo.Siscolar.Domain.Repositories
{
    public interface ISchoolRepository
    {
        void Create(School school);
        void Update(School school);
        TodoItem GetById(Guid id);
        IEnumerable<School> GetAll();

    }
}