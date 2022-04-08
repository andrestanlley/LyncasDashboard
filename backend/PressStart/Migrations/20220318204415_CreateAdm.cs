using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PressStart.Migrations
{
    public partial class CreateAdm : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql($"INSERT INTO Pessoas (nome, sobrenome, email, telefone, DataNasc) " +
                $"VALUES ('Master', 'Owner', 'adm@lyncas.net', '99999999999', 26/03/1999)");

            mb.Sql($"INSERT INTO Autenticacao (PessoaId, senha, estado) VALUES (1, 'b8648cda319ee5a20c18d694048a32f080d0f07c', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
