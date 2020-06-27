using Medgrupo.Siscolar.Domain.Entities;
using System.Collections.Generic;

namespace Medgrupo.Siscolar.Infra.Data.Seeds
{
    internal class SchoolClassSeedData
    {
        internal static List<SchoolClass> Seed()
        {
            return new List<SchoolClass>
            {
                new SchoolClass("Turma da 5ª Série",2020,"Matutino"),
                new SchoolClass("Turma da 7ª Série",2020,"Vespertino"),
                new SchoolClass("Turma da 8ª Série",2020,"Noturno"),
            };
        }
    }
}
