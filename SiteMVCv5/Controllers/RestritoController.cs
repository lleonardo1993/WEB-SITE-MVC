using Microsoft.AspNetCore.Mvc;
using SiteMVCv5.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVCv5.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaParaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
