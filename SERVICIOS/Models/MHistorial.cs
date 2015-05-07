using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Models
{
    public class MHistorial
    {
        public int idHistorial{ get;set; }
        public DateTime hraEntrada { get; set; }
        public DateTime? hraSalida { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int noEmpleado { get; set; }
    }
}
