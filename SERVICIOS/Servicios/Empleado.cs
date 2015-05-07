using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICIOS.Models;
using DAL;
using DAL.Repositorios;
using System.Linq.Expressions;
using AutoMapper;
namespace SERVICIOS.Servicios
{
    public class Empleado : IEmpleado
    {
        IRepositorioGenerico<catEmpleado> _Empleados;
        public Empleado(IRepositorioGenerico<catEmpleado>_Empleados)
        {
            this._Empleados = _Empleados;
        }
        public Empleado() : this (new RepositorioGenerico<catEmpleado,dbCITEmpleadoEntities>())
        {
            Mapper.CreateMap<catEmpleado, MEmpleado>();
            Mapper.CreateMap<MEmpleado, catEmpleado>();
        }
        public void GuardarDatosEmpleado(MEmpleado model)
        {

            var nuevosDatos = Mapper.Map<MEmpleado, catEmpleado>(model);
            _Empleados.GuardarRegistro(nuevosDatos);
        }

        public void EditarEmpleado(MEmpleado model)
        {
            var original = _Empleados.CargaRegistro(a=>a.noEmpleado==model.noEmpleado).SingleOrDefault();
            var registroEditado = Mapper.Map(model,original);
            _Empleados.EditarRegistro(registroEditado);
        }

        public void EliminarEmpleado(MEmpleado model)
        {
            var registro = _Empleados.CargaRegistro(a=>a.noEmpleado==model.noEmpleado).SingleOrDefault();
            _Empleados.EliminarRegistro(registro);
        }

        public IEnumerable<MEmpleado> CargarEmpleados(Expression<Func<catEmpleado, bool>> expresion)
        {
            var listaEmpleados = _Empleados.CargaRegistro(expresion);
            var lista = new List<MEmpleado>();
            foreach (var item in listaEmpleados)
            {
                var elemento = Mapper.Map<catEmpleado, MEmpleado>(item);
                lista.Add(elemento);
            }
            return lista;
        }

        public IEnumerable<MEmpleado> CargarEmpleados()
        {
            var listaEmpleados = _Empleados.CargaRegistro();
            var lista = new List<MEmpleado>();
            foreach (var item in listaEmpleados)
            {
                var elemento = Mapper.Map<catEmpleado, MEmpleado>(item);
                lista.Add(elemento);
            }
            return lista;
        }
    }
}
