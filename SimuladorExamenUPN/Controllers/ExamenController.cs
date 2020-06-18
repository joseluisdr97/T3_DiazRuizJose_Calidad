using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SimuladorExamenUPN.Interfaces;

namespace SimuladorExamenUPN.Controllers
{
    [Authorize]
    public class ExamenController : Controller
    {
        private readonly IExamenService service;
        public ExamenController(IExamenService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Usuario logged = service.GetLoggedUser();
            var examenes = service.ObtenerListaExamenes()
                .Where(o => o.UsuarioId == logged.Id)
                .ToList();
            return View(examenes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Temas = service.ObtenerListaTemas();
            return View(new Examen());
        }

        [HttpPost]
        public ActionResult Crear(Examen examen, int nroPreguntas)
        {
            if (ModelState.IsValid && examen!=null)
            {
                examen.EstaActivo = true;
                service.GuardarExamen(examen);
                List<Pregunta> preguntas = service.GenerarPreguntas(examen.TemaId, nroPreguntas);
                
                service.GuardarPreguntas(examen, preguntas);
                return RedirectToAction("Index");
            }

            ViewBag.Temas = service.ObtenerListaTemas().ToList();
            return View(examen);
        }
    }
}
