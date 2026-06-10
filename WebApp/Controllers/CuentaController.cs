using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CuentaController : Controller
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            string lrol = HttpContext.Session.GetString("LogueadoRol");

            if (lid == null)
            {
                return RedirectToAction("NoPermitido", "Auth");
            }
            if(lrol != "Administrador")
            {
                return RedirectToAction("NoPermitido", "Auth");

            }

            return View(s.GetCuentasPorId(id));
        }
    }
}
