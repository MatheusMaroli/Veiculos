using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Web.Models;

namespace Veiculos.Web.Controllers
{
    public class ModeloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}