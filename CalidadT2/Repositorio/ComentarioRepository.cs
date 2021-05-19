using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface IComentarioRepository
    {
        public void AgregarComentario(Usuario user, Comentario comentario);
    }
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppBibliotecaContext app;

        public ComentarioRepository(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public void AgregarComentario( Usuario user, Comentario comentario)
        {
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            app.Comentarios.Add(comentario);

            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();
        }
    }
}
