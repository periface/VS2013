using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SERVICIOS.Models;
using SERVICIOS.HighChartsModel;
using DAL.Repositorios;
using AutoMapper;
namespace SERVICIOS.Servicios
{
    public class Graficas : IGraficas
    {
        IRepositorioGenerico<catHistorial> _Historial;
        IRepositorioGenerico<catEmpleado> _Empleados;
        IRepositorioGenerico<catPermisos> _Permisos;
        public Graficas(IRepositorioGenerico<catHistorial> _Historial, IRepositorioGenerico<catEmpleado> _Empleados,IRepositorioGenerico<catPermisos> _Permisos)
        {
            this._Historial = _Historial;
            this._Empleados = _Empleados;
            this._Permisos = _Permisos;
        }
        public Graficas()
            : this(new RepositorioGenerico<catHistorial, dbCITEmpleadoEntities>(), new RepositorioGenerico<catEmpleado, dbCITEmpleadoEntities>(),new RepositorioGenerico<catPermisos,dbCITEmpleadoEntities>())
        {
            Mapper.CreateMap<catHistorial, MHistorial>();
            Mapper.CreateMap<MHistorial, catHistorial>();
        }
        //public barModel GraficaGeneral(DateTime? fechaInicio, DateTime? fechaFin)
        //{
        //    IEnumerable<catEmpleado> empleados = _Empleados.CargaRegistro();
        //    IEnumerable<catHistorial> registros = _Historial.CargaRegistro();
        //    if (fechaFin.HasValue && fechaInicio.HasValue) {
        //        registros = registros.Where(a=>a.fechaRegistro>=fechaInicio && a.fechaRegistro<=fechaFin);
        //    }
        //    var graficaColumna = new barModel();
        //    graficaColumna.chart = new chart() { 
        //        type= "column"
        //    };
        //    graficaColumna.title = new title() { 
        //        text = "Grafica General de Rendimiento",
        //        align = "Center"
        //    };
        //    graficaColumna.xAxis = new xAxis() { 
        //        crosshair = true
        //    };
        //    graficaColumna.yAxis = new yAxis();
        //    var listaFechas = new List<string>();
        //    foreach (var item in registros)
        //    {
        //        listaFechas.Add(item.fechaRegistro.Value.ToShortDateString());
        //    }
        //    graficaColumna.xAxis.categories = listaFechas.ToArray();
        //    graficaColumna.xAxis.title = new title() { 
        //        text = "Fechas"
        //    };
        //    graficaColumna.yAxis.min = 0;
        //    graficaColumna.yAxis.title = new title();
        //    graficaColumna.yAxis.title.text = "Horas Trabajadas";
        //    return graficaColumna;
        //}

        public barModel GraficaRendimientoUsuario(int noEMPLEADO,DateTime? fechaInicio,DateTime? fechaFin)
        {
            //TODO: Simplificar codigo
            var usuario = _Empleados.CargaRegistro(a=>a.noEmpleado==noEMPLEADO).SingleOrDefault();
            IEnumerable<catHistorial> registros = _Historial.CargaRegistro();
            registros = registros.Where(a => a.noEmpleado == noEMPLEADO);
            if (fechaFin.HasValue && fechaInicio.HasValue) {
                registros = registros.Where(a => a.fechaRegistro >= fechaInicio && a.fechaRegistro <= fechaFin);
            }
            var graficaColumna = new barModel();
            graficaColumna.chart = new chart() { 
                type = "column",
                zoomType =  "xy"
            }; 
            
            graficaColumna.title = new title() { 
                text = "Grafica de Horas Trabajadas",
                align = "Center"
            };


            graficaColumna.xAxis = new xAxis() { 
            
            crosshair=true
            
            };
            graficaColumna.yAxis = new yAxis();
           
            //XAXIS
            var listaFechas = new List<string>();
            foreach (var item in registros)
	        {
		            listaFechas.Add(item.fechaRegistro.Value.ToShortDateString());
	        }
            graficaColumna.xAxis.categories = listaFechas.ToArray();
            graficaColumna.xAxis.title = new title() { 
                text = "Fechas",

            };
            //FIN XAXIS ................ Doero De Bitch Na Kanojotachi ...................  

            //YAXIS
            graficaColumna.yAxis.min = 0;
            graficaColumna.yAxis.title = new title();
            graficaColumna.yAxis.title.text = "Horas Trabajadas";
            //FIN YAXIS
            graficaColumna.credits = new credits() { 
            enabled = false,
            
            };
            graficaColumna.legend = new legend() { 
                
            };
            //graficaColumna.tooltip = new tooltip() { 
            //    footerFormat ="<span style='font-size:10px'>{point.key}</span><table>",
            //    headerFormat = "<tr><td style='color:{series.color};padding:0'>{series.name}: </td>"+"<td style='padding:0'><b>{point.y:.1f} mm</b></td></tr>",
            //    pointFormat = "</table>",
            //    shared = true,
            //    useHTML = true
            
            //};
            graficaColumna.plotOptions = new plotOptions();
            graficaColumna.plotOptions.column = new column() { 
                borderWidth = 0,
                pointPadding =0.2,
            
            };

            series[] series = new series[graficaColumna.xAxis.categories.Length];
            series[] seriesPastel = new series[1];
            List<double> listaValores = new List<double>();
            var listSeries = new List<series>();
            foreach (var item in registros)
            {
                if (item.hraSalida.HasValue) {

                    double totalHoras = 0;
                    totalHoras = (item.hraSalida.Value-item.hraEntrada.Value).TotalHours;
                    listaValores.Add(totalHoras);
                }
            }
            listSeries.Add(new series { 
                data = listaValores.ToArray(),
                name = "Rendimiento de "+usuario.nomEmpleado+" "+ usuario.patEmpleado
            });
            //listSeries.Add(new series {
            //    data = new double[] { 8,5 },
            //    name = "Relación Horas Trabajadas, Horas con Permiso"
            //});
            graficaColumna.series = listSeries.ToArray();
            return graficaColumna;
        }


