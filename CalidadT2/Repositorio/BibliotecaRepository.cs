using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface IBibliotecaRepository
    {
      
    }
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly AppBibliotecaContext app;

        public BibliotecaRepository(AppBibliotecaContext app)
        {
            this.app = app;
        }

        
    }
}
