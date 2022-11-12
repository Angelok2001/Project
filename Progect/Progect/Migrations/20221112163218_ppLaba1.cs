using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progect.Migrations
{
    /// <inheritdoc />
    public partial class ppLaba1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FunctionalArea",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParrentID = table.Column<int>(type: "int", nullable: false),
                    FunctionalAreaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalArea", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionalArea_FunctionalArea_ParrentID",
                        column: x => x.ParrentID,
                        principalTable: "FunctionalArea",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrudeValue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParrentID = table.Column<int>(type: "int", nullable: false),
                    StructureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Structures_Structures_ParrentID",
                        column: x => x.ParrentID,
                        principalTable: "Structures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TupeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDatails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StructureID = table.Column<int>(type: "int", nullable: false),
                    StructuresID = table.Column<int>(type: "int", nullable: false),
                    TypesID = table.Column<int>(type: "int", nullable: false),
                    AccessCount = table.Column<int>(type: "int", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FunctionalAreaID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Documents_FunctionalArea_FunctionalAreaID",
                        column: x => x.FunctionalAreaID,
                        principalTable: "FunctionalArea",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Structures_StructuresID",
                        column: x => x.StructuresID,
                        principalTable: "Structures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Types_TypesID",
                        column: x => x.TypesID,
                        principalTable: "Types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    DocumentsID = table.Column<int>(type: "int", nullable: false),
                    SectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sections_Documents_DocumentsID",
                        column: x => x.DocumentsID,
                        principalTable: "Documents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageAltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImadeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImadeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Images_Sections_SectionsID",
                        column: x => x.SectionsID,
                        principalTable: "Sections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FunctionalAreaID",
                table: "Documents",
                column: "FunctionalAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RoleID",
                table: "Documents",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StructuresID",
                table: "Documents",
                column: "StructuresID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypesID",
                table: "Documents",
                column: "TypesID");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalArea_ParrentID",
                table: "FunctionalArea",
                column: "ParrentID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_SectionsID",
                table: "Images",
                column: "SectionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DocumentsID",
                table: "Sections",
                column: "DocumentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Structures_ParrentID",
                table: "Structures",
                column: "ParrentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "FunctionalArea");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Structures");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
