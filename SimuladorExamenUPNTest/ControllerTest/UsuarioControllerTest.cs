using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.Controllers;
using SimuladorExamenUPN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SimuladorExamenUPNTest.ControllerTest
{
    [TestFixture]
    class UsuarioControllerTest
    {
        [Test]
        public void Retorno_Del_Modelo_LoginTest()
        {
            var faker = new Mock<IUsuarioService>();

            var controller = new UsuarioController(faker.Object);
            var view = controller.Login();


            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void Retorno_Del_ModeloEnviandoDatosInvalidos_LoginPostTest()
        {
            var faker = new Mock<IUsuarioService>();

            var controller = new UsuarioController(faker.Object);
            var view = controller.Login("jose","luis");

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void Retorno_Del_ModeloEnviandoDatosValidos_LoginPostTest()
        {
            var faker = new Mock<IUsuarioService>();

            var controller = new UsuarioController(faker.Object);
            var view = controller.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
    }
}
