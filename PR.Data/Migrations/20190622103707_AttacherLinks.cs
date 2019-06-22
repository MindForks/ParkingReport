using Microsoft.EntityFrameworkCore.Migrations;

namespace PR.Data.Migrations
{
    public partial class AttacherLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFile_Report_ReportId",
                table: "AttachedFile");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "AttachedFile",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFile_Report_ReportId",
                table: "AttachedFile",
                column: "ReportId",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachedFile_Report_ReportId",
                table: "AttachedFile");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "AttachedFile",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AttachedFile_Report_ReportId",
                table: "AttachedFile",
                column: "ReportId",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
