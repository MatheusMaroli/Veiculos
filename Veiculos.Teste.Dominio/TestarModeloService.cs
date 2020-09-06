using Xunit;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.AcessoDados;
using Veiculos.Dominio.Services;

namespace Veiculos.Teste.Dominio
{
    public class TestarModeloService
    {
       
        public TestarModeloService(){
            InicializadorDeValores.CriaValoresPadraoNoBancoDeDados();
        }


        [Fact]       
        public void Deve_Retornar_Erro_De_Validacao_De_Todas_As_Propriedades_Obrigatoria_Para_Cadastro()
        {         
            var db =new Db();
            var modelo = new Modelo();
            const int totalDePropriedadeObrigatorio  = 2;
            var resposta = new ModeloService(db).Cadastrar(modelo);

            Assert.Equal(totalDePropriedadeObrigatorio, resposta.Errors.Count);
        }

        [Fact]
        public void Deve_Cadastrar_Uma_Modelo()
        {
            var db =new Db();
            var modelo = new Modelo() { IdMarca= InicializadorDeValores.IdMarcaInicializado, Nome= "Modelo_Teste"};
            var resposta = new ModeloService(db).Cadastrar(modelo);

            if (! resposta.IsValidResponse())
                System.Console.WriteLine(resposta.Errors[0].Message);          
            Assert.True(resposta.IsValidResponse());
        }


        [Fact]       
        public void Deve_Retornar_Erro_De_Validacao_De_Todas_As_Propriedades_Obrigatoria_Para_Edicao()
        {
            var db =new Db();
            var modelo = new Modelo();
            const int totalDePropriedadeObrigatorio  = 3;
            var resposta = new ModeloService(db).Editar(modelo);

            Assert.Equal(totalDePropriedadeObrigatorio, resposta.Errors.Count);
        }

        [Fact]
        public void Deve_Editar_Um_Modelo()
        {
            var db =new Db();
            var modelo = new Modelo() {Id =InicializadorDeValores.IdModeloInicializado, IdMarca=InicializadorDeValores.IdMarcaInicializado, Nome="Modelo_Teste_Editado"};
            var resposta = new ModeloService(db).Editar(modelo);

            if (! resposta.IsValidResponse())
                System.Console.WriteLine(resposta.Errors[0].Message);
            Assert.True(resposta.IsValidResponse());
        }
    }
}
