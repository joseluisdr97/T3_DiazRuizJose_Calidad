using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimuladorExamenUPNTest.SeleniumTest
{
    [TestFixture]
    class SeleniumTests
    {
        [Test]
        public void VerificarQueNoIngresoLogin()
        {
            IWebDriver navegador = new FirefoxDriver();

            navegador.Url = "http://localhost:58972/Usuario/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#input1"));
            input1Busqueda.SendKeys("jose");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#input2"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#boton"));
            boton.Click();
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnLogin"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void VerificarQueIngresoLogin()
        {
            IWebDriver navegador = new FirefoxDriver();

            navegador.Url = "http://localhost:58972/Usuario/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#input1"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#input2"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#boton"));
            boton.Click();
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnIndexHome"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void VerificarQueIngresoATema()
        {
            IWebDriver navegador = new FirefoxDriver();

            navegador.Url = "http://localhost:58972/Usuario/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#input1"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#input2"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#boton"));
            boton.Click();
            navegador.FindElement(By.CssSelector("#temaLink")).Click();
            Thread.Sleep(1000);
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnIndexTema"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void IngresoCorrectoTemaCrear()
        {
            IWebDriver navegador = new FirefoxDriver();

            navegador.Url = "http://localhost:58972/Usuario/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#input1"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#input2"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#boton"));
            boton.Click();
            navegador.FindElement(By.CssSelector("#temaLink")).Click();
            Thread.Sleep(1000);
            navegador.FindElement(By.CssSelector("#creartemaLink")).Click();
            Thread.Sleep(1000);
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnCrearTema"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void CrearTemaDatosInvalidos()
        {
            IWebDriver navegador = new FirefoxDriver();

            navegador.Url = "http://localhost:58972/Usuario/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#input1"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#input2"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#boton"));
            boton.Click();
            navegador.FindElement(By.CssSelector("#temaLink")).Click();
            Thread.Sleep(1000);
            navegador.FindElement(By.CssSelector("#creartemaLink")).Click();
            Thread.Sleep(1000);
            navegador.FindElement(By.CssSelector("#btnguardartema")).Click();
            Thread.Sleep(1000);
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnCrearTema"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void CrearTemaDatosValidos()
        {
            IWebDriver navegador = new FirefoxDriver();

            navegador.Url = "http://localhost:58972/Usuario/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#input1"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#input2"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#boton"));
            boton.Click();
            navegador.FindElement(By.CssSelector("#temaLink")).Click();
            Thread.Sleep(1000);
            navegador.FindElement(By.CssSelector("#creartemaLink")).Click();
            Thread.Sleep(2000);

            var input1Busqueda1 = navegador.FindElement(By.CssSelector("#Nombre"));
            input1Busqueda.SendKeys("La primera");
            var input2Busqueda1 = navegador.FindElement(By.CssSelector("#Descripcion"));
            input1Busqueda.SendKeys("dsfhfshfg");

            navegador.FindElement(By.CssSelector("#btnguardartema")).Click();
            Thread.Sleep(1000);
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnIndexTema"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void IngresoATema()
        {
            IWebDriver navegador = new FirefoxDriver();

            navegador.Url = "http://localhost:58972/Usuario/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#input1"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#input2"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#boton"));
            boton.Click();
            navegador.FindElement(By.CssSelector("#temaLink")).Click();
            Thread.Sleep(1000);

            navegador.Url = "http://localhost:58972/Pregunta/Index?temaId=1";

            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnIndexPregunta"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
    }
}
