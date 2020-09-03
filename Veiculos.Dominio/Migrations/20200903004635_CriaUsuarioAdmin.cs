using Microsoft.EntityFrameworkCore.Migrations;
using Utils.Crypt;


namespace Veiculos.Dominio.Migrations
{
    public partial class CriaUsuarioAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var senhaCrypt = new Md5Crypt().Crypt("admin");
            migrationBuilder.Sql($"Insert Into usuarios (Id, Deletado, Nome, Email, Senha) values(1, \"false\", \"Admin\", \"admin@admin.com\", \"{senhaCrypt}\")");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from usuarios where Id = 1");
        }
    }
}
