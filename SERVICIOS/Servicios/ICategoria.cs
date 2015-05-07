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
        void GuardarCategoria(catCategorias model);
        void EditarCategoria(catCategorias model);
        void EliminarCategoria(catCategorias model);
        IEnumerable<MCategoria> CargarCategorias();
        IEnumerable<MCategoria> CargarCategorias(Expression<Func<catCategorias,bool>>expresion);
    }
}
