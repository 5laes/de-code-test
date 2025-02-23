using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnswersKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuizAnswers",
                table: "UserQuizAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserQuizAnswers_PlayerId",
                table: "UserQuizAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "UserQuizAnswers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserQuizAnswers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuizAnswers",
                table: "UserQuizAnswers",
                columns: new[] { "PlayerId", "QuestionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuizAnswers",
                table: "UserQuizAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserQuizAnswers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "UserQuizAnswers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuizAnswers",
                table: "UserQuizAnswers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizAnswers_PlayerId",
                table: "UserQuizAnswers",
                column: "PlayerId");
        }
    }
}
