using System;
using System.Collections.Generic;
using Medgrupo.Siscolar.Domain.Entities;

namespace Medgrupo.Siscolar.Domain.Repositories
{
    public interface ISchoolClassRepository
    {
        void Create(SchoolClass schoolClass);
        void Update(SchoolClass schoolClass);
        SchoolClass GetById(Guid id);
        IEnumerable<SchoolClass> GetAll();
        void Delete(SchoolClass schoolClass);
    }
}