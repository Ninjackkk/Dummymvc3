using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dummymvc3.Migrations
{
    /// <inheritdoc />
    public partial class Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emp",
                table: "Emp");

            migrationBuilder.RenameTable(
                name: "Emp",
                newName: "emps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_emps",
                table: "emps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pcat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Pid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emps",
                table: "emps");

            migrationBuilder.RenameTable(
                name: "emps",
                newName: "Emp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emp",
                table: "Emp",
                column: "Id");
        }
    }
}
