using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETB.WebApi.Migrations
{
    public partial class AddingTableTenders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenderRef = table.Column<string>(nullable: true),
                    WorkNo = table.Column<string>(nullable: true),
                    TenderType = table.Column<string>(nullable: true),
                    TenderTitle = table.Column<string>(nullable: true),
                    DescOfWork = table.Column<string>(nullable: true),
                    TenderDocument = table.Column<string>(nullable: true),
                    TenderRefSiteAddress = table.Column<string>(nullable: true),
                    Organisation = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    ePublishDate = table.Column<string>(nullable: true),
                    DocumentDownloadStDate = table.Column<DateTime>(nullable: true),
                    DocumentDownloadEdDate = table.Column<DateTime>(nullable: true),
                    BidOpeningDate = table.Column<DateTime>(nullable: false),
                    BidSubmissionStDate = table.Column<DateTime>(nullable: true),
                    BidSubmissionEnDate = table.Column<DateTime>(nullable: false),
                    EstimatedCost = table.Column<string>(nullable: true),
                    CostOfBOQ = table.Column<string>(nullable: true),
                    EMD = table.Column<string>(nullable: true),
                    COT = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
