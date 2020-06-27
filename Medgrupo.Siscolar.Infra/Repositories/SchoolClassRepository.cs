using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Medgrupo.Siscolar.Infra.Contexts;
using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Domain.Repositories;
using Medgrupo.Siscolar.Domain.Queries;

namespace Medgrupo.Siscolar.Infra.Repositories
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        private SiscolarDbContext _ctx;

        public SchoolClassRepository(SiscolarDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(SchoolClass schoolClass)
        {
            _ctx.SchoolClasses.Add(schoolClass);
            _ctx.SaveChanges();
        } 

        public IEnumerable<SchoolClass> GetAll()
        {
            return _ctx
                    .SchoolClasses
                    .Include(x => x.School)
                    .AsNoTracking()
                    .ToList();
        }

        public SchoolClass GetById(Guid id)
        {
            return _ctx
                .SchoolClasses
                .Include(x => x.School)
                .FirstOrDefault(SchoolClassQueries.GetById(id));
        }

        public void Update(SchoolClass schoolClass)
        {
            _ctx.Entry(schoolClass).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(SchoolClass schoolClass)
        {
            _ctx.SchoolClasses.Remove(schoolClass);
            _ctx.SaveChanges();
        }

    }
}
