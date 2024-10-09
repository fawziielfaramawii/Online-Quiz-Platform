using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineQuiz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddstudentWithInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorStudent");

            migrationBuilder.CreateTable(
                name: "StudentInstructors",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInstructors", x => new { x.StudentId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_StudentInstructors_AspNetUsers_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInstructors_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInstructors_InstructorId",
                table: "StudentInstructors",
                column: "InstructorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentInstructors");

            migrationBuilder.CreateTable(
                name: "InstructorStudent",
                columns: table => new
                {
                    InstructorsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorStudent", x => new { x.InstructorsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_InstructorStudent_AspNetUsers_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstructorStudent_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorStudent_StudentsId",
                table: "InstructorStudent",
                column: "StudentsId");
        }
    }
}
