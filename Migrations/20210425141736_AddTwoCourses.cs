using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class AddTwoCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityCourse");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 2, "<h2>Test Header for php</h2><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", "PHP" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "ShortDescription" },
                values: new object[] { 5, 1, "<h2>Test Header for QA</h2><ul><li>Item1</li><li>Item2</li></ul><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", "Quality assurance", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "ShortDescription" },
                values: new object[] { 4, 2, "<h2>Test Header for go lang</h2><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", "Go Lang", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 1, "<h2>Test Header for QA</h2><ul><li>Item1</li><li>Item2</li></ul><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad ipsum culpa molestiae quo nemo aliquam enim! Dolor rem, sapiente nisi, totam dolore, atque architecto ad obcaecati molestiae impedit error nemo.</p>", "Quality assurance" });

            migrationBuilder.CreateIndex(
                name: "IX_CityCourse_CoursesId",
                table: "CityCourse",
                column: "CoursesId");
        }
    }
}
