using Moq;
using NUnit.Framework;
using SimuladorExamenUPN.Controllers;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SimuladorExamenUPNTest.ControllerTest
{
    [TestFixture]
    class HomeControlllerTest
    {
        [Test]
        public void Retorno_Del_Modelo_IndexTest()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now, EstaActivo=true},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now, EstaActivo=true}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Examen>;

            Assert.IsInstanceOf<List<Examen>>(view.Model);
        }
            
        [Test]
        public void ContarExamentesActivos_IndexTest()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now, EstaActivo=true},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now, EstaActivo=false}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Examen>;

            Assert.AreEqual(1, model.Count());
        }
        [Test]
        public void VerificarSiExamenEstaActivo_ConfirmarTest()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now, EstaActivo=true},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now, EstaActivo=true}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.Confirmar(1) as ViewResult;
            var model = view.Model as Examen;

            Assert.AreEqual(true, model.EstaActivo);
        }
        [Test]
        public void ReturnExamen_ConfirmarTest()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now, EstaActivo=true},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now, EstaActivo=true}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.Confirmar(1) as ViewResult;


            Assert.IsInstanceOf<Examen>(view.Model);
        }
        [Test]
        public void ReturnDarExamen_DarExamenTest()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now, EstaActivo=true},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now, EstaActivo=true}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.DarExamen(1) as ViewResult;

            Assert.IsInstanceOf<Examen>(view.Model);
        }
    }
}
