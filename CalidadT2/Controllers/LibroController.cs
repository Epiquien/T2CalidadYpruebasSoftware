using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        //private readonly AppBibliotecaContext app;
        private readonly ILibroRepository _libro;
        private readonly IComentarioRepository _comentario;
        private readonly ICookieAuthService _cookieAuthService;


        public LibroController(ILibroRepository _libro, IComentarioRepository _comentario, ICookieAuthService _cookieAuthService)
        {
           // this.app = app;
            this._libro = _libro;
            this._comentario = _comentario;
            this._cookieAuthService = _cookieAuthService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            //var model = app.Libros
            //    .Include("Autor")
            //    .Include("Comentarios.Usuario")
            //    .Where(o => o.Id == id)
            //    .FirstOrDefault();

            //return View(model);
            var libroDetalle = _libro.DetalleLibro(id);
            return View(libroDetalle);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            //comentario.UsuarioId = user.Id;
            //comentario.Fecha = DateTime.Now;
            //app.Comentarios.Add(comentario);

            //var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            //libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            //app.SaveChanges();

            _comentario.AgregarComentario(user, comentario);
            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            //var claim = HttpContext.User.Claims.FirstOrDefault();
            _cookieAuthService.SetHttpContext(HttpContext);
            var claim = _cookieAuthService.ObtenerClaim();
            // var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            var user = _libro.ObtenerUsuarioLogin(claim);
            return user;
        }
    }
}
