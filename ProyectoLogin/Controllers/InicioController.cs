using Microsoft.AspNetCore.Mvc;

using ProyectoLogin.Models;
using ProyectoLogin.Recursos;
using ProyectoLogin.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ProyectoLogin.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public InicioController(IUsuarioService usuarioService)
        {

            _usuarioService = usuarioService;
        }
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]

        public async IActionResult Registrarse(Usuario modelo)
        {
            modelo.Clave = Utilidades.EncriptarClave(modelo.Clave);

            Usuario usuario_creado = await _usuarioService.SaveUsuario(modelo);

            if (usuario_creado.IdUsuario > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crea el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]

        public async IActionResult IniciarSesion(string correo,string clave)
        {
            Usuario usuario_encontrado = await _usuarioService.GetUsuario(correo.Utilidades.EncriptarClave(clave));


             return View();
        }

    }
}
