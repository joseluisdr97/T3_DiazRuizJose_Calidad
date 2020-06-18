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
    public class HomeService: IHomeService
    {
        private SimuladorContext conexion;

        public HomeService()
        {
            this.conexion = new SimuladorContext();
        }

        public List<Examen> ObtenerListaExamenes()
        {
            return conexion.Examenes.Include(o => o.Tema.Categorias.Select(s => s.Categoria)).Include(o => o.Usuario).Include(o => o.Preguntas.Select(s => s.Pregunta.Alternativas)).ToList();
        }
    }
}