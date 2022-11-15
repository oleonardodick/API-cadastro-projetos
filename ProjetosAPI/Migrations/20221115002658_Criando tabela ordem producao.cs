using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetosAPI.Migrations
{
    public partial class Criandotabelaordemproducao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemProducao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemProducao_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducao_ProjetoId",
                table: "OrdemProducao",
                column: "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemProducao");
        }
    }
}
