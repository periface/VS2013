//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class catCategorias
    {
        public catCategorias()
        {
            this.catEmpleado = new HashSet<catEmpleado>();
        }
    
        public int idCategoria { get; set; }
        public string nomCategoria { get; set; }
        public Nullable<System.TimeSpan> hraEntAsignada { get; set; }
        public Nullable<System.TimeSpan> hraSalAsignada { get; set; }
    
        public virtual ICollection<catEmpleado> catEmpleado { get; set; }
    }
}
