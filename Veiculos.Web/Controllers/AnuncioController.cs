using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Dominio.AcessoDados;
using Veiculos.Web.Models;
using Veiculos.Dominio.Repositorio;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Services;
using Veiculos.Dominio;

namespace Veiculos.Web.Controllers
{
    public class AnuncioController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromServices] Db db)
        {
            var repositorio = new Repositorio<Anuncio>(db);
            var model = new ConsultaViewModel(){
                RotaCadastro = "/Anuncio/Cadastro",
                Titulo = "Cadastro de Anúncio",
                Dados = repositorio.Get
            };
            return View(model);
        }
      
        public IActionResult BuscarTipoCombustivel(){
                var tipos = new List<TipoCombustivel>();
                tipos.Add(TipoCombustivel.NaoExiste);
                tipos.Add(TipoCombustivel.Alcool);
                tipos.Add(TipoCombustivel.Disel);
                tipos.Add(TipoCombustivel.Gasolina);
                tipos.Add(TipoCombustivel.Vapor);
                var response = tipos .Select(t => new {Id = t, Nome=t.ToString()});

                return Json(response);
            }

        [HttpGet]
        public IActionResult Cadastro()
        {
            var model = new CadastroViewModel(){
                Titulo= "Cadastro de Anúncio",
                RotaForm="/Anuncio/Cadastro",
                Dados = new Anuncio()
            };
            return View("Form", model);
        }

   


        [HttpPost]
        public IActionResult Cadastro([FromServices]Db db, Anuncio param){
            var service = new AnuncioService(db);
            var response = service.Cadastrar(param);
            if (response.IsValidResponse())
                return Ok(response);
            return BadRequest(response);    

        }


        [HttpGet]
        public IActionResult Editar([FromServices]Db db, int id)
        {
            var repositorio = new Repositorio<Anuncio>(db);
            var anuncio = repositorio.Get.FirstOrDefault(filtro => filtro.Id == id);

            var model = new CadastroViewModel(){
                Titulo= "Cadastro de Anúncio",
                RotaForm="/Anuncio/Editar",
                Dados = anuncio
            };
            return View("Form", model);
        }
    
        [HttpPost]
        public IActionResult Editar([FromServices]Db db, Anuncio param){
            var service = new AnuncioService(db);
            var response = service.Editar(param);
            if (response.IsValidResponse())
                return Ok(response);
            return BadRequest(response);    

        }
    
    }
}