using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    FactionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FactionName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FactionDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.FactionID);
                });

            migrationBuilder.CreateTable(
                name: "PaintTypes",
                columns: table => new
                {
                    PaintTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintTypes", x => x.PaintTypeID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StateDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    FactionID = table.Column<int>(type: "INTEGER", nullable: false),
                    StateID = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelID);
                    table.ForeignKey(
                        name: "FK_Models_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "FactionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paints",
                columns: table => new
                {
                    PaintID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaintName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    HexCode = table.Column<string>(type: "TEXT", nullable: false),
                    BrandID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaintTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaintQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paints", x => x.PaintID);
                    table.ForeignKey(
                        name: "FK_Paints_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paints_PaintTypes_PaintTypeID",
                        column: x => x.PaintTypeID,
                        principalTable: "PaintTypes",
                        principalColumn: "PaintTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paints_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelPaints",
                columns: table => new
                {
                    ModelID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaintID = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelPaintID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsageType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelPaints", x => new { x.ModelID, x.PaintID });
                    table.ForeignKey(
                        name: "FK_ModelPaints_Models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Models",
                        principalColumn: "ModelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelPaints_Paints_PaintID",
                        column: x => x.PaintID,
                        principalTable: "Paints",
                        principalColumn: "PaintID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelPaints_PaintID",
                table: "ModelPaints",
                column: "PaintID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_FactionID",
                table: "Models",
                column: "FactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_StateID",
                table: "Models",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_UserID",
                table: "Models",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Paints_BrandID",
                table: "Paints",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Paints_PaintTypeID",
                table: "Paints",
                column: "PaintTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Paints_UserID",
                table: "Paints",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelPaints");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Paints");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "PaintTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
