using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YounicornApp.Infrastructure.Migrations
{
    public partial class ChangesInAllDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ContactForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendBCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ISPdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ispname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Displayname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isprating = table.Column<float>(type: "real", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ISPdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RedirectUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<long>(type: "bigint", nullable: false),
                    ActionDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EnquiryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActionDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IspId = table.Column<long>(type: "bigint", nullable: true),
                    IspOfferId = table.Column<long>(type: "bigint", nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ISPoffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Displayname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pricemonth = table.Column<float>(type: "real", nullable: false),
                    Priceannual = table.Column<float>(type: "real", nullable: false),
                    Discountdetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bundledetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bullet1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bullet2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bullet3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bullet4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bullet5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Installationcost = table.Column<float>(type: "real", nullable: false),
                    Modemcost = table.Column<float>(type: "real", nullable: false),
                    Terminationfee = table.Column<float>(type: "real", nullable: false),
                    Offerrating = table.Column<float>(type: "real", nullable: false),
                    Favourite = table.Column<int>(type: "int", nullable: false),
                    Ispid = table.Column<int>(type: "int", nullable: false),
                    Adsl = table.Column<bool>(type: "bit", nullable: false),
                    Vdsl = table.Column<bool>(type: "bit", nullable: false),
                    Fibre = table.Column<bool>(type: "bit", nullable: false),
                    Fibreplus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ISPoffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ISPoffers_tbl_ISPdetails_Ispid",
                        column: x => x.Ispid,
                        principalTable: "tbl_ISPdetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Users_tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SignUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IspOfferId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SignUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_SignUps_tbl_ISPoffers_IspOfferId",
                        column: x => x.IspOfferId,
                        principalTable: "tbl_ISPoffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "RedirectUrl" },
                values: new object[] { 1, 1, new DateTime(2021, 4, 20, 15, 30, 10, 182, DateTimeKind.Utc).AddTicks(6825), true, null, null, "Admin", "/Provider/Index" });

            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "RedirectUrl" },
                values: new object[] { 2, 1, new DateTime(2021, 4, 20, 15, 30, 10, 182, DateTimeKind.Utc).AddTicks(7966), true, null, null, "Member", "" });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "Firstname", "IsActive", "Lastname", "ModifiedBy", "ModifiedDate", "Password", "Phone", "RoleId", "Username" },
                values: new object[] { 1, 1, new DateTime(2021, 4, 20, 15, 30, 10, 186, DateTimeKind.Utc).AddTicks(336), "admin@younicorn.com", "admin", true, "admin", null, null, "YouYou99!", "12345678", 1, "younicorn" });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "Firstname", "IsActive", "Lastname", "ModifiedBy", "ModifiedDate", "Password", "Phone", "RoleId", "Username" },
                values: new object[] { 2, 1, new DateTime(2021, 4, 20, 15, 30, 10, 186, DateTimeKind.Utc).AddTicks(514), "testuser@younicorn.com", "user", true, "user", null, null, "user", "123456789", 2, "user" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ISPoffers_Ispid",
                table: "tbl_ISPoffers",
                column: "Ispid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SignUps_IspOfferId",
                table: "tbl_SignUps",
                column: "IspOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_RoleId",
                table: "tbl_Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ContactForms");

            migrationBuilder.DropTable(
                name: "tbl_EmailTemplates");

            migrationBuilder.DropTable(
                name: "tbl_SignUps");

            migrationBuilder.DropTable(
                name: "tbl_UserHistory");

            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.DropTable(
                name: "tbl_ISPoffers");

            migrationBuilder.DropTable(
                name: "tbl_Roles");

            migrationBuilder.DropTable(
                name: "tbl_ISPdetails");
        }
    }
}
