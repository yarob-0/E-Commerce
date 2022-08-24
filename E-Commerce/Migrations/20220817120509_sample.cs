using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class sample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("06989192-5c8d-4188-8324-bcf311a93983"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("07a70ce3-f9cb-4d10-9d46-e852e1936244"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6780fe5f-f61b-4c2c-92b6-d86fcab7b820"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ae89aa06-8423-4d9a-817b-f424afbd1050"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "NameSecondLanguage" },
                values: new object[,]
                {
                    { new Guid("2b768143-2f81-4f94-9083-d0f42109eef7"), "Category 1", "تصنيف  ١" },
                    { new Guid("42bbbd77-d0f2-453a-a6d0-b8c0b9479222"), "Category 2", "تصنيف  ٢" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "DescriptionSecondLanguage", "ImagePath", "Name", "NameSecondLanguage", "Price", "Rate" },
                values: new object[,]
                {
                    { new Guid("20f6e016-d0ca-4fd7-afba-86f5a79d0671"), " a detalied discription of Produce 1", "وصف مفصل لمنتج ١", null, "product 1", "منتج ١", 2345m, 1f },
                    { new Guid("a06e52c3-bced-4f3c-8c00-a0b1e012b7be"), " a detalied discription of Produce 2", "وصف مفصل لمنتج ٢", null, "product 2", "منتج ٢", 25m, 3f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2b768143-2f81-4f94-9083-d0f42109eef7"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("42bbbd77-d0f2-453a-a6d0-b8c0b9479222"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("20f6e016-d0ca-4fd7-afba-86f5a79d0671"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a06e52c3-bced-4f3c-8c00-a0b1e012b7be"));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "DescriptionSecondLanguage", "ImagePath", "Name", "NameSecondLanguage", "Price", "Rate" },
                values: new object[] { new Guid("06989192-5c8d-4188-8324-bcf311a93983"), " a detalied discription of Produce 2", "وصف مفصل لمنتج ٢", null, "product 2", "منتج ٢", 25m, 3f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ImagePath", "Name", "NameSecondLanguage" },
                values: new object[] { new Guid("07a70ce3-f9cb-4d10-9d46-e852e1936244"), null, "Category 2", "تصنيف  ٢" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "DescriptionSecondLanguage", "ImagePath", "Name", "NameSecondLanguage", "Price", "Rate" },
                values: new object[] { new Guid("6780fe5f-f61b-4c2c-92b6-d86fcab7b820"), " a detalied discription of Produce 1", "وصف مفصل لمنتج ١", null, "product 1", "منتج ١", 2345m, 1f });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ImagePath", "Name", "NameSecondLanguage" },
                values: new object[] { new Guid("ae89aa06-8423-4d9a-817b-f424afbd1050"), null, "Category 1", "تصنيف  ١" });
        }
    }
}
