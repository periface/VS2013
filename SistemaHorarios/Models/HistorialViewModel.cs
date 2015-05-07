using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHorarios.Models
{
    public class HistorialViewModel
    {
        public int idHistorial { get; set; }
        public string horaEntrada { get; set; }
        public string horaSalida { get; set; }
        public string fecha { get; set; }
        public int noEmpleado { get; set; }

    }
}