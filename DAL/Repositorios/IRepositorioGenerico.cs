using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public interface IRepositorioGenerico<T>
    {
        void GuardarRegistro(T entidad);
        void GuardarVolcado(List<T> entidad);
        void EditarRegistro(T entidad);
        void EliminarRegistro(T entidad);
        IEnumerable<T> CargaRegistro();
        IEnumerable<T> CargaRegistro(Expression<Func<T, bool>> expression);
    }
}
