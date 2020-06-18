using SimuladorExamenUPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Interfaces
{
    public interface IPreguntaService
    {
        List<Tema> ObtenerListaTemas();
        void GuardarPregunta(Pregunta pregunta);
        List<Pregunta> ObtenerListaPreguntas();
        void Entry(Pregunta pregunta);
        void EliminarPregunta(Pregunta pregunta);
    }
}
