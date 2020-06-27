using System;
using System.Linq.Expressions;
using Medgrupo.Siscolar.Domain.Entities;

namespace Medgrupo.Siscolar.Domain.Queries
{
    public static class SchoolClassQueries
    {
        public static Expression<Func<SchoolClass, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

    }
}