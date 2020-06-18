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
    class PreguntaControllerTest
    {
        [Test]
        public void Retorno_Del_Modelo_IndexTest()
        {
            var faker = new Mock<IPreguntaService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new PreguntaController(faker.Object);
            var view = controller.Index(1) as ViewResult;


            Assert.IsInstanceOf<Tema>(view.Model);
        }
        [Test]
        public void ObtenerNombreDelTemaSolicitado_IndexTest()
        {
            var faker = new Mock<IPreguntaService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new PreguntaController(faker.Object);
            var view = controller.Index(1) as ViewResult;
            var model = view.Model as Tema;

            Assert.AreEqual("La guerra",model.Nombre);
        }
        [Test]
        public void RwturnCrearPregunta_CrearTest()
        {
            var faker = new Mock<IPreguntaService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new PreguntaController(faker.Object);
            var view = controller.Crear(1);

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void ReturnViewBagTema_CrearTest()
        {
            var faker = new Mock<IPreguntaService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new PreguntaController(faker.Object);
            var view = controller.Crear(1) as ViewResult;

            Assert.IsInstanceOf<Tema>(view.ViewBag.Tema);
        }
        [Test]
        public void CrearPreguntaEnviandoIncorrecto_CrearTest()
        {
            var pregunta = new Pregunta { Id = 1, TemaId = 1, Descripcion = "Pregunta1" };
            var alternativas = new List<Alternativa>
            {
                new Alternativa{Id=1, PreguntaId=1, EsCorrecto=true, Descripcion="Alternativa 1"},
                new Alternativa{Id=2, PreguntaId=1, EsCorrecto=false, Descripcion="Alternativa 2"},
                new Alternativa{Id=3, PreguntaId=1, EsCorrecto=false, Descripcion="Alternativa 3"}
            };
            pregunta.Alternativas = alternativas;
            var faker = new Mock<IPreguntaService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new PreguntaController(faker.Object);
            var view = controller.Crear(pregunta);

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void CrearPreguntaEnviandoCorrecto_CrearTest()
        {
            var pregunta = new Pregunta { Id = 1, TemaId = 1, Descripcion = "Pregunta1" };
            var alternativas = new List<Alternativa>
            {
                new Alternativa{Id=1, PreguntaId=1, EsCorrecto=true, Descripcion="Alternativa 1"},
                new Alternativa{Id=2, PreguntaId=1, EsCorrecto=false, Descripcion="Alternativa 2"},
                new Alternativa{Id=3, PreguntaId=1, EsCorrecto=false, Descripcion="Alternativa 3"},
                new Alternativa{Id=3, PreguntaId=1, EsCorrecto=false, Descripcion="Alternativa 3"},
                new Alternativa{Id=3, PreguntaId=1, EsCorrecto=false, Descripcion="Alternativa 3"}
            };
            pregunta.Alternativas = alternativas;
            var faker = new Mock<IPreguntaService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new PreguntaController(faker.Object);
            var view = controller.Crear(pregunta);

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }

        [Test]
        public void EditarPostDatosInvalidos_EditarTest()
        {
            var pregunta = new Pregunta { Id = 1, TemaId = 1, Descripcion = "Pregunta1" };
            var alternativas = new List<Alternativa>
            {
                new Alternativa{Id=1, PreguntaId=1, EsCorrecto=true, Descripcion="Alternativa 1"},
                new Alternativa{Id=2, PreguntaId=1, EsCorrecto=false, Descripcion="Alternativa 2"}
            };
            pregunta.Alternativas = alternativas;
            var faker = new Mock<IPreguntaService>();
            faker.Setup(a => a.ObtenerListaTemas()).Returns(new List<Tema>
            {
                new Tema{Id=1, Nombre="La guerra", Descripcion="Esta guerra se dio en el año 2000"},
                new Tema{Id=2, Nombre="La guerra1", Descripcion="Esta guerra se dio en el año 2001"}
            });

            var controller = new PreguntaController(faker.Object);
            var view = controller.Editar(pregunta);

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
    }
}
