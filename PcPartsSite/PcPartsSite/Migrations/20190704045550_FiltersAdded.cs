using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcPartsSite.Migrations
{
    public partial class FiltersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CatName = table.Column<string>(maxLength: 25, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Filters",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(maxLength: 25, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Filters", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SubCategories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        SubCatName = table.Column<string>(maxLength: 25, nullable: false),
            //        CategoryId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubCategories", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_SubCategories_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "FilterItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FilterId = table.Column<int>(nullable: false),
            //        Display = table.Column<string>(nullable: false),
            //        Value = table.Column<string>(nullable: true),
            //        MinValue = table.Column<int>(nullable: true),
            //        MaxValue = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FilterItems", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_FilterItems_Filters_FilterId",
            //            column: x => x.FilterId,
            //            principalTable: "Filters",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(maxLength: 100, nullable: false),
            //        Description = table.Column<string>(maxLength: 280, nullable: true),
            //        Image = table.Column<byte[]>(nullable: true),
            //        Price = table.Column<decimal>(nullable: false),
            //        Discount = table.Column<decimal>(nullable: true),
            //        SubCategoryId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Products_SubCategories_SubCategoryId",
            //            column: x => x.SubCategoryId,
            //            principalTable: "SubCategories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_FilterItems_FilterId",
            //    table: "FilterItems",
            //    column: "FilterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_SubCategoryId",
            //    table: "Products",
            //    column: "SubCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubCategories_CategoryId",
            //    table: "SubCategories",
            //    column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
