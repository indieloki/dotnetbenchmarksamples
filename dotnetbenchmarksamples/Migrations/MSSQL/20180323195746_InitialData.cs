using dotnetbenchmarksamples.Infrastucture.Data;
using dotnetbenchmarksamples.Infrastucture.Model;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnetbenchmarksamples.Migrations.MSSQL
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var db = new MSSQLContextFactory().CreateDbContext(null))
            {

                DataSeeder<MSSQLContext>.SeedDataUP(db);
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var db = new MSSQLContextFactory().CreateDbContext(null))
            {

                DataSeeder<MSSQLContext>.SeedDataDown(db);
            }
        }
    }
}
