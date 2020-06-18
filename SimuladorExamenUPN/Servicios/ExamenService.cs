using SimuladorExamenUPN.DB;
using SimuladorExamenUPN.Interfaces;
using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimuladorExamenUPN.Servicios
{
    public class ExamenService: IExamenService
    {
        private SimuladorContext conexion;

        public ExamenService()
        {
            this.conexion = new SimuladorContext();
        }

        public List<Examen> ObtenerListaExamenes()
        {
            return conexion.Examenes.Include(o => o.Tema).Include(o => o.Preguntas).ToList();
        }

        public Usuario GetLoggedUser()
        {
            return (Usuario)HttpContext.Current.Session["Usuario"];
        }

        public List<Tema> ObtenerListaTemas()
        {
            return conexion.Temas.ToList();
        }
        public void GuardarExamen(Examen examen)
        {
            examen.UsuarioId = GetLoggedUser().Id;
            examen.FechaCreacion = DateTime.Now;
            conexion.Examenes.Add(examen);
            conexion.SaveChanges();
        }

        public List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas)
        {
            var basePreguntas = conexion.Preguntas.Where(o => o.TemaId == tema).ToList();
            return basePreguntas.OrderBy(x => Guid.NewGuid()).Take(nroPreguntas).ToList();
        }

        public void GuardarPreguntas(Examen examen, List<Pregunta> preguntas)
        {
            foreach (var item in preguntas)
            {
                var examenPreguta = new ExamenPregunta();
                examenPreguta.ExamenId = examen.Id;
                examenPreguta.PreguntaId = item.Id;

                conexion.ExamenPreguntas.Add(examenPreguta);

                conexion.SaveChanges();
            }
        }
    }
}