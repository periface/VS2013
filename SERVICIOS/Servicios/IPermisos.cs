using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS.Models;
using System.Linq.Expressions;
namespace SERVICIOS.Servicios
{
    public interface IPermisos
    {
        void GuardarPermiso(MPermiso model);
        void EditarPermiso(MPermiso model);
        void EliminarPermiso(MPermiso model);
        IEnumerable<MPermiso> CargaPermiso();
        IEnumerable<MPermiso> CargaPermiso(Expression<Func<DAL.catPermisos,bool>>expression);
    }
}
