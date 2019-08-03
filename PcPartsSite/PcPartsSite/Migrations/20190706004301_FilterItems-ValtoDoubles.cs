using Microsoft.EntityFrameworkCore.Migrations;

namespace PcPartsSite.Migrations
{
    public partial class FilterItemsValtoDoubles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinValue",
                table: "FilterItems",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "FilterItems",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinValue",
                table: "FilterItems",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxValue",
                table: "FilterItems",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
