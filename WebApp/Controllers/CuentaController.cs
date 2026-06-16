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
            if (lrol != "Administrador")
            {
                return RedirectToAction("NoPermitido", "Auth");

            }

            return View(s.GetCuentasPorId(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, bool mfa)
        {
            try
            {
                Persona buscada = s.FindPersonaById(id);
                if (buscada != null)
                {
                    Cuenta c = new Cuenta();
                    c.TieneMfa = mfa;
                    c.Titular = buscada;
                    s.AltaCuenta(c);
                    ViewBag.msg = "Cuenta creada correctamente";
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error: " + e.Message;
            }
            return View();
        }

    }
}

