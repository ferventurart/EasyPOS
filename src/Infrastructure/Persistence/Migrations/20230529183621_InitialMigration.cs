using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Address_Line1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address_Line2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
