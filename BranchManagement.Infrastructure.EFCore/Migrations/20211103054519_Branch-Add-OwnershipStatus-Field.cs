using Microsoft.EntityFrameworkCore.Migrations;

namespace BranchManagement.Infrastructure.EFCore.Migrations
{
    public partial class BranchAddOwnershipStatusField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OwnershipStatus",
                table: "Branches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnershipStatus",
                table: "Branches");
        }
    }
}
