using SERVICIOS.ValidacionesPers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Models
{
    //Modelo Categoria
    public class MCategoria
    {
        public int idCategoria { get; set; }
        [Required(ErrorMessage="Nombre de categoria requerida")]
        public string nomCategoria { get; set; }
        [Required(ErrorMessage = "Hora de entrada requerida")]
        public TimeSpan hraEntAsignada { get; set; }
        [Required(ErrorMessage = "Hora de salida requerida")]
        public TimeSpan hraSalAsignada { get; set; }

    }
}
