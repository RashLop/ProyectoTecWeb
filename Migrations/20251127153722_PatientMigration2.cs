using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoTecWeb.Migrations
{
    /// <inheritdoc />
    public partial class PatientMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_histories_patients_PatientId1",
                table: "histories");

            migrationBuilder.DropIndex(
                name: "IX_histories_PatientId1",
                table: "histories");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "histories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PatientId1",
                table: "histories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_histories_PatientId1",
                table: "histories",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_histories_patients_PatientId1",
                table: "histories",
                column: "PatientId1",
                principalTable: "patients",
                principalColumn: "PatientId");
        }
    }
}
