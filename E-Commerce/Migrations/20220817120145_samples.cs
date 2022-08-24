using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class samples : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 1f,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionSecondLanguage",
                table: "Product",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "nil",
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "nil",
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionSecondLanguage",
                table: "Category",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: true,
                defaultValue: "nil",
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: true,
                defaultValue: "nil",
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "Product",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float",
                oldDefaultValue: 1f);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionSecondLanguage",
                table: "Product",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000,
                oldDefaultValue: "nil")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000,
                oldDefaultValue: "nil")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "DescriptionSecondLanguage",
                keyValue: null,
                column: "DescriptionSecondLanguage",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionSecondLanguage",
                table: "Category",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000,
                oldNullable: true,
                oldDefaultValue: "nil")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "varchar(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldMaxLength: 5000,
                oldNullable: true,
                oldDefaultValue: "nil")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
