using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class AddCitiestoCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "CourseCities",
                columns: new[] { "CityId", "CourseId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 1, 5 },
                    { 2, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "CourseCities",
                columns: new[] { "CityId", "CourseId" },
                values: new object[] { 4, 1 });
        }
    }
}
