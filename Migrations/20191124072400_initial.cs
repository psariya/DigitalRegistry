using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRegistry.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "All_Social_Media",
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
                    table.PrimaryKey("PK_All_Social_Media", x => x.page);
                });

            migrationBuilder.CreateTable(
                name: "Social_Media",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Organization = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Service_key = table.Column<string>(nullable: true),
                    Short_description = table.Column<string>(nullable: true),
                    Long_description = table.Column<string>(nullable: true),
                    Service_display_name = table.Column<string>(nullable: true),
                    Service_url = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Created_at = table.Column<string>(nullable: true),
                    Updated_at = table.Column<string>(nullable: true),
                    All_Social_Mediapage = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Social_Media_All_Social_Media_All_Social_Mediapage",
                        column: x => x.All_Social_Mediapage,
                        principalTable: "All_Social_Media",
                        principalColumn: "page",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    a_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Info_url = table.Column<string>(nullable: true),
                    Social_MediaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.a_id);
                    table.ForeignKey(
                        name: "FK_Agencies_Social_Media_Social_MediaId",
                        column: x => x.Social_MediaId,
                        principalTable: "Social_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    t_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tag_text = table.Column<string>(nullable: true),
                    Social_MediaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.t_id);
                    table.ForeignKey(
                        name: "FK_Tags_Social_Media_Social_MediaId",
                        column: x => x.Social_MediaId,
                        principalTable: "Social_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_Social_MediaId",
                table: "Agencies",
                column: "Social_MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Social_Media_All_Social_Mediapage",
                table: "Social_Media",
                column: "All_Social_Mediapage");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Social_MediaId",
                table: "Tags",
                column: "Social_MediaId");
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
                name: "All_Social_Media");
        }
    }
}
