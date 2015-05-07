using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class RepositorioGenerico<T,C> : IRepositorioGenerico<T> where T:class where C: dbCITEmpleadoEntities, new()
    {
        private C _entidades = new C();
        public C _contexto
        {
            get { return _entidades; }
            set { _entidades = value; }
        }


        public void GuardarRegistro(T entidad)
        {
            _contexto.Set<T>().Add(entidad);
            _contexto.SaveChanges();
        }

        public void GuardarVolcado(List<T> entidad)
        {
            foreach (var item in entidad)
            {
                _contexto.Set<T>().Add(item);
            }
            _contexto.SaveChanges();
        }

        public void EditarRegistro(T entidad)
        {
            _entidades.Entry<T>(entidad).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void EliminarRegistro(T entidad)
        {
            _contexto.Set<T>().Remove(entidad);
            _contexto.SaveChanges();
        }


        public IEnumerable<T> CargaRegistro(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            var consulta = _contexto.Set<T>().Where(expression);
            return consulta;
        }


        public IEnumerable<T> CargaRegistro()
        {
            var consulta = _contexto.Set<T>();
            return consulta;
        }
    }
}
