using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRegistration.API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CustomerBase");

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "CustomerBase",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "CustomerBase",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address_type = table.Column<byte>(type: "tinyint", nullable: false),
                    localization = table.Column<string>(type: "varchar(100)", nullable: false),
                    district = table.Column<string>(type: "varchar(70)", nullable: false),
                    city = table.Column<string>(type: "varchar(70)", nullable: false),
                    state = table.Column<string>(type: "varchar(50)", nullable: false),
                    number = table.Column<string>(type: "varchar(15)", nullable: false),
                    zip_code = table.Column<string>(type: "varchar(20)", nullable: false),
                    complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    country = table.Column<string>(type: "varchar(70)", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_Client_client_id",
                        column: x => x.client_id,
                        principalSchema: "CustomerBase",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                schema: "CustomerBase",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email_type = table.Column<byte>(type: "tinyint", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmailAddress_Client_client_id",
                        column: x => x.client_id,
                        principalSchema: "CustomerBase",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telephone",
                schema: "CustomerBase",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telephone_type = table.Column<byte>(type: "tinyint", nullable: false),
                    ddi = table.Column<string>(type: "varchar(6)", nullable: false),
                    ddd = table.Column<string>(type: "varchar(3)", nullable: true),
                    phone_number = table.Column<string>(type: "varchar(11)", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.id);
                    table.ForeignKey(
                        name: "FK_Telephone_Client_client_id",
                        column: x => x.client_id,
                        principalSchema: "CustomerBase",
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_client_id",
                schema: "CustomerBase",
                table: "Address",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_client_id",
                schema: "CustomerBase",
                table: "EmailAddress",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Telephone_client_id",
                schema: "CustomerBase",
                table: "Telephone",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address",
                schema: "CustomerBase");

            migrationBuilder.DropTable(
                name: "EmailAddress",
                schema: "CustomerBase");

            migrationBuilder.DropTable(
                name: "Telephone",
                schema: "CustomerBase");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "CustomerBase");
        }
    }
}
