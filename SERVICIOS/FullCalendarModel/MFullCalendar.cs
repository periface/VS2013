using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.FullCalendarModel
{
    public class MFullCalendar
    {
        public MFullCalendar()
        {
            ignorarHorario = false;
        }
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string className { get; set; }
        public bool allDay { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string descripcion { get; set; }
        public bool ignorarHorario { get; set; }
    }
}
