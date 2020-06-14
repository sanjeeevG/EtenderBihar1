using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class AddingTableUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserInfoId = table.Column<int>(nullable: true),
                    Salutation = table.Column<string>(maxLength: 10, nullable: true),
                    FName = table.Column<string>(maxLength: 50, nullable: true),
                    MName = table.Column<string>(maxLength: 50, nullable: true),
                    LName = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: true),
                    Organisation = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Email1 = table.Column<string>(nullable: true),
                    Email2Optinal = table.Column<string>(nullable: true),
                    WantEmailNotfi = table.Column<int>(nullable: false),
                    ContactNo1 = table.Column<string>(maxLength: 20, nullable: true),
                    ContactNo2Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    ContactNo3Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    Nationality = table.Column<string>(maxLength: 25, nullable: true),
                    WantSMSNotfi = table.Column<int>(nullable: false),
                    WantWhatsUpNotfi = table.Column<int>(nullable: false),
                    PhotoUrl = table.Column<string>(maxLength: 255, nullable: true),
                    WebUrl = table.Column<string>(maxLength: 255, nullable: true),
                    IsDetailUpdated = table.Column<int>(nullable: false),
                    IsActive = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserInfoId",
                table: "UserDetails",
                column: "UserInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
