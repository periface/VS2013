using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Models
{
    public class MPermiso
    {
        public int idPermiso { get; set; }
        public string motivoPermiso { get; set; }
        public string observaciones { get; set; }
        public DateTime horaSalida { get; set; }
        public DateTime horaLlegada { get; set; }
        public int noEmpleado { get; set; }
        public bool autorizacion { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
