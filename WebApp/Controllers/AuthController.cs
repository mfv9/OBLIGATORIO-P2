using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {

        Sistema s = Sistema.getInstance();
    
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            Persona buscado = s.VerificarExistencia(lvm.Email, lvm.Password);
            if(buscado == null)
            {
                ViewBag.msg = "No se encontro la cuenta";
                return View();
            }
            else
            {

                HttpContext.Session.SetInt32("LogueadoId", buscado.Id);
                HttpContext.Session.SetString("LogueadoNombre", buscado.Nombre);
                HttpContext.Session.SetString("LogueadoRol", buscado.Rol);

                if (buscado.Rol == "Administrador")
                {
                    return RedirectToAction("Index", "Persona");
                }
                else
                {
                    return RedirectToAction("Details", "Persona", new { id = buscado.Id });

                }
            }
            
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetInt32("LogueadoId") is null)
            {
                return RedirectToAction("Login", "Auth");

            }
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");

    }

        public IActionResult NoPermitido()
        {
            
            return View();
        }
}
}
