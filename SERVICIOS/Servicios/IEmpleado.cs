using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS.Models;
using DAL;
using System.Linq.Expressions;
namespace SERVICIOS.Servicios
{
    public interface IEmpleado
    {
        void GuardarDatosEmpleado(MEmpleado model);
        void EditarEmpleado(MEmpleado model);
        void EliminarEmpleado(MEmpleado model);
        IEnumerable<MEmpleado> CargarEmpleados(Expression<Func<catEmpleado,bool>>expresion);
        IEnumerable<MEmpleado> CargarEmpleados();
    }
}
