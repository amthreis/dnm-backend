using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTier.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientCode",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientCode",
                table: "Appointments");
        }
    }
}
