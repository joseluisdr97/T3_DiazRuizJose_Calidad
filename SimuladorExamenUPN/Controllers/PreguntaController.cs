using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimuladorExamenUPN.Controllers
{
    public class PreguntaController : Controller
    {
        private readonly IPreguntaService service;
        public PreguntaController(IPreguntaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index(int temaId)
        {
            var tema = service.ObtenerListaTemas()
                
                .Where(x => x.Id == temaId)
                .FirstOrDefault();

            return View(tema);
        }

        [HttpGet]
        public ActionResult Crear(int temaId)
        {
            ViewBag.Tema = service.ObtenerListaTemas().Where(a => a.Id == temaId).First();
            return View(new Pregunta());
        }

        [HttpPost]
        public ActionResult Crear(Pregunta pregunta)
        {
            Validar(pregunta);
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = service.ObtenerListaTemas().Where(a => a.Id == pregunta.TemaId).First();
                return View(pregunta);
            }

            service.GuardarPregunta(pregunta);

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var pregunta = service.ObtenerListaPreguntas().Where(a => a.Id == id).First();
            ViewBag.Tema = service.ObtenerListaTemas().Where(a => a.Id == pregunta.TemaId).First();
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Editar(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tema = service.ObtenerListaTemas().Where(a => a.Id == pregunta.TemaId).First();
                return View(pregunta);
            }
            service.Entry(pregunta);

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var pregunta = service.ObtenerListaPreguntas().Where(a => a.Id == id).First();
            service.EliminarPregunta(pregunta);

            return RedirectToAction("Index");
        }



        private void Validar(Pregunta pregunta)
        {
            if (pregunta.Alternativas.Count < 4)
                ModelState.AddModelError("Alternativas", "Las alternativas deben ser al menos 4");

            if (pregunta.Alternativas.Where(o => o.EsCorrecto).Count() == 0)
                ModelState.AddModelError("Alternativas", "Las alternativas deben tener al mensos una respusta correcta");
        }

    }
}