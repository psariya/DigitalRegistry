using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRegistry.Migrations
{
    public partial class InitialCreate_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Social_Media_socialMedia_All_Social_Mediapage",
                table: "Social_Media");

            migrationBuilder.DropTable(
                name: "socialMedia");

            migrationBuilder.CreateTable(
                name: "AllSocialMedia",
                columns: table => new
                {
                    page = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    count_ = table.Column<int>(nullable: false),
                    page_size = table.Column<int>(nullable: false),
                    pages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllSocialMedia", x => x.page);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Social_Media_AllSocialMedia_All_Social_Mediapage",
                table: "Social_Media",
                column: "All_Social_Mediapage",
                principalTable: "AllSocialMedia",
                principalColumn: "page",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Social_Media_AllSocialMedia_All_Social_Mediapage",
                table: "Social_Media");

            migrationBuilder.DropTable(
                name: "AllSocialMedia");

            migrationBuilder.CreateTable(
                name: "socialMedia",
                columns: table => new
                {
                    page = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    count_ = table.Column<int>(nullable: false),
                    page_size = table.Column<int>(nullable: false),
                    pages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialMedia", x => x.page);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Social_Media_socialMedia_All_Social_Mediapage",
                table: "Social_Media",
                column: "All_Social_Mediapage",
                principalTable: "socialMedia",
                principalColumn: "page",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