        public barModel GraficaPermisos(int noEMPLEADO, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var usuario = _Empleados.CargaRegistro(a => a.noEmpleado == noEMPLEADO).SingleOrDefault();
            IEnumerable<catPermisos> registros = _Permisos.CargaRegistro();
            registros = registros.Where(a => a.noEmpleado == noEMPLEADO);
            if (fechaFin.HasValue && fechaInicio.HasValue)
            {
                registros = registros.Where(a => a.horaSalida >= fechaInicio && a.horaLlegada <= fechaFin);
            }
            var graficaColumna = new barModel();
            graficaColumna.chart = new chart()
            {
                type = "column",
                zoomType = "xy"
            };

            graficaColumna.title = new title()
            {
                text = "Grafica de Horas en Permiso",
                align = "Center"
            };


            graficaColumna.xAxis = new xAxis()
            {

                crosshair = true

            };
            graficaColumna.yAxis = new yAxis();
            //XAXIS
            var listaFechas = new List<string>();
            foreach (var item in registros.ToList())
            {
                listaFechas.Add(item.fechaCreacion.Value.ToShortDateString());
            }
            var set = new HashSet<string>();
            var duplicados = listaFechas.Where(x => !set.Add(x));
            foreach (var duplicado in duplicados.ToList())
            {
                listaFechas.Remove(duplicado);
            }
            graficaColumna.xAxis.categories = listaFechas.ToArray();
            graficaColumna.xAxis.title = new title()
            {
                text = "Fechas",

            };
            //FIN XAXIS ................ Doero De Bitch Na Kanojotachi ...................  

            //YAXIS
            graficaColumna.yAxis.min = 0;
            graficaColumna.yAxis.title = new title();
            graficaColumna.yAxis.title.text = "Horas no Trabajadas";
            //FIN YAXIS
            graficaColumna.credits = new credits()
            {
                enabled = false,

            };
            graficaColumna.legend = new legend()
            {

            };
            //graficaColumna.tooltip = new tooltip() { 
            //    footerFormat ="<span style='font-size:10px'>{point.key}</span><table>",
            //    headerFormat = "<tr><td style='color:{series.color};padding:0'>{series.name}: </td>"+"<td style='padding:0'><b>{point.y:.1f} mm</b></td></tr>",
            //    pointFormat = "</table>",
            //    shared = true,
            //    useHTML = true

            //};
            graficaColumna.plotOptions = new plotOptions();
            graficaColumna.plotOptions.column = new column()
            {
                borderWidth = 0,
                pointPadding = 0.2,

            };

            series[] series = new series[graficaColumna.xAxis.categories.Length];
            series[] seriesPastel = new series[1];
            
            var listSeries = new List<series>();
            List<double> listaValores = new List<double>();
            foreach (var item in registros)
            {
                if (item.horaLlegada.HasValue)
                {

                    double totalHoras = 0;
                    totalHoras = (item.horaLlegada.Value - item.horaSalida.Value).TotalHours;
                    listaValores.Add(totalHoras);
                }
                
            }
            listSeries.Add(new series
            {
                data = listaValores.ToArray(),
                name = "Rendimiento en este dia"
            });
            //listSeries.Add(new series {
            //    data = new double[] { 8,5 },
            //    name = "Relación Horas Trabajadas, Horas con Permiso"
            //});
            graficaColumna.series = listSeries.ToArray();
            return graficaColumna;
        }
    }
}
