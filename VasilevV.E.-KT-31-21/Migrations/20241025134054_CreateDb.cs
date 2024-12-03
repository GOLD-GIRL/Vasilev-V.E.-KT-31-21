using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VasilevV.E._KT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_name = table.Column<string>(type: "nvarchar(200)", maxLength: 30, nullable: false),
                    с_discipline_isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    c_discipline_direction = table.Column<string>(type: "nvarchar(200)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_group_groupname = table.Column<string>(type: "nvarchar(200)", maxLength: 15, nullable: false),
                    с_group_groupcourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_group_discipline",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false),
                    discipline_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_discipline_group_discipline_id", x => new { x.group_id, x.discipline_id });
                    table.ForeignKey(
                        name: "FK_cd_group_discipline_cd_discipline_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cd_group_discipline_cd_group_group_id",
                        column: x => x.group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_firstname = table.Column<string>(type: "nvarchar(200)", maxLength: 100, nullable: false),
                    c_student_lastname = table.Column<string>(type: "nvarchar(200)", maxLength: 100, nullable: false),
                    c_student_middlename = table.Column<string>(type: "nvarchar(200)", maxLength: 100, nullable: false),
                    c_student_group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.c_student_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_discipline_direction",
                table: "cd_discipline",
                column: "c_discipline_direction");

            migrationBuilder.CreateIndex(
                name: "idx_cd_discipline_isdeleted",
                table: "cd_discipline",
                column: "с_discipline_isdeleted");

            migrationBuilder.CreateIndex(
                name: "IX_cd_group_discipline_discipline_id",
                table: "cd_group_discipline",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_student_c_student_group_id",
                table: "cd_student",
                column: "c_student_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_group_discipline");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
