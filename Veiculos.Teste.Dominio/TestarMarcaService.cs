using Xunit;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.AcessoDados;
using Veiculos.Dominio.Services;

namespace Veiculos.Teste.Dominio
{
    public class TestarMarcaService
    {
        public TestarMarcaService(){
            InicializadorDeValores.CriaValoresPadraoNoBancoDeDados();
        }

        [Fact]       
        public void Deve_Retornar_Erro_De_Validacao_De_Todas_As_Propriedades_Obrigatoria_Para_Cadastro()
        {
            var db =new Db();
            var marca = new Marca();
            const int totalDePropriedadeObrigatorio  = 1;
            var resposta = new MarcaService(db).Cadastrar(marca);

            Assert.Equal(totalDePropriedadeObrigatorio, resposta.Errors.Count);
        }

        [Fact]
        public void Deve_Cadastrar_Uma_Marca()
        {
            var db =new Db();
            var marca = new Marca() { Nome= "Marca_Teste"};
            var resposta = new MarcaService(db).Cadastrar(marca);


            if (! resposta.IsValidResponse())
                System.Console.WriteLine(resposta.Errors[0].Message);
            Assert.True(resposta.IsValidResponse());
        }


        [Fact]       
        public void Deve_Retornar_Erro_De_Validacao_De_Todas_As_Propriedades_Obrigatoria_Para_Edicao()
        {
            var db =new Db();
            var marca = new Marca();
            const int totalDePropriedadeObrigatorio  = 2;
            var resposta = new MarcaService(db).Editar(marca);

            Assert.Equal(totalDePropriedadeObrigatorio, resposta.Errors.Count);
        }

        [Fact]
        public void Deve_Editar_Uma_Marca()
        {
            var db =new Db();
            var marca = new Marca() {Id =InicializadorDeValores.IdMarcaInicializado, Nome="Marca_Teste_Editado"};
            var resposta = new MarcaService(db).Editar(marca);


            if (! resposta.IsValidResponse())
                System.Console.WriteLine(resposta.Errors[0].Message);
            Assert.True(resposta.IsValidResponse());
        }
    }
}
