using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class addinguserservicemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    UserDetailId = table.Column<int>(nullable: false),
                    ServiceStDate = table.Column<DateTime>(nullable: false),
                    ServiceEnDate = table.Column<DateTime>(nullable: false),
                    OriginalAmt = table.Column<decimal>(nullable: false),
                    AmtReceived = table.Column<decimal>(nullable: false),
                    AmtReceivedDate = table.Column<decimal>(nullable: false),
                    IsServiceInForce = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserServices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserServices");
        }
    }
}
