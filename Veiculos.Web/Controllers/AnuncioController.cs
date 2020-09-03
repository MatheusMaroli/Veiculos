using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Dominio.AcessoDados;
using Veiculos.Web.Models;

namespace Veiculos.Web.Controllers
{
    public class AnuncioController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromServices] Db db)
        {
            
            return View();
        }
    }
}