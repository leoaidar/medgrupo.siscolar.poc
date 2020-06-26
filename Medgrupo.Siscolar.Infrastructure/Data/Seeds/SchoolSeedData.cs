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
                new School("Escola João de Barro",10,100, "Sr. Roggani"),
                new School("Escola Estadual Paulo Freire", 15, 150, "Sr. Afonso"),
                new School("Escola Federal Pedro Ernesto", 11, 110, "Sr. José Aldo")
            };
        }
    }
}
