using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnetbenchmarksamples.Migrations.Postgre
{
    public partial class AddGetFirtsProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp =
             @"CREATE FUNCTION public.""GetFirtsById""(index bigint) 
                 RETURNS SETOF ""SampleFirstTablePOCOs"" AS
                $BODY$
                BEGIN
                RETURN QUERY SELECT
                *
                FROM public.""SampleFirstTablePOCOs""
                WHERE public.""SampleFirstTablePOCOs"".""Id"" = index;
                RETURN;
                END;
                $BODY$
                LANGUAGE plpgsql VOLATILE
                COST 100;";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP FUNCTION public.""GetFirtsById""(""Id"" bigint)";
            migrationBuilder.Sql(sp);
        }
    }
}
