using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnetbenchmarksamples.Migrations.MSSQL
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleFirstTablePOCOs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleFirstTablePOCOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleSecondTablePOCOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SampleFirstTablePOCOId = table.Column<long>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleSecondTablePOCOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleSecondTablePOCOs_SampleFirstTablePOCOs_SampleFirstTablePOCOId",
                        column: x => x.SampleFirstTablePOCOId,
                        principalTable: "SampleFirstTablePOCOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleSecondTablePOCOs_SampleFirstTablePOCOId",
                table: "SampleSecondTablePOCOs",
                column: "SampleFirstTablePOCOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleSecondTablePOCOs");

            migrationBuilder.DropTable(
                name: "SampleFirstTablePOCOs");
        }
    }
}
