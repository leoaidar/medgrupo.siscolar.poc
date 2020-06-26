using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medgrupo.Siscolar.Api.Migrations
{
    public partial class InitialCreate : Migration
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
                    MaxSchoolStudents = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "MaxSchoolClass", "MaxSchoolStudents", "Name" },
                values: new object[] { new Guid("8d4f653f-adfd-4b89-9811-20def628c407"), 0, 0, "Escola João de Barro" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "MaxSchoolClass", "MaxSchoolStudents", "Name" },
                values: new object[] { new Guid("c936f200-39db-4411-944b-03ff307933db"), 0, 0, "Escola Estadual Paulo Freire" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "MaxSchoolClass", "MaxSchoolStudents", "Name" },
                values: new object[] { new Guid("e14a3b32-2919-45b7-8df1-8fe4caa64104"), 0, 0, "Escola Federal Pedro Ernesto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
