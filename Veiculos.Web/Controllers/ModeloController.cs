using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Dominio.AcessoDados;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Repositorio;
using Veiculos.Web.Models;

namespace Veiculos.Web.Controllers
{
    public class ModeloController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromServices] Db db)
        {
            var repositorio = new Repositorio<Modelo>(db);
            var _consultaModel = new Models.ConsultaViewModel();
            _consultaModel.Titulo ="Cadastro de Modelo";
            _consultaModel.RotaCadastro ="/Modelo/Cadastro";
           _consultaModel.Dados = repositorio.Get;
            return View(_consultaModel);
        }

        [HttpGet]
        public IActionResult Cadastro()
        {   
            var model = new Models.CadastroViewModel();
            model.RotaForm="/Modelo/Cadastro";
            model.Titulo="Cadastro de Marcas";
            model.Dados = new Modelo();
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Cadastro([FromServices] Db db, Marca param)
        {
            return null;
        }

        [HttpGet]
        public IActionResult Editar([FromServices] Db db, int id)
        {    
            var repositorio = new Repositorio<Modelo>(db);
            var model = new Models.CadastroViewModel();
            model.RotaForm="/Modelo/Editar";
            model.Titulo="Editar Modelo";
            model.Dados = repositorio.Get.FirstOrDefault(f => f.Id == id);
            return View("Form", model);
        }


        [HttpPost]
        public IActionResult Editar([FromServices] Db db, Marca param)
        {
            return null;
        }
    }
}