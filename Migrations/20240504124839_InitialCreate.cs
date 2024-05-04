using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restify.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landlord",
                columns: table => new
                {
                    landlord_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    landlord_firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    landlord_lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    landlord_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    landlord_contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    landlord_password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlord", x => x.landlord_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Landlord");
        }
    }
}
