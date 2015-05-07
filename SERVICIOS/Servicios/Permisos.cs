using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositorios;
using SERVICIOS.Models;
using AutoMapper;
namespace SERVICIOS.Servicios
{
    public class Permisos : IPermisos
    {
        IRepositorioGenerico<catPermisos> _Permisos;
        public Permisos(IRepositorioGenerico<catPermisos> _Permisos)
        {
            this._Permisos = _Permisos;
        }
        public Permisos()
            : this(new RepositorioGenerico<catPermisos, dbCITEmpleadoEntities>())
        {
            Mapper.CreateMap<catPermisos, MPermiso>();
            Mapper.CreateMap<MPermiso, catPermisos>();
        }
        public void GuardarPermiso(Models.MPermiso model)
        {
            try
            {

                var nuevoPermiso = Mapper.Map<MPermiso, catPermisos>(model);
                _Permisos.GuardarRegistro(nuevoPermiso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditarPermiso(Models.MPermiso model)
        {
            var original = _Permisos.CargaRegistro(a=>a.idPermiso==model.idPermiso).SingleOrDefault();
            var editado = Mapper.Map(model,original);
            _Permisos.EditarRegistro(editado);
        }

        public void EliminarPermiso(Models.MPermiso model)
        {
            var original = _Permisos.CargaRegistro(a=>a.idPermiso==model.idPermiso).SingleOrDefault();
            _Permisos.EliminarRegistro(original);
        }

        public IEnumerable<Models.MPermiso> CargaPermiso()
        {
            var permisos = new List<MPermiso>();
            var registros = _Permisos.CargaRegistro();
            foreach (var item in registros)
            {
                var reg = Mapper.Map<catPermisos,MPermiso>(item);
                permisos.Add(reg);
            }
            return permisos;
        }

        public IEnumerable<Models.MPermiso> CargaPermiso(System.Linq.Expressions.Expression<Func<DAL.catPermisos, bool>> expression)
        {
            var permisos = new List<MPermiso>();
            var registros = _Permisos.CargaRegistro(expression);
            foreach (var item in registros)
            {
                var reg = Mapper.Map<catPermisos, MPermiso>(item);
                permisos.Add(reg);
            }
            return permisos;
        }
    }
}
