using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PersonaController : Controller
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            return View(s.GetPersonas());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona p)
        {
            try
            {
                s.AltaPersona(p);
                ViewBag.msg = "Alta correcta";
            }
            catch (Exception e)
            {
                ViewBag.msg = "Error: " + e.Message;

            }
            return View();
        }

        public IActionResult Details(int id)
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            if(lid == null)
            {
                return RedirectToAction("NoPermitido", "Auth");
            }
            if(lid != id)
            {
                return RedirectToAction("NoPermitido", "Auth");
            }
            ViewBag.activos = s.FindActivosById(id); 
            return View(s.FindPersonaById(id));
        }

       

    }
}
