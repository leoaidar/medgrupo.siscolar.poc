using Medgrupo.Siscolar.Domain.Entities;
using System.Collections.Generic;

namespace Medgrupo.Siscolar.Infrastructure.Data.Seeds
{
    internal class SchoolSeedData
    {
        internal static List<School> Seed()
        {
            return new List<School>
            {
                new School("Escola João de Barro"),
                new School("Escola Estadual Paulo Freire"),
                new School("Escola Federal Pedro Ernesto")
            };
        }
    }
}
