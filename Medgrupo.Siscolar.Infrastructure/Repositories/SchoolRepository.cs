using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Medgrupo.Siscolar.Infrastructure.Contexts;
using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Domain.Repositories;

namespace Medgrupo.Siscolar.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SiscolarDbContext _context;

        public SchoolRepository(SiscolarDbContext context)
        {
            _context = context;
        }

        public void Create(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
        }

        public IEnumerable<School> GetAll()
        {
            return _context.Schools
               .AsNoTracking();
        }        

        public School GetById(Guid id)
        {
            return _context
                .Schools
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(School school)
        {
            _context.Entry(school).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}