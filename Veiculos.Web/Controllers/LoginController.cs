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
        public ActionResult Login([FromServices] Db db, LoginViewModel param)
        {

            var repositorio = new Repositorio<Usuario>(db);
            var usuario = repositorio.Get.FirstOrDefault(u => u.Email.Trim() == param.Email.Trim() && u.Senha == new Utils.Crypt.Md5Crypt().Crypt(param.Senha));


            if (usuario != null)
                return RedirectToAction("Index", "PainelAdministrativo");
            else  {
                ViewBag.LoginMensagemErro = "Usuário ou senha ivnado";  
                return View(param);
            }   
        }
    }
}