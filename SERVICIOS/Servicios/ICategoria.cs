using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SERVICIOS.Models;

namespace SERVICIOS.Servicios
{
    public interface ICategoria
    {
        void GuardarCategoria(MCategoria model);
        void EditarCategoria(MCategoria model);
        void EliminarCategoria(MCategoria model);
        IEnumerable<MCategoria> CargarCategorias();
        IEnumerable<MCategoria> CargarCategorias(Expression<Func<catCategorias,bool>>expresion);
    }
}
