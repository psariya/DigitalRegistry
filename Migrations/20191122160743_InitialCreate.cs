using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRegistry.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Social_Media",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    organization = table.Column<string>(nullable: true),
                    account = table.Column<string>(nullable: true),
                    service_key = table.Column<string>(nullable: true),
                    short_description = table.Column<string>(nullable: true),
                    long_description = table.Column<string>(nullable: true),
                    service_display_name = table.Column<string>(nullable: true),
                    service_url = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(nullable: true),
                    updated_at = table.Column<string>(nullable: true),
                    All_Social_Mediapage = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social_Media", x => x.id);
                    table.ForeignKey(
                        name: "FK_Social_Media_AllSocialMedia_All_Social_Mediapage",
                        column: x => x.All_Social_Mediapage,
                        principalTable: "AllSocialMedia",
                        principalColumn: "page",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    agencies_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    info_url = table.Column<string>(nullable: true),
                    Social_Mediaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.agencies_id);
                    table.ForeignKey(
                        name: "FK_Agencies_Social_Media_Social_Mediaid",
                        column: x => x.Social_Mediaid,
                        principalTable: "Social_Media",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    tags_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tag_text = table.Column<string>(nullable: true),
                    Social_Mediaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.tags_id);
                    table.ForeignKey(
                        name: "FK_Tags_Social_Media_Social_Mediaid",
                        column: x => x.Social_Mediaid,
                        principalTable: "Social_Media",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_Social_Mediaid",
                table: "Agencies",
                column: "Social_Mediaid");

            migrationBuilder.CreateIndex(
                name: "IX_Social_Media_All_Social_Mediapage",
                table: "Social_Media",
                column: "All_Social_Mediapage");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Social_Mediaid",
                table: "Tags",
                column: "Social_Mediaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Social_Media");

            migrationBuilder.DropTable(
                name: "AllSocialMedia");
        }
    }
}
