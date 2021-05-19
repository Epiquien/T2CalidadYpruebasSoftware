using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface ILibroRepository
    {
        public Libro DetalleLibro(int id);
        public Usuario ObtenerUsuarioLogin(Claim claim);

    }
    public class LibroRepository : ILibroRepository
    {
        private readonly AppBibliotecaContext app;

        public LibroRepository(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public Libro DetalleLibro(int id)
        {
            var libroDetalle = app.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();

            return libroDetalle;
        }

        public Usuario ObtenerUsuarioLogin(Claim claim)
        {
            var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
