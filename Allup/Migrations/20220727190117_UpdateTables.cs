using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Allup.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6d824f9d-b393-448a-b411-b1d21e1d812d", "c1a51ea0-02d1-4e33-b9e2-aaac9e0ad27c" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 304, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7679), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7691), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7693), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7695), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7696), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7698), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7699), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 1, 17, 305, DateTimeKind.Local).AddTicks(7701), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 306, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 306, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 306, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 23, 1, 17, 306, DateTimeKind.Local).AddTicks(2932));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cfadf4be-a114-4eb1-a862-914d046081bb", "f0bfd589-42e7-42d9-9d99-b4da87b7093e" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 600, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7282), "category-5.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7291), "category-6.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7293), "category-7.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7294), "category-8.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7296), "category-9.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7297), "category-10.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7298), "category-11.jpg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImgUrl" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 17, 9, 601, DateTimeKind.Local).AddTicks(7299), "category-12.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 602, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 602, DateTimeKind.Local).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 602, DateTimeKind.Local).AddTicks(1433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 27, 5, 17, 9, 602, DateTimeKind.Local).AddTicks(1435));
        }
    }
}
