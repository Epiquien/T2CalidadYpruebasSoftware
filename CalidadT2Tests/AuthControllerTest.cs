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
    public class AuthControllerTest
    {
        [Test]
        public void PruebaLogin1AuthController()
        {
            //AuthController authController = new AuthController( );

            //ViewResult result = authController.Login() as ViewResult;

            //Assert.IsNotNull(result);
        }

        [Test]
        public void UsuarioLograIniciarSesion()
        {
            var usuario = new Usuario();
            usuario.Username = "admin";
            usuario.Password = "admin";

            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.EncontrarUsuario(usuario.Username, usuario.Password)).Returns(usuario);

            var cookMock = new Mock<ICookieAuthService>();
            var authCont = new AuthController(userMock.Object, cookMock.Object);
            var log = authCont.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToActionResult>(log);

        }

        [Test]
        public void UsuarioNoIniciaSesion()
        {
            var usuario = new Usuario();
            usuario.Username = "admin";
            usuario.Password = "admin";

            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.EncontrarUsuario(usuario.Username, usuario.Password)).Returns(usuario);

            var cookMock = new Mock<ICookieAuthService>();
            var authCont = new AuthController(userMock.Object, cookMock.Object);
            var log = authCont.Login("Ricardo", "Epiquien");

            Assert.IsInstanceOf<ViewResult>(log);
        }

    }
}
