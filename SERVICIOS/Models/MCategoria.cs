using SERVICIOS.ValidacionesPers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Models
{
    public class MCategoria
    {
        public int idCategoria { get; set; }
        public string nomCategoria { get; set; }
        public TimeSpan hraEntAsignada { get; set; }
        public TimeSpan hraSalAsignada { get; set; }

    }
}
