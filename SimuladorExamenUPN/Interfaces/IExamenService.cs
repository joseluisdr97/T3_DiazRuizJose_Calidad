using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface IExamenService
    {
        Usuario GetLoggedUser();
        List<Examen> ObtenerListaExamenes();
        List<Tema> ObtenerListaTemas();
        void GuardarExamen(Examen examen);
        List<Pregunta> GenerarPreguntas(int tema, int nroPreguntas);
        void GuardarPreguntas(Examen examen, List<Pregunta> preguntas);
    }
}
