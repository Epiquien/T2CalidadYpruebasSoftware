using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface IAutorRepository
    {

    }
    public class AutorRepository : IAutorRepository
    {
        private readonly AppBibliotecaContext app;

        public AutorRepository(AppBibliotecaContext app)
        {
            this.app = app;
        }


    }
}
