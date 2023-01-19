using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Twitter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TwitterStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfTweets = table.Column<int>(type: "int", nullable: false),
                    Hashtag = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterStatistics", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TwitterStatistics",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Hashtag", "LastModifiedBy", "LastModifiedDate", "NumberOfTweets" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 1, 18, 15, 14, 58, 778, DateTimeKind.Local).AddTicks(2629), "#brasil#saopaulo#competition#influencer#influencermarketing#fridayfeeling#MondayMotivation#tbt#traveltuesday#vegan", null, null, 1000 },
                    { 2, null, new DateTime(2023, 1, 17, 15, 14, 58, 778, DateTimeKind.Local).AddTicks(2698), "#usa#tampa#competition#influencer#influencermarketing#fridayfeeling#MondayMotivation#tbt#traveltuesday#vegan", null, null, 2000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwitterStatistics");
        }
    }
}
