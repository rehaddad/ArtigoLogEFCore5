using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtigoLogEFCore5.Migrations
{
    public partial class SetupInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Covid = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Pacientes_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "MedicoId", "Especialidade", "Nome" },
                values: new object[] { 1, "Infectologista", "Marcelo" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "MedicoId", "Especialidade", "Nome" },
                values: new object[] { 2, "Ortopedista", "Thiago" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "MedicoId", "Especialidade", "Nome" },
                values: new object[] { 3, "Ginecologista", "Regina" });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "PacienteId", "Covid", "MedicoId", "Nome" },
                values: new object[,]
                {
                    { 1, true, 1, "Renato" },
                    { 2, true, 1, "Livia" },
                    { 3, false, 2, "Ivete" },
                    { 4, true, 2, "Rosi" },
                    { 5, true, 3, "Reginaldo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_MedicoId",
                table: "Pacientes",
                column: "MedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
