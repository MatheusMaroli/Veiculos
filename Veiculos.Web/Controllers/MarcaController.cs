using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Web.Models;
using Veiculos.Dominio.AcessoDados;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Repositorio;
using Veiculos.Dominio.Services;

namespace Veiculos.Web.Controllers
{
    public class MarcaController : Controller
    {   
        [HttpGet]
        public IActionResult Index([FromServices] Db db)
        {
            var repositorio = new Repositorio<Marca>(db);
            var _consultaModel = new Models.ConsultaViewModel();
            _consultaModel.Titulo ="Cadastro de Marcas";
            _consultaModel.RotaCadastro ="/Marca/Cadastro";
           _consultaModel.Dados = repositorio.Get;
            return View(_consultaModel);
        }

        [HttpGet]
        public IActionResult Buscar([FromServices] Db db)
        {
            var repositorio = new Repositorio<Marca>(db);       
            var marcas = repositorio.Get.Select(marca => new {marca.Id, marca.Nome}).ToList()    ;
            return Json(marcas);
        }

 


        [HttpGet]
        public IActionResult Cadastro()
        {   
            var model = new Models.CadastroViewModel();
            model.RotaForm="/Marca/Cadastro";
            model.Titulo="Cadastro de Marcas";
            model.Dados = new Marca();

            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Cadastro([FromServices] Db db, Marca param)
        {
            var marcaService= new MarcaService(db);
            var response = marcaService.Cadastrar(param);
            response.RotaRetorno = "/Marca/Index";   
            if (response.IsValidResponse())
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        public IActionResult Editar([FromServices] Db db, int id)
        {    
            var repositorio = new Repositorio<Marca>(db);
            var model = new Models.CadastroViewModel();
            model.RotaForm="/Marca/Editar";
            model.Titulo="Editar Marca";
            model.Dados = repositorio.Get.FirstOrDefault(f => f.Id == id);

            return View("Form", model);
        }


        [HttpPost]
        public IActionResult Editar([FromServices] Db db, Marca param)
        {
            var marcaService= new MarcaService(db);
            var response = marcaService.Editar(param);
            response.RotaRetorno = "/Marca/Index";   
            if (response.IsValidResponse())
                return Ok(response);
            return BadRequest(response);
        }
    }
}