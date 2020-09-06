using System;
namespace Veiculos.Teste.Dominio
{
    public static class InicializadorDeValores
    {
        public static int IdMarcaInicializado {get; private set;}
        public static int IdModeloInicializado {get; private set;}
        public static int IdAnuncioInicializado {get; private set;}

        public static void CriaValoresPadraoNoBancoDeDados() {
            
            var db = new Veiculos.Dominio.AcessoDados.Db();
            IdMarcaInicializado = (int) new Veiculos.Dominio.Services.MarcaService(db).Cadastrar(new Veiculos.Dominio.Entidades.Marca() { Nome = "Marca_Inicializada"}).Body;     
            IdModeloInicializado = (int) new Veiculos.Dominio.Services.ModeloService(db).Cadastrar(new Veiculos.Dominio.Entidades.Modelo() { IdMarca = IdMarcaInicializado, Nome = "Modelo_Inicializada"}).Body;   
            IdAnuncioInicializado =(int) new Veiculos.Dominio.Services.AnuncioService(db).Cadastrar(new Veiculos.Dominio.Entidades.Anuncio()
            {
               IdMarca = IdMarcaInicializado,
               IdModelo = IdModeloInicializado,
               Ano = 2000,
               ValorCompra = 20000,
               ValorVenda = 22000,
               Cor = "Anuncio_Inicialido_valor",
               TipoCombustivel = Veiculos.Dominio.TipoCombustivel.Gasolina,
               DataVenda = DateTime.Now                    
            }).Body;
            
        }
    }
}