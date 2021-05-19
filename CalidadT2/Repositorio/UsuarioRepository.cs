using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface IUsuarioRepository
    {
        public Usuario EncontrarUsuario(String user, String password);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppBibliotecaContext app;

        public UsuarioRepository(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public Usuario EncontrarUsuario(string user, string password)
        {
            var usuario = app.Usuarios.Where(o => o.Username == user && o.Password == password).FirstOrDefault();
            return usuario;
        }
    }
}
