using System;
using System.Linq.Expressions;
using Medgrupo.Siscolar.Domain.Entities;

namespace Medgrupo.Siscolar.Domain.Queries
{
    public static class SchoolQueries
    {
        public static Expression<Func<School, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

    }
}