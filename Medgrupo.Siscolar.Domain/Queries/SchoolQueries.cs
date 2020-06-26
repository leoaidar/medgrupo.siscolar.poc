using System;
using System.Linq.Expressions;
using Medgrupo.Siscolar.Domain.Entities;

namespace Medgrupo.Siscolar.Domain.Queries
{
    public static class SchoolQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll()
        {
            return x => x.Id != null;
        }

    }
}