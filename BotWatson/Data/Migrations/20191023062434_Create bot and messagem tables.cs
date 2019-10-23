using Microsoft.EntityFrameworkCore.Migrations;

namespace BotWatson.Data.Migrations
{
    public partial class Createbotandmessagemtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bot",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messagem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConversationId = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<string>(nullable: false),
                    From = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messagem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bot");

            migrationBuilder.DropTable(
                name: "Messagem");
        }
    }
}
