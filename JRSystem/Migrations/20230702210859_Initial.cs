using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JRSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountSets",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetupTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSets", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "ReferralSets",
                columns: table => new
                {
                    ReferralId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReferralName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferralDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralSets", x => x.ReferralId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountSets");

            migrationBuilder.DropTable(
                name: "ReferralSets");
        }
    }
}
