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
    class ExamenControllerTest
    {
        [Test]
        public void Retorno_Del_Modelo_IndexTest()
        {
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.GetLoggedUser()).Returns(new Usuario {Id=1, Username="admin", Password="admin", Nombres="Administrador" });
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now}
            });

            var controller = new ExamenController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Examen>;

            Assert.IsInstanceOf<List<Examen>>(view.Model);
        }
        [Test]
        public void Cuantos_Examenes_TieneElUsuario()
        {
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.GetLoggedUser()).Returns(new Usuario { Id = 1, Username = "admin", Password = "admin", Nombres = "Administrador" });
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now, EstaActivo=true},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now, EstaActivo=true}
            });

            var controller = new ExamenController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Examen>;

            Assert.AreEqual(1,model.Count());
        }
        [Test]
        public void LaVistaRetornaViewResult_IndexTest()
        {
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.GetLoggedUser()).Returns(new Usuario { Id = 1, Username = "admin", Password = "admin", Nombres = "Administrador" });
            faker.Setup(a => a.ObtenerListaExamenes()).Returns(new List<Examen>
            {
                new Examen{Id=1, TemaId=1, UsuarioId=1, FechaCreacion=DateTime.Now},
                new Examen{Id=2, TemaId=2, UsuarioId=2, FechaCreacion=DateTime.Now}
            });

            var controller = new ExamenController(faker.Object);
            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void LaVistaRetornaViewResult_CrearTest()
        {
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new ExamenController(faker.Object);
            var view = controller.Crear() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void Contenido_DelViewBagTemas_CrearTest()
        {
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new ExamenController(faker.Object);
            var view = controller.Crear() as ViewResult;

            Assert.IsInstanceOf<List<Tema>>(view.ViewBag.Temas);
        }
        [Test]
        public void CuantosTemasContieneElViewBagTemas_CrearTest()
        {
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new ExamenController(faker.Object);
            var view = controller.Crear() as ViewResult;
            var model = view.ViewBag.Temas as List<Tema>;

            Assert.AreEqual(2, model.Count());
        }
        [Test]
        public void CrearExamenEnviandoNull_CrearPostTest()
        {
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });
            var controller = new ExamenController(faker.Object);
            var view = controller.Crear(null,3);

            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void CrearExamen_CrearPostTest()
        {
            var examem = new Examen { Id = 1, TemaId = 1, UsuarioId = 1, FechaCreacion = DateTime.Now };
            var faker = new Mock<IExamenService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });
            faker.Setup(a => a.GenerarPreguntas(1,2)).Returns(new List<Pregunta>
            {
                new Pregunta{Id=1, TemaId=1, Descripcion="Pregunta 1"},
                new Pregunta{Id=2, TemaId=1, Descripcion="Pregunta 2"},
            });
            var controller = new ExamenController(faker.Object);
            var view = controller.Crear(examem, 2);

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
  
    }
}
