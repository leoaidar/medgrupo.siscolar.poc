using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medgrupo.Siscolar.Infra.Migrations
{
    public partial class OneSchoolWithManySchoolClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "SchoolClass",
                keyColumn: "Id",
                keyValue: new Guid("2dcc54e4-9e55-4bdf-baf0-634f9ba70780"));

            migrationBuilder.DeleteData(
                table: "SchoolClass",
                keyColumn: "Id",
                keyValue: new Guid("8b30e1ac-d993-48f7-b8bf-77ca88c289b7"));

            migrationBuilder.DeleteData(
                table: "SchoolClass",
                keyColumn: "Id",
                keyValue: new Guid("d99ec33e-1745-482e-8344-1435fe83fced"));

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolId",
                table: "SchoolClass",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("950c9298-737f-4562-ae74-adf53ef099ec"), new DateTime(2020, 6, 27, 15, 15, 6, 541, DateTimeKind.Local).AddTicks(3214), new DateTime(2020, 6, 27, 15, 15, 6, 541, DateTimeKind.Local).AddTicks(3214), 10, 100, "Escola João de Barro", "Sr. Roggani" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("8b005216-1b99-43f0-af3d-e1a01fbe18e4"), new DateTime(2020, 6, 27, 15, 15, 6, 550, DateTimeKind.Local).AddTicks(6723), new DateTime(2020, 6, 27, 15, 15, 6, 550, DateTimeKind.Local).AddTicks(6723), 15, 150, "Escola Estadual Paulo Freire", "Sr. Afonso" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "MaxSchoolClass", "MaxSchoolStudents", "Name", "SchoolPrincipal" },
                values: new object[] { new Guid("8a013b0e-eaaa-4349-acbf-e067270cf87b"), new DateTime(2020, 6, 27, 15, 15, 6, 550, DateTimeKind.Local).AddTicks(6824), new DateTime(2020, 6, 27, 15, 15, 6, 550, DateTimeKind.Local).AddTicks(6824), 11, 110, "Escola Federal Pedro Ernesto", "Sr. José Aldo" });

            migrationBuilder.InsertData(
                table: "SchoolClass",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "Name", "SchoolClassCode", "SchoolId", "SchoolYear", "Shift" },
                values: new object[] { new Guid("4a7572b4-a4a5-4116-bd29-4b34fe6d6746"), new DateTime(2020, 6, 27, 15, 15, 6, 565, DateTimeKind.Local).AddTicks(1965), new DateTime(2020, 6, 27, 15, 15, 6, 565, DateTimeKind.Local).AddTicks(1965), "Turma da 5ª Série", "M20A4A5965", new Guid("950c9298-737f-4562-ae74-adf53ef099ec"), 2020, "Matutino" });

            migrationBuilder.InsertData(
                table: "SchoolClass",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "Name", "SchoolClassCode", "SchoolId", "SchoolYear", "Shift" },
                values: new object[] { new Guid("bc6f1f78-6e9b-4da3-8588-0c337fb3525a"), new DateTime(2020, 6, 27, 15, 15, 6, 567, DateTimeKind.Local).AddTicks(5883), new DateTime(2020, 6, 27, 15, 15, 6, 567, DateTimeKind.Local).AddTicks(5883), "Turma da 7ª Série", "V206E9B883", new Guid("8b005216-1b99-43f0-af3d-e1a01fbe18e4"), 2020, "Vespertino" });

            migrationBuilder.InsertData(
                table: "SchoolClass",
                columns: new[] { "Id", "CreateDate", "LastUpdateDate", "Name", "SchoolClassCode", "SchoolId", "SchoolYear", "Shift" },
                values: new object[] { new Guid("f3bb23a2-b65d-4ce7-ad72-d6d0db9710b5"), new DateTime(2020, 6, 27, 15, 15, 6, 567, DateTimeKind.Local).AddTicks(6187), new DateTime(2020, 6, 27, 15, 15, 6, 567, DateTimeKind.Local).AddTicks(6187), "Turma da 8ª Série", "N20B65D187", new Guid("8a013b0e-eaaa-4349-acbf-e067270cf87b"), 2020, "Noturno" });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClass_SchoolId",
                table: "SchoolClass",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClass_School_SchoolId",
                table: "SchoolClass",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClass_School_SchoolId",
                table: "SchoolClass");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClass_SchoolId",
                table: "SchoolClass");

            migrationBuilder.DeleteData(
                table: "SchoolClass",
                keyColumn: "Id",
                keyValue: new Guid("4a7572b4-a4a5-4116-bd29-4b34fe6d6746"));

            migrationBuilder.DeleteData(
                table: "SchoolClass",
                keyColumn: "Id",
                keyValue: new Guid("bc6f1f78-6e9b-4da3-8588-0c337fb3525a"));

            migrationBuilder.DeleteData(
                table: "SchoolClass",
                keyColumn: "Id",
                keyValue: new Guid("f3bb23a2-b65d-4ce7-ad72-d6d0db9710b5"));

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("8a013b0e-eaaa-4349-acbf-e067270cf87b"));

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("8b005216-1b99-43f0-af3d-e1a01fbe18e4"));

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: new Guid("950c9298-737f-4562-ae74-adf53ef099ec"));

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "SchoolClass");

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
    }
}
