using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Allup.Migrations
{
    public partial class UpdateSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderContents");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainTitle",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Sliders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "931b2f08-f667-48f9-8cdb-eac09f7027f4", "0749eda4-1452-4909-974c-cabcd3af0829" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 858, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 858, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 858, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 858, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 858, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 858, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 1, 13, 50, 27, 859, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "MainTitle", "SubTitle" },
                values: new object[] { "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "<span>4K HDR Smart TV 43 </span> Sony Bravia.", "Save $120 when you buy" });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "MainTitle", "SubTitle" },
                values: new object[] { "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "<span>4K HDR Smart TV 43 </span> Sony Bravia.", "Save $120 when you buy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "MainTitle",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Sliders");

            migrationBuilder.CreateTable(
                name: "SliderContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderContents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "519ef060-5950-448e-929a-d60c82121f15", "647f92c6-6f5b-4d04-84c3-8b2e19cae726" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 223, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 225, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 225, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 225, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 227, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 227, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 227, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 227, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 227, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 227, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 227, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(6826));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 226, DateTimeKind.Local).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 228, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 228, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 228, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 31, 23, 26, 54, 228, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.InsertData(
                table: "SliderContents",
                columns: new[] { "Id", "Description", "MainTitle", "SubTitle" },
                values: new object[,]
                {
                    { 2, "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "<span>4K HDR Smart TV 43 </span> Sony Bravia.", "Save $120 when you buy" },
                    { 1, "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform", "<span>4K HDR Smart TV 43 </span> Sony Bravia.", "Save $120 when you buy" }
                });
        }
    }
}
