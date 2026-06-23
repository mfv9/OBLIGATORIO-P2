using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            string lrol = HttpContext.Session.GetString("LogueadoRol");

            if (lrol == "Operador" || lrol == "Administrador")
            {
                return RedirectToAction("NoPermitido", "Auth");
            }

            return View();
        }

       public IActionResult Menu(int id)
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            if (lid == null)
            {
                return RedirectToAction("NoPermitido", "Auth");
            }
            if (lid != id)
            {
                return RedirectToAction("NoPermitido", "Auth");
            }
            ViewBag.Persona = s.FindPersonaById(id);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
