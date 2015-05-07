using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Models
{
    public class MEmpleado
    {
        [Required(ErrorMessage="Capture el numero de empleado")]
        public int noEmpleado { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        public string nomEmpleado { get; set; }
        [Required(ErrorMessage = "Apellido Paterno Requerido")]
        public string patEmpleado { get; set; }
        [Required(ErrorMessage = "Apellido Materno Requerido")]
        public string matEmpleado { get; set; }
        public int idCategoria { get; set; }
        [Required(ErrorMessage = "Capture las Horas Asignadas")]
        public int noHorasAginadas { get; set; }
        public string id { get; set; }
        public int tipoEmpleado { get; set; }
        public string obtenerNombre() {
            return nomEmpleado + " " + patEmpleado + " " + matEmpleado;
        }
        public int horasTrabajadas(DateTime entrada,DateTime salida) {
            var horas = entrada.Hour - salida.Hour;
            return horas;
        }
    }
}
