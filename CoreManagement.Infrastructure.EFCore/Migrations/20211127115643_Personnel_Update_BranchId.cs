using Microsoft.EntityFrameworkCore.Migrations;

namespace BranchManagement.Infrastructure.EFCore.Migrations
{
    public partial class Personnel_Update_BranchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Personnel",
                newName: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_BranchId",
                table: "Personnel",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_Branches_BranchId",
                table: "Personnel",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_Branches_BranchId",
                table: "Personnel");

            migrationBuilder.DropIndex(
                name: "IX_Personnel_BranchId",
                table: "Personnel");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Personnel",
                newName: "Branch");
        }
    }
}
