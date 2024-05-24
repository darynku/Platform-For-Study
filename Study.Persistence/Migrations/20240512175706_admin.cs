using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserName" },
                values: new object[] { new Guid("2c2f09ce-c3d8-44ab-afd3-86fea81ccf1b"), "admin@gmail.com", "$2a$11$0WRUHt9rLLgZ3iVxF/bJ9ujF4CmSSje/NN.XQdEzLxyKElCd824wq", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2c2f09ce-c3d8-44ab-afd3-86fea81ccf1b"));
        }
    }
}
