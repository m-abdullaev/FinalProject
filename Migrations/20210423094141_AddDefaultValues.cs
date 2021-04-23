using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class AddDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCities_Cities_CityId",
                table: "CourseCities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCities_Courses_CourseId",
                table: "CourseCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCities",
                table: "CourseCities");

            migrationBuilder.RenameTable(
                name: "CourseCities",
                newName: "CourseCity");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCities_CourseId",
                table: "CourseCity",
                newName: "IX_CourseCity_CourseId");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseCity",
                table: "CourseCity",
                columns: new[] { "CityId", "CourseId" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "QA" },
                    { 2, "Back-end" },
                    { 3, "Front-end" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dushanbe" },
                    { 2, "Khudjand" },
                    { 3, "Kulob" },
                    { 4, "Farkhor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CityId",
                table: "Courses",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCity_Cities_CityId",
                table: "CourseCity",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCity_Courses_CourseId",
                table: "CourseCity",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Cities_CityId",
                table: "Courses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCity_Cities_CityId",
                table: "CourseCity");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCity_Courses_CourseId",
                table: "CourseCity");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Cities_CityId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CityId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCity",
                table: "CourseCity");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "CourseCity",
                newName: "CourseCities");

            migrationBuilder.RenameIndex(
                name: "IX_CourseCity_CourseId",
                table: "CourseCities",
                newName: "IX_CourseCities_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseCities",
                table: "CourseCities",
                columns: new[] { "CityId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCities_Cities_CityId",
                table: "CourseCities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCities_Courses_CourseId",
                table: "CourseCities",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
