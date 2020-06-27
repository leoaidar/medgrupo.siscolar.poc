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
                new SchoolClass("Turma da 5ª Série",2020,"Matutino", new System.Guid()),
                new SchoolClass("Turma da 7ª Série",2020,"Vespertino", new System.Guid()),
                new SchoolClass("Turma da 8ª Série",2020,"Noturno", new System.Guid()),
            };
        }

        internal static List<SchoolClass> Seed(List<School> schoolsSeed)
        {
            return new List<SchoolClass>
            {
                new SchoolClass("Turma da 5ª Série",2020,"Matutino", schoolsSeed[0].Id),
                new SchoolClass("Turma da 7ª Série",2020,"Vespertino", schoolsSeed[1].Id),
                new SchoolClass("Turma da 8ª Série",2020,"Noturno", schoolsSeed[2].Id)
            };
        }
    }
}
