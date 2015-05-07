using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Models
{
    public class MFechaEspecial
    {
        public int id { get; set; }
        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Titulo requerido")]
        public string titulo { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Descripción Requerida")]
        public string descripcion { get; set; }
        /// <summary>
        /// Esta propiedad sera recibia en un formato especial de UNIX
        /// </summary>
        public double inicio { get; set; }
        /// <summary>
        /// Esta propiedad sera recibida en un formato especial de UNIX
        /// </summary>
        public double fin { get; set; }
        public string clase { get; set; }
        [Display(Name = "Esta restricción o fecha especial dura todo el dia")]
        public bool todoElDia { get; set; }
        public int tipo { get; set; }
    }
}
