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
    
    public partial class catPermisos
    {
        public int idPermiso { get; set; }
        public string motivoPermiso { get; set; }
        public string observaciones { get; set; }
        public Nullable<System.DateTime> horaSalida { get; set; }
        public Nullable<System.DateTime> horaLlegada { get; set; }
        public Nullable<int> noEmpleado { get; set; }
        public Nullable<bool> autorizado { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
    
        public virtual catEmpleado catEmpleado { get; set; }
    }
}