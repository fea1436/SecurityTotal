using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BranchManagement.Infrastructure.EFCore.Migrations
{
    public partial class Branches_Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeadQ = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    OldCode = table.Column<int>(type: "int", nullable: false),
                    AuthorizationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelPreCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PostalCode = table.Column<long>(type: "bigint", nullable: false),
                    ActivationStatus = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
