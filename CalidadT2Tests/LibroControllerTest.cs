using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Tests
{

    public class LibroControllerTest
    {
        [Test]
        public void PruebaDetails()
        {
            var IDetalleMock = new Mock<ILibroRepository>();
            var IComentarioMock = new Mock<IComentarioRepository>();
          

            var libro = new Libro();
            libro.Id = 1;

            IDetalleMock.Setup(o => o.DetalleLibro(libro.Id));

            var ICookieMock = new Mock<ICookieAuthService>();
            var libroCont = new LibroController(IDetalleMock.Object, IComentarioMock.Object, ICookieMock.Object);

            var valida = libroCont.Details(1);
            // var authCont = new AuthController(IDetalleMock.Object);

            //var detalle = IDetalleMock.Verify(id);
            Assert.IsInstanceOf<ViewResult>(valida);

        }

        [Test]
        public void AgregaComentario()
        {
            var IDetalleMock = new Mock<ILibroRepository>();
            var IComentarioMock = new Mock<IComentarioRepository>();
            var ICookieMock = new Mock<ICookieAuthService>();

            IComentarioMock.Setup(o => o.AgregarComentario(new Usuario() { }, new Comentario()));

            var configLibro = new LibroController(IDetalleMock.Object, IComentarioMock.Object, ICookieMock.Object);

           // var add = configLibro.AddComentario("Details", );

        }
    }
}
