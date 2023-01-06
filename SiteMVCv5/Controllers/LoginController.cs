using Microsoft.AspNetCore.Mvc;
using SiteMVCv5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVCv5.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(loginModel.Login == "adm" && loginModel.Senha == "123")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                    

                }
                return View("Index");
            }

            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login tente novamente, detalhes do erro: {erro.Message}!";
                return RedirectToAction("Index");
            }
          
        }
    }
}
