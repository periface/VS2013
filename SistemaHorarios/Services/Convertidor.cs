using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHorarios.Services
{
    public class Convertidor
    {
        public string entradasSalidas(DateTime fecha) {
            if (fecha != null)
            {
                return fecha.ToShortTimeString();
            }
            else {
                return "No Determinado";
            }
        }
    }
}