using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//Servando, no implementes... no funciona :( por ahora
namespace SERVICIOS.ValidacionesPers
{
    public class NombreRepetido : ValidationAttribute
    {
        public string propiedad { get; private set; }
        private SERVICIOS.Servicios.Categoria _c = new SERVICIOS.Servicios.Categoria();
        public NombreRepetido(string propertyName)
        {
            this.propiedad = propertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propiedades = this.propiedad;
            var encontrado = _c.CargarCategorias(a=>a.nomCategoria.ToUpper()== propiedades.ToUpper()).SingleOrDefault();
            if (encontrado != null) {
                return new ValidationResult(validationContext.DisplayName);
            }
            return null;
        }

    }
}
