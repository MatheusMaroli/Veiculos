using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Web.Models;

namespace Veiculos.Web.Controllers
{
    public class MarcaController : Controller
    {   

      
        private IEnumerable<Models.MarcaViewModel> PopulaMarcas(){
            var marcas = new List<Models.MarcaViewModel>();
            marcas.Add(new Models.MarcaViewModel() {Id=1, Nome="Honda"});
            marcas.Add(new Models.MarcaViewModel() {Id=1, Nome="Toyota"});
            marcas.Add(new Models.MarcaViewModel() {Id=1, Nome="Pegout"});
            return marcas;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _consultaModel = new Models.ConsultaViewModel();
            _consultaModel.Titulo ="Cadastro de Marcas";
            _consultaModel.RotaCadastro ="/Marca/Cadastro";
           _consultaModel.Dados = PopulaMarcas();
            return View(_consultaModel);
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}