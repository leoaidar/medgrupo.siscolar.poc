using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medgrupo.Siscolar.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 160, nullable: true),
                    MaxSchoolClass = table.Column<int>(nullable: false),
                    MaxSchoolStudents = table.Column<int>(nullable: false),
                    SchoolPrincipal = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("937fc52c-5667-4f14-a662-cd87ff6213cc"), new DateTime(2020, 6, 26, 21, 10, 3, 445, DateTimeKind.Local).AddTicks(1479), new DateTime(2020, 6, 26, 21, 10, 3, 445, DateTimeKind.Local).AddTicks(1479), 10, 100, "Escola João de Barro", "Sr. Roggani" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("b52600f7-cb8c-4d9f-ab32-b57a091cf5b9"), new DateTime(2020, 6, 26, 21, 10, 3, 453, DateTimeKind.Local).AddTicks(1532), new DateTime(2020, 6, 26, 21, 10, 3, 453, DateTimeKind.Local).AddTicks(1532), 15, 150, "Escola Estadual Paulo Freire", "Sr. Afonso" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("6d1e0197-90af-4985-a5fe-828f28cfb06d"), new DateTime(2020, 6, 26, 21, 10, 3, 453, DateTimeKind.Local).AddTicks(1609), new DateTime(2020, 6, 26, 21, 10, 3, 453, DateTimeKind.Local).AddTicks(1609), 11, 110, "Escola Federal Pedro Ernesto", "Sr. José Aldo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
