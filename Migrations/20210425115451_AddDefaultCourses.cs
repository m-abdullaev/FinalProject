using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class AddDefaultCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CityCourse",
                columns: table => new
                {
                    CitiesId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCourse", x => new { x.CitiesId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CityCourse_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityCourse_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "ShortDescription" },
                values: new object[] { 1, 3, "<h1>Test Header</h1><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", "Java script lvl 0", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim!" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "ShortDescription" },
                values: new object[] { 2, 2, "<h2>Test Header for c#</h2><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", "C#", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "ShortDescription" },
                values: new object[] { 3, 1, "<h2>Test Header for QA</h2><ul><li>Item1</li><li>Item2</li></ul><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", "Quality assurance", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." });

            migrationBuilder.InsertData(
                table: "CourseCities",
                columns: new[] { "CityId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityCourse_CoursesId",
                table: "CityCourse",
                column: "CoursesId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCities_Cities_CityId",
                table: "CourseCities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseCities_Courses_CourseId",
                table: "CourseCities");

            migrationBuilder.DropTable(
                name: "CityCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCities",
                table: "CourseCities");

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CourseCities",
                keyColumns: new[] { "CityId", "CourseId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
