using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS.Models;
using DAL;
using System.Linq.Expressions;
using SERVICIOS.FullCalendarModel;
namespace SERVICIOS.Servicios
{
    public interface IHistorial
    {
        void GuardarHistorial(MHistorial model);
        void EditarHistorial(MHistorial model);
        void EliminarHistorial(MHistorial model);
        IEnumerable<MHistorial> CargaHistorial(Expression<Func<catHistorial,bool>>expression);
        IEnumerable<MHistorial> CargaHistorial();
        IEnumerable<MFullCalendar> CargarFechas();
        IEnumerable<MFullCalendar> CargarFechas(Expression<Func<DAL.catHistorial, bool>> expresion);
    }
}
