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
    public class PreguntaService: IPreguntaService
    {
        private SimuladorContext conexion;

        public PreguntaService()
        {
            this.conexion = new SimuladorContext();
        }

        public List<Tema> ObtenerListaTemas()
        {
            return conexion.Temas
                .Include(o => o.Preguntas.Select(x => x.Alternativas))
                .ToList();
        }
        public void GuardarPregunta(Pregunta pregunta)
        {
            conexion.Preguntas.Add(pregunta);
            conexion.SaveChanges();
        }
        public List<Pregunta> ObtenerListaPreguntas()
        {
            return conexion.Preguntas.ToList();
        }
        public void Entry(Pregunta pregunta)
        {
            conexion.Entry(pregunta).State = EntityState.Modified;
            conexion.SaveChanges();
        }
        public void EliminarPregunta(Pregunta pregunta)
        {
            conexion.Preguntas.Remove(pregunta);
            conexion.SaveChanges();
        }
    }
}