using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS.Models;
using SERVICIOS.FullCalendarModel;
using System.Linq.Expressions;
using DAL;
namespace SERVICIOS.Servicios
{
    public interface IFechasEspeciales
    {
        void GuardarFecha(MFechaEspecial model);
        void EditarFecha(MFechaEspecial model);
        void EliminarFecha(MFechaEspecial model);
        IEnumerable<MFullCalendar> CargarFechas();
        IEnumerable<MFullCalendar> CargarFechas(System.Linq.Expressions.Expression<Func<catFechasEspeciales, bool>> expresion);

    }
}
