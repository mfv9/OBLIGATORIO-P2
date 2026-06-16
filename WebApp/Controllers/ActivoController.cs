using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ActivoController : Controller
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
            return View(s.GetActivosPorCuenta(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Activo a, int id)
        {
            try
            {
                Cuenta buscada = s.FindCuentaById(id);
                if (buscada != null)
                {
                    
                    a.CuentaResponsable = buscada;
                    s.AltaActivo(a);
                    ViewBag.msg = "Activo creado correctamente";
                }
            }
            catch (Exception e)
            {

                ViewBag.msg = "Error: " + e.Message;

            }
            return View();
        }

        public IActionResult Edit(string codigo)
        {
            Activo a = s.FindActivoByCodigo(codigo);
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Activo a)
        {
            s.ActualizarActivo(a);
            return RedirectToAction("Index", "Persona");
        }

        public IActionResult PersonaActivos(int id)
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

            return View(s.GetActivosById(id));
        }
    }

}
