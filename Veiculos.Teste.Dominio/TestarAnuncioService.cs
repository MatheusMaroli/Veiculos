using Veiculos.Dominio.AcessoDados;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Services;
using Xunit;

namespace Veiculos.Teste.Dominio
{
    public class TestarAnuncioService
    {

        public TestarAnuncioService(){
            InicializadorDeValores.CriaValoresPadraoNoBancoDeDados();
        }

        [Fact]       
        public void Deve_Retornar_Erro_De_Validacao_De_Todas_As_Propriedades_Obrigatoria_Para_Cadastro()
        {
            var db =new Db();
            var anuncio = new Anuncio();
            const int totalDePropriedadeObrigatorio  = 7;
            var resposta = new AnuncioService(db).Cadastrar(anuncio);

            Assert.Equal(totalDePropriedadeObrigatorio, resposta.Errors.Count);
        }

        [Fact]
        public void Deve_Cadastrar_Um_Anuncio()
        {
            var db =new Db();
            var anuncio = new Anuncio() 
            { 
                IdMarca = InicializadorDeValores.IdMarcaInicializado,
                IdModelo = InicializadorDeValores.IdModeloInicializado,
                Ano = 2020,
                ValorCompra = 20000,
                ValorVenda = 25000,
                Cor = "Preto_Teste",
                TipoCombustivel = Veiculos.Dominio.TipoCombustivel.Gasolina
            };
            var resposta = new AnuncioService(db).Cadastrar(anuncio);

            if (! resposta.IsValidResponse())
                System.Console.WriteLine(resposta.Errors[0].Message);


            Assert.True(resposta.IsValidResponse());
        }


        [Fact]       
        public void Deve_Retornar_Erro_De_Validacao_De_Todas_As_Propriedades_Obrigatoria_Para_Edicao()
        {
            var db =new Db();
            var anuncio = new Anuncio();
            const int totalDePropriedadeObrigatorio  = 8;
            var resposta = new AnuncioService(db).Editar(anuncio);

            Assert.Equal(totalDePropriedadeObrigatorio, resposta.Errors.Count);
        }

        [Fact]
        public void Deve_Editar_Um_Anuncio()
        {
            var db =new Db();
            var anuncio = new Anuncio() 
            { 
                Id= InicializadorDeValores.IdAnuncioInicializado,
                IdMarca = InicializadorDeValores.IdMarcaInicializado,
                IdModelo = InicializadorDeValores.IdModeloInicializado,
                Ano = 2020,
                ValorCompra = 22000,
                ValorVenda = 27000,
                Cor = "Preto_Teste_Edicao",
                TipoCombustivel = Veiculos.Dominio.TipoCombustivel.Diesel
            };
            var resposta = new AnuncioService(db).Editar(anuncio);


            if (! resposta.IsValidResponse())
                System.Console.WriteLine(resposta.Errors[0].Message);

            Assert.True(resposta.IsValidResponse());
        }
    }
}