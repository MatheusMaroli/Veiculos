using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Web.Models;

namespace Veiculos.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.LoginMensagemErro = "";
            return View("Login", new LoginViewModel(){
                Email = "", 
                Senha = ""
            });
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel param)
        {
            if ((param.Email == "matheus.maroli66@gmail.com") && (param.Senha == "123"))
                return RedirectToAction("Index", "PainelAdministrativo");
            else  {
                ViewBag.LoginMensagemErro = "Usuário ou senha ivnado";  
                return View(param);
            }   
        }
    }
}