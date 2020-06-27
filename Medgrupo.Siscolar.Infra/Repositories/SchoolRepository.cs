﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Medgrupo.Siscolar.Infra.Contexts;
using Medgrupo.Siscolar.Domain.Entities;
using Medgrupo.Siscolar.Domain.Repositories;


namespace Medgrupo.Siscolar.Infra.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private SiscolarDbContext _ctx;

        public SchoolRepository(SiscolarDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(School school)
        {
            _ctx.Schools.Add(school);
            _ctx.SaveChanges();
        } 

        public IEnumerable<School> GetAll()
        {
            return _ctx.Schools;
        }

     

        public School GetById(Guid id)
        {
            return _ctx
                .Schools
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(School school)
        {
            _ctx.Entry(school).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

    }
}