using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaQualquer.WebApi.Repository.Migrations
{
    public partial class CreateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "admin@lojaqualquer.com.br", "Administrador", "AQAAAAEAACcQAAAAEKfQncAI8gUDZY1Nf9lKu3+qeFRVkJgJMF3Ka3Ku/0eYJNOzkLgJmpRhQS/d71bV9Q==" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 2, "usuario@lojaqualquer.com.br", "Usuario", "AQAAAAEAACcQAAAAEHaDiz/ImdoZTlNaube3GYffTNAvsXtmZwmqLd6Xu5DV2qYnIm3UflL+Z9oSeMTnng==" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
