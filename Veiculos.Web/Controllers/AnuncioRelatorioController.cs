using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Dominio.AcessoDados;
using Utils.ClassExtensions;
using Veiculos.Web.Models;
using Veiculos.Dominio.Repositorio;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Web.Controllers
{
    public class AnuncioRelatorioController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromServices] Db db)
        {          
            var model = new Models.RelatorioConsultaViewModel() {
                Titulo ="Relatório de Venda de Veículos",
                RotaRelatorio = "/AnuncioRelatorio/GerarRelatorio",
                SubTitulo = "Relatório com informação de venda de veículos por data.",
                Filtro =  new FiltroAnuncioRelatorioViewModel(){
                        DataMinima = DateTime.Now.StartOfMonth(),
                        DataMaxima = DateTime.Now.EndOfMonth()
                    }
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult GerarRelatorio ([FromServices] Db db, FiltroAnuncioRelatorioViewModel param) 
        {   
            var repositorio = new Repositorio<Anuncio>(db);
            var anuncios = repositorio.Get.Where(f =>  f.DataVenda >= param.DataMinima && f.DataVenda <= param.DataMaxima).ToList();

            var model= new Models.RelatorioViewModel(){
                Titulo = "Relatório de Venda de Veículos",
                RotaDeRetorno="/AnuncioRelatorio/Index",
                Dados = anuncios.Select(anuncio => new AnuncioRelatorioViewModel() {
                    Modelo= anuncio.Modelo.Nome,
                    Marca = anuncio.Marca.Nome,
                    Ano= anuncio.Ano,
                    DataVenda = anuncio.DataVenda,
                    ValorCompra = anuncio.ValorCompra,
                    ValorVenda = anuncio.ValorVenda,
                    Lucro = anuncio.ValorVenda - anuncio.ValorCompra
                })
            };
            return View("Relatorio", model);
        }
    }
}