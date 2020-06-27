using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medgrupo.Siscolar.Infra.Migrations
{
    public partial class SchoolClassEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("3f06b3ee-a31f-4d8d-b353-518f508b56d2"));

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("740289ad-4241-4415-b8d8-2e36438e7fb4"));

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("f9906e88-eb7e-4a6f-aef7-9aff628f7d30"));

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 160, nullable: true),
                    SchoolYear = table.Column<int>(maxLength: 4, nullable: false),
                    Shift = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SchoolClassCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[,]
                {
                    { new Guid("82d921ac-7a07-4e46-9101-6bd2ccb2088e"), new DateTime(2020, 6, 27, 3, 28, 7, 159, DateTimeKind.Local).AddTicks(4267), new DateTime(2020, 6, 27, 3, 28, 7, 159, DateTimeKind.Local).AddTicks(4267), 10, 100, "Escola João de Barro", "Sr. Roggani" },
                    { new Guid("d8a61f26-98eb-47ab-98d4-c16246159718"), new DateTime(2020, 6, 27, 3, 28, 7, 169, DateTimeKind.Local).AddTicks(8581), new DateTime(2020, 6, 27, 3, 28, 7, 169, DateTimeKind.Local).AddTicks(8581), 15, 150, "Escola Estadual Paulo Freire", "Sr. Afonso" },
                    { new Guid("6e6056c0-fbc6-4201-96fb-2cc29c47f478"), new DateTime(2020, 6, 27, 3, 28, 7, 169, DateTimeKind.Local).AddTicks(8680), new DateTime(2020, 6, 27, 3, 28, 7, 169, DateTimeKind.Local).AddTicks(8680), 11, 110, "Escola Federal Pedro Ernesto", "Sr. José Aldo" }
                });

            migrationBuilder.InsertData(
                table: "SchoolClass",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "Name", "SchoolClassCode", "SchoolYear", "Shift" },
                values: new object[,]
                {
                    { new Guid("8b30e1ac-d993-48f7-b8bf-77ca88c289b7"), new DateTime(2020, 6, 27, 3, 28, 7, 176, DateTimeKind.Local).AddTicks(5402), new DateTime(2020, 6, 27, 3, 28, 7, 176, DateTimeKind.Local).AddTicks(5402), "Turma da 5ª Série", "d993M205402", 2020, "Matutino" },
                    { new Guid("d99ec33e-1745-482e-8344-1435fe83fced"), new DateTime(2020, 6, 27, 3, 28, 7, 178, DateTimeKind.Local).AddTicks(2093), new DateTime(2020, 6, 27, 3, 28, 7, 178, DateTimeKind.Local).AddTicks(2093), "Turma da 7ª Série", "1745V202093", 2020, "Vespertino" },
                    { new Guid("2dcc54e4-9e55-4bdf-baf0-634f9ba70780"), new DateTime(2020, 6, 27, 3, 28, 7, 178, DateTimeKind.Local).AddTicks(2304), new DateTime(2020, 6, 27, 3, 28, 7, 178, DateTimeKind.Local).AddTicks(2304), "Turma da 8ª Série", "9e55N202304", 2020, "Noturno" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("6e6056c0-fbc6-4201-96fb-2cc29c47f478"));

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("82d921ac-7a07-4e46-9101-6bd2ccb2088e"));

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("d8a61f26-98eb-47ab-98d4-c16246159718"));

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("3f06b3ee-a31f-4d8d-b353-518f508b56d2"), new DateTime(2020, 6, 27, 3, 8, 35, 939, DateTimeKind.Local).AddTicks(775), new DateTime(2020, 6, 27, 3, 8, 35, 939, DateTimeKind.Local).AddTicks(775), 10, 100, "Escola João de Barro", "Sr. Roggani" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("740289ad-4241-4415-b8d8-2e36438e7fb4"), new DateTime(2020, 6, 27, 3, 8, 35, 948, DateTimeKind.Local).AddTicks(7447), new DateTime(2020, 6, 27, 3, 8, 35, 948, DateTimeKind.Local).AddTicks(7447), 15, 150, "Escola Estadual Paulo Freire", "Sr. Afonso" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("f9906e88-eb7e-4a6f-aef7-9aff628f7d30"), new DateTime(2020, 6, 27, 3, 8, 35, 948, DateTimeKind.Local).AddTicks(7541), new DateTime(2020, 6, 27, 3, 8, 35, 948, DateTimeKind.Local).AddTicks(7541), 11, 110, "Escola Federal Pedro Ernesto", "Sr. José Aldo" });
        }
    }
}
