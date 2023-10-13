using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsExample.Migrations
{
    /// <inheritdoc />
    public partial class innitdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.ID);
                });
                migrationBuilder.InsertData(
                    table:"article",
                    columns: new [] {"Title","PublishDate","Content"},
                    values: new object[]
                    {
                        "bai viet 1",
                        new DateTime(2021,9,9   ),
                        "noi dung 1"
                    });
                     migrationBuilder.InsertData(
                    table:"article",
                    columns: new [] {"Title","PublishDate","Content"},
                    values: new object[]
                    {
                        "bai viet 2",
                        new DateTime(2021,8,9),
                        "noi dung 2"
                    });
                     migrationBuilder.InsertData(
                    table:"article",
                    columns: new [] {"Title","PublishDate","Content"},
                    values: new object[]
                    {
                        "bai viet 3",
                        new DateTime(2021,9,12),
                        "noi dung 3"
                    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article");
        }
    }
}
