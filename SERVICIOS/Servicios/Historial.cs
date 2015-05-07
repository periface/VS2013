using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SERVICIOS.Models;
using DAL.Repositorios;
using AutoMapper;
namespace SERVICIOS.Servicios
{
    public class Historial : IHistorial
    {
        IRepositorioGenerico<catHistorial> _Historial;
        public Historial(IRepositorioGenerico<catHistorial> _Historial)
        {
            this._Historial = _Historial;
        }
        public Historial() : this(new RepositorioGenerico<catHistorial,dbCITEmpleadoEntities>())
        {
            Mapper.CreateMap<catHistorial, MHistorial>();
            Mapper.CreateMap<MHistorial, catHistorial>();
        }
        public void GuardarHistorial(MHistorial model)
        {
            try
            {
                var nuevoHistorial = Mapper.Map<MHistorial, catHistorial>(model);
                _Historial.GuardarRegistro(nuevoHistorial);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void EditarHistorial(MHistorial model)
        {
            var original = _Historial.CargaRegistro(a=>a.idHistorial==model.idHistorial).SingleOrDefault();
            if (original != null) {
                var registroEditado = Mapper.Map(model,original);
                _Historial.EditarRegistro(registroEditado);
            }
            return;
        }

        public void EliminarHistorial(MHistorial model)
        {
            var registro = _Historial.CargaRegistro(a => a.idHistorial == model.idHistorial).SingleOrDefault();
            if (registro != null) {

                _Historial.EliminarRegistro(registro);
            }
        }

        public IEnumerable<MHistorial> CargaHistorial(System.Linq.Expressions.Expression<Func<catHistorial, bool>> expression)
        {
            var listaRegistros = _Historial.CargaRegistro(expression);
            var lista = new List<MHistorial>();
            foreach (var item in listaRegistros)
            {
                var elemento = Mapper.Map<catHistorial, MHistorial>(item);
                lista.Add(elemento);
            }
            return lista;
        }

        public IEnumerable<MHistorial> CargaHistorial()
        {
            var listaRegistros = _Historial.CargaRegistro();
            var lista = new List<MHistorial>();
            foreach (var item in listaRegistros)
            {
                var elemento = Mapper.Map<catHistorial, MHistorial>(item);
                lista.Add(elemento);
            }
            return lista;
        }


        public IEnumerable<FullCalendarModel.MFullCalendar> CargarFechas()
        {
            var listaRegistros = _Historial.CargaRegistro();
            var lista = new List<FullCalendarModel.MFullCalendar>();
            foreach (var item in listaRegistros)
            {
                //Arreglado error de fecha nula 7-05-15
                if (item.hraEntrada.HasValue && item.hraSalida.HasValue) {

                    lista.Add(new FullCalendarModel.MFullCalendar
                    {
                        start = item.hraEntrada.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                        end = item.hraSalida.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                        title = item.catEmpleado.nomEmpleado,
                    });
                }
            }
            return lista;
        }

        public IEnumerable<FullCalendarModel.MFullCalendar> CargarFechas(System.Linq.Expressions.Expression<Func<catHistorial, bool>> expresion)
        {
            var listaRegistros = _Historial.CargaRegistro(expresion);
            var lista = new List<FullCalendarModel.MFullCalendar>();
            foreach (var item in listaRegistros)
            {
                //Arreglado error de fecha nula 7-05-15
                if (item.hraEntrada.HasValue && item.hraSalida.HasValue)
                {

                    lista.Add(new FullCalendarModel.MFullCalendar
                    {
                        start = item.hraEntrada.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                        end = item.hraSalida.Value.ToString("yyyy-MM-ddTHH:mm:ss"),
                        title = item.catEmpleado.nomEmpleado,
                    });
                }
            }
            return lista;
        }
    }
}
