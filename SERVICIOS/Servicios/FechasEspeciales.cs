using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SERVICIOS.FullCalendarModel;
using DAL.Repositorios;
using SERVICIOS.Models;
namespace SERVICIOS.Servicios
{
    public class FechasEspeciales : IFechasEspeciales
    {
        IRepositorioGenerico<catFechasEspeciales> _FechasEspeciales;
        public FechasEspeciales(IRepositorioGenerico<catFechasEspeciales> _FechasEspeciales)
        {
            this._FechasEspeciales = _FechasEspeciales;
        }
        public FechasEspeciales()
            : this(new RepositorioGenerico<catFechasEspeciales, dbCITEmpleadoEntities>())
        {

        }

        public void GuardarFecha(MFechaEspecial model)
        {

            var nuevaFecha = new catFechasEspeciales()
            {
                clase = cssClass(model.tipo),
                descripcion = model.descripcion,
                fin = model.fin,
                inicio = model.inicio,
                tipo = model.tipo,
                titulo = model.titulo,
                todoElDia = model.todoElDia,

            };
            _FechasEspeciales.GuardarRegistro(nuevaFecha);
        }

        public void EditarFecha(MFechaEspecial model)
        {
            var original = _FechasEspeciales.CargaRegistro(a => a.id == model.id).SingleOrDefault();
            original.inicio = model.inicio;
            original.fin = model.fin;
            _FechasEspeciales.EditarRegistro(original);
        }

        public void EliminarFecha(MFechaEspecial model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MFullCalendar> CargarFechas()
        {
            var fechas = _FechasEspeciales.CargaRegistro().ToList();
            var listaFechas = new List<MFullCalendar>();
            foreach (var item in fechas)
            {
                //Resuelto error por valor nulo en fechas
                if (item.inicio.HasValue && item.fin.HasValue)
                {
                    var stringFechaInicio = ConvertirDeUnix(item.inicio.Value);
                    var stringFechaFin = ConvertirDeUnix(item.fin.Value);
                    listaFechas.Add(new MFullCalendar()
                    {
                        allDay = item.todoElDia.Value,
                        className = item.clase,
                        end = stringFechaFin.ToString("yyyy-MM-ddTHH:mm:ss"),
                        id = item.id,
                        start = stringFechaInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        title = item.titulo,
                        fechaFin = stringFechaFin,
                        fechaInicio = stringFechaInicio,
                        descripcion = item.descripcion
                    });

                }
                
                
            }
            return listaFechas;
        }

        public IEnumerable<MFullCalendar> CargarFechas(System.Linq.Expressions.Expression<Func<catFechasEspeciales, bool>> expresion)
        {
            var fechas = _FechasEspeciales.CargaRegistro(expresion).ToList();
            var listaFechas = new List<MFullCalendar>();
            foreach (var item in fechas)
            {
                if (item.inicio.HasValue && item.fin.HasValue)
                {
                    var stringFechaInicio = ConvertirDeUnix(item.inicio.Value);
                    var stringFechaFin = ConvertirDeUnix(item.fin.Value);
                    listaFechas.Add(new MFullCalendar()
                    {
                        allDay = item.todoElDia.Value,
                        className = item.clase,
                        end = stringFechaFin.ToString("yyyy-MM-ddTHH:mm:ss"), //Formato obligatorio para full calendar
                        id = item.id,
                        start = stringFechaInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        title = item.titulo,
                        fechaFin = stringFechaFin,
                        fechaInicio = stringFechaInicio,
                        descripcion = item.descripcion,
                    });
                }
            }
            return listaFechas;
        }

        public DateTime ConvertirDeUnix(double unixTimeStamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddMilliseconds(unixTimeStamp);
        }
        public double ConvertirDeFechaAUnix(DateTime fecha)
        {
            double unixTimestamp = (double)(fecha.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalMilliseconds;
            return unixTimestamp;
        }
        public string cssClass(int tipo)
        {
            if (tipo == 1)
            {
                return "diaFestivo";
            }
            if (tipo == 2)
            {
                return "laborForzosa";
            }
            if (tipo == 3)
            {
                return "noPermisos";
            }
            return null;
        }






    }
}
