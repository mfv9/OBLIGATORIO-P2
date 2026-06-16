using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class IncidenteController : Controller 
    {
        Sistema s = Sistema.getInstance();
        public IActionResult Index()
        {
            return View(s.GetIncidentes());
        }
    }
}
