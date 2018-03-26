using dotnetbenchmarksamples.Infrastucture.Data;
using dotnetbenchmarksamples.Infrastucture.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetbenchmarksamples.Migrations.Postgre
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var db = new PostgreContextFactory().CreateDbContext(null))
            {

                DataSeeder<PostgreContext>.SeedDataUP(db);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var db = new PostgreContextFactory().CreateDbContext(null))
            {

                DataSeeder<PostgreContext>.SeedDataDown(db);
            }
        }
    }
}
