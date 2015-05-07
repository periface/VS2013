using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Models
{
    public class MPermiso
    {
        public MPermiso()
        {
            fechaCreacion = DateTime.Now;
            autorizacion = false;
        }
        public int idPermiso { get; set; }
        [Required(ErrorMessage="Motivo Requerido"),MaxLength(200,ErrorMessage="Maximo 200 caracteres")]
        public string motivoPermiso { get; set; }
        [MaxLength(250, ErrorMessage = "Maximo 250 caracteres")]
        public string observaciones { get; set; }
        [Display(Name="Hora de salida")]
        public DateTime horaSalida { get; set; }
        [Display(Name = "Hora de Llegada")]
        public DateTime? horaLlegada { get; set; }
        public int noEmpleado { get; set; }
        public bool autorizacion { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
