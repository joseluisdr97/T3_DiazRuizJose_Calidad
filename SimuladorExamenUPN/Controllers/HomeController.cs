using SimuladorExamenUPN.DB;
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
    public class HomeController : Controller
    {
        private readonly IHomeService service;
        public HomeController(IHomeService service)
        {
            this.service = service;
        }
        SimuladorContext db;
        public ActionResult Index()
        {
            var examenes = service.ObtenerListaExamenes()
                .Where(o => o.EstaActivo == true)
                .ToList();
            return View(examenes);
        }

        public ActionResult Confirmar(int ExamenId)
        {
            var examen = service.ObtenerListaExamenes()
                .Where(o => o.Id == ExamenId)
                .FirstOrDefault();
            return View(examen);
        }

        public ActionResult DarExamen(int ExamenId)
        {
            
            var examen = service.ObtenerListaExamenes().Where(o => o.Id == ExamenId)
                .FirstOrDefault();
            return View(examen);
        }
        
    }
}