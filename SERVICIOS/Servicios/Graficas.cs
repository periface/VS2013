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
using System.Globalization;
namespace SERVICIOS.Servicios
{
    public class Graficas : IGraficas
    {
        IRepositorioGenerico<catHistorial> _Historial;
        IRepositorioGenerico<catEmpleado> _Empleados;
        IRepositorioGenerico<catPermisos> _Permisos;
        public Graficas(IRepositorioGenerico<catHistorial> _Historial, IRepositorioGenerico<catEmpleado> _Empleados, IRepositorioGenerico<catPermisos> _Permisos)
        {
            this._Historial = _Historial;
            this._Empleados = _Empleados;
            this._Permisos = _Permisos;
        }
        public Graficas()
            : this(new RepositorioGenerico<catHistorial, dbCITEmpleadoEntities>(), new RepositorioGenerico<catEmpleado, dbCITEmpleadoEntities>(), new RepositorioGenerico<catPermisos, dbCITEmpleadoEntities>())
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

        public barModel GraficaRendimientoUsuario(int noEMPLEADO, DateTime? fechaInicio, DateTime? fechaFin)
        {
            //TODO: Simplificar codigo
            var usuario = _Empleados.CargaRegistro(a => a.noEmpleado == noEMPLEADO).SingleOrDefault();
            IEnumerable<catHistorial> registros = _Historial.CargaRegistro();
            registros = registros.Where(a => a.noEmpleado == noEMPLEADO);
            if (fechaFin.HasValue && fechaInicio.HasValue)
            {
                registros = registros.Where(a => a.fechaRegistro >= fechaInicio && a.fechaRegistro <= fechaFin);
            }
            var graficaColumna = new barModel();
            graficaColumna.chart = new chart()
            {
                type = "column",
                zoomType = "xy"
            };

            graficaColumna.title = new title()
            {
                text = "Relación Horas Trabajadas/Horas no Trabajadas -Diarias-",
                align = "Center"
            };


            graficaColumna.xAxis = new xAxis()
            {

                crosshair = true

            };
            graficaColumna.yAxis = new yAxis();

            //XAXIS
            var listaFechas = new List<string>();
            foreach (var item in registros)
            {
                listaFechas.Add(item.fechaRegistro.Value.ToShortDateString());

            }
            graficaColumna.xAxis.categories = listaFechas.ToArray();
            graficaColumna.xAxis.title = new title()
            {
                text = "Fechas",

            };
            //FIN XAXIS ................ Doero De Bitch Na Kanojotachi ...................  

            //YAXIS
            graficaColumna.yAxis.title = new title();
            graficaColumna.yAxis.title.text = "Horas";
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

            List<double> listaValores = new List<double>();
            List<double> listaHorasPermiso = new List<double>();
            var listSeries = new List<series>();

            foreach (var item in registros)
            {

                var _permisos = _Permisos.CargaRegistro(a => a.catEmpleado.noEmpleado == item.noEmpleado);
                var permisos = _permisos.Where(a => a.fechaCreacion.Value.ToShortDateString() == item.fechaRegistro.Value.ToShortDateString());
                if (item.hraSalida.HasValue)
                {
                    double totalHoras = 0;
                    totalHoras = (item.hraSalida.Value - item.hraEntrada.Value).TotalHours;
                    listaValores.Add(totalHoras);
                }
                double totalHorasP = 0;
                foreach (var permiso in permisos)
                {
                    if (permiso.horaLlegada.HasValue)
                    {

                        totalHorasP = (permiso.horaLlegada.Value - permiso.horaSalida.Value).TotalHours;

                    }
                }
                listaHorasPermiso.Add(totalHorasP);
            }
            listSeries.Add(new series
            {

                data = listaValores.ToArray(),
                name = "Horas trabajadas de " + usuario.nomEmpleado + " " + usuario.patEmpleado
            });
            listSeries.Add(new series
            {
                data = listaHorasPermiso.ToArray(),
                name = "Horas no trabajadas de " + usuario.nomEmpleado + " " + usuario.patEmpleado
            });
            //listSeries.Add(new series {
            //    data = new double[] { 8,5 },
            //    name = "Relación Horas Trabajadas, Horas con Permiso"
            //});
            graficaColumna.series = listSeries.ToArray();
            graficaColumna.id = noEMPLEADO;
            return graficaColumna;
        }
        public barModel GraficaPromedioMensual(int noEMPLEADO, DateTime? fechaInicio, DateTime? fechaFin)
        {

            //TODO: Simplificar codigo
            var usuario = _Empleados.CargaRegistro(a => a.noEmpleado == noEMPLEADO).SingleOrDefault();
            IEnumerable<catHistorial> registros = _Historial.CargaRegistro();
            registros = registros.Where(a => a.noEmpleado == noEMPLEADO);
            IEnumerable<catPermisos> permisos = _Permisos.CargaRegistro();
            registros = registros.Where(a => a.noEmpleado == noEMPLEADO);
            CultureInfo ci = new CultureInfo("Es-Es");
            var r = from i in registros
                    group i by ci.DateTimeFormat.GetMonthName(i.fechaRegistro.Value.Month).ToString() + " " + i.fechaRegistro.Value.Year.ToString() into grp
                    select new
                    {
                        mes = grp.Key,
                        prom = grp.Sum(c => (c.hraSalida.Value - c.hraEntrada.Value).TotalHours) / grp.Count()
                    };
            var rNo = from i in permisos
                      group i by ci.DateTimeFormat.GetMonthName(i.fechaCreacion.Value.Month).ToString() into grp
                      select new
                      {
                          mes = grp.Key,
                          prom = grp.Sum(c => (c.horaLlegada.Value - c.horaSalida.Value).TotalHours) / grp.Count()
                      };
            var graficaColumna = new barModel();
            graficaColumna.chart = new chart()
            {
                type = "column",
                zoomType = "xy"
            };

            graficaColumna.title = new title()
            {
                text = "Promedio de Horas Trabajadas -Mensual-",
                align = "Center"
            };


            graficaColumna.xAxis = new xAxis()
            {

                crosshair = true

            };
            graficaColumna.yAxis = new yAxis();

            //XAXIS
            var listaFechas = new List<string>();
            foreach (var item in r)
            {
                listaFechas.Add(item.mes);

            }
            graficaColumna.xAxis.categories = listaFechas.ToArray();
            graficaColumna.xAxis.title = new title()
            {
                text = "Fechas",

            };
            //FIN XAXIS ................ Doero De Bitch Na Kanojotachi ...................  

            //YAXIS
            graficaColumna.yAxis.title = new title();
            graficaColumna.yAxis.title.text = "Horas";
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
            List<double> listaValores = new List<double>();
            List<double> listaValoresNo = new List<double>();
            var listSeries = new List<series>();

            foreach (var item in r)
            {
                if (item.prom != 0)
                {
                    listaValores.Add(item.prom);
                }
            }
            foreach (var item in rNo)
            {
                if (item.prom != 0)
                {
                    listaValoresNo.Add(item.prom);
                }
            }
            listSeries.Add(new series
            {
                data = listaValores.ToArray(),
                name = "Promedio de horas trabajadas de " + usuario.nomEmpleado + " " + usuario.patEmpleado
            });
            listSeries.Add(new series
            {
                data = listaValoresNo.ToArray(),
                name = "Promedio de horas no trabajadas de " + usuario.nomEmpleado + " " + usuario.patEmpleado
            });

            //listSeries.Add(new series {
            //    data = new double[] { 8,5 },
            //    name = "Relación Horas Trabajadas, Horas con Permiso"
            //});
            graficaColumna.series = listSeries.ToArray();
            graficaColumna.id = noEMPLEADO;
            return graficaColumna;

        }
        public barModel GraficaAñoDrill(int noEMPLEADO)
        {
            //TODO: Simplificar codigo
            var usuario = _Empleados.CargaRegistro(a => a.noEmpleado == noEMPLEADO).SingleOrDefault();
            StringBuilder st = new StringBuilder(); 
            IEnumerable<catHistorial> registros = _Historial.CargaRegistro();
            registros = registros.Where(a => a.noEmpleado == noEMPLEADO);
            IEnumerable<catPermisos> permisos = _Permisos.CargaRegistro();
            registros = registros.Where(a => a.noEmpleado == noEMPLEADO);
            CultureInfo ci = new CultureInfo("Es-Es");
            var r = from i in registros
                    group i by i.fechaRegistro.Value.Year.ToString() into grp
                    select new
                    {
                        año = grp.Key,
                        prom = grp.Sum(c => (c.hraSalida.Value - c.hraEntrada.Value).TotalHours) / grp.Count()
                    };
            var rM = from i in registros
                     group i by i.fechaRegistro.Value.Month.ToString() into grp
                     select new
                     {
                         mes = grp.Key,
                         prom = grp.Sum(c => (c.hraSalida.Value - c.hraEntrada.Value).TotalHours) / grp.Count(),
                         año = grp.Sum(c => c.fechaRegistro.Value.Year)
                     };
            var graficaColumna = new barModel();
            graficaColumna.chart = new chart()
            {
                type = "column",
                zoomType = "xy"
            };

            graficaColumna.title = new title()
            {
                text = "Promedio de Horas Trabajadas",
                align = "Center"
            };


            graficaColumna.xAxis = new xAxis()
            {

                crosshair = true

            };
            graficaColumna.yAxis = new yAxis();

            //XAXIS
            var listaFechas = new List<string>();
            foreach (var item in r)
            {
                listaFechas.Add(item.año);

            }
            graficaColumna.xAxis.categories = listaFechas.ToArray();
            graficaColumna.xAxis.title = new title()
            {
                text = "Fechas",

            };
            //FIN XAXIS ................ Doero De Bitch Na Kanojotachi ...................  

            //YAXIS
            graficaColumna.yAxis.title = new title();
            graficaColumna.yAxis.title.text = "Horas";
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

            seriesDataObject listaValores = new seriesDataObject();
            var data = new List<SERVICIOS.HighChartsModel.data>();
            foreach (var item in r)
            {
                if (item.prom != 0)
                {
                    data.Add(new SERVICIOS.HighChartsModel.data()
                    {
                        name = item.año,
                        drilldown = item.año,
                        y = item.prom
                    });
                    listaValores.colorByPoint = true;
                    listaValores.name = "Rendimiento General";
                    listaValores.data = data.ToArray();
                }
                foreach (var itemDr in rM)
                {

                    if (itemDr.prom != 0)
                    {
                        if (item.año.ToString() != itemDr.año.ToString())
                        {
                            st.Append("[{");
                            st.Append(Convert.ToChar(34) + "id" + Convert.ToChar(34) + ":" + Convert.ToChar(34) + (2015).ToString() + Convert.ToChar(34) + ",");
                            st.Append(Convert.ToChar(34)+"data"+Convert.ToChar(34)+": [");
                            st.Append(Convert.ToChar(34) + itemDr.mes + Convert.ToChar(34));
                            st.Append(",");
                            st.Append(itemDr.prom);
                            st.Append("]");
                            st.Append("}]");
                        }

                    }
                }
            }

            graficaColumna.drillDown = st.ToString();
            //listSeries.Add(new series {
            //    data = new double[] { 8,5 },
            //    name = "Relación Horas Trabajadas, Horas con Permiso"
            //});
            graficaColumna.seriesDo = listaValores;
            graficaColumna.id = noEMPLEADO;
            return graficaColumna;
        }
        public barModel GraficaTodosEmpleados()
        {
            barModel graficaColumna = new barModel();
            var usuarios = _Empleados.CargaRegistro();
            var listaCategorias = new List<string>();
            var listaSeries = new List<series>();
            graficaColumna.chart = new chart()
            {
                type = "column",
                zoomType = "xy"
            };
            graficaColumna.title = new title()
            {
                text = "Horas Trabajadas",
                align = "Center"
            };
            graficaColumna.xAxis = new xAxis()
            {
                crosshair = true
            };
            graficaColumna.yAxis = new yAxis();
            graficaColumna.xAxis.title = new title()
            {
                text = "Fechas",
            };
            graficaColumna.yAxis.title = new title();
            graficaColumna.yAxis.title.text = "Horas";
            //FIN YAXIS
            graficaColumna.credits = new credits()
            {
                enabled = false,

            };
            graficaColumna.legend = new legend()
            {

            };
            graficaColumna.plotOptions = new plotOptions();
            graficaColumna.plotOptions.column = new column()
            {
                borderWidth = 0,
                pointPadding = 0.2,

            };
            CultureInfo ci = new CultureInfo("Es-Es");
            var rCategorias = from i in _Historial.CargaRegistro()
                              group i by ci.DateTimeFormat.GetMonthName(i.fechaRegistro.Value.Month).ToString() +" " + i.fechaRegistro.Value.Year.ToString()
                                  into gr
                                  select new
                                  {
                                      mes = gr.Key
                                  };

            foreach (var item in rCategorias)
            {
                listaCategorias.Add(item.mes);

            }
            foreach (var empleado in usuarios)
            {
                var listaValores = new List<double>();
                IEnumerable<catHistorial> historico = _Historial.CargaRegistro(a => a.catEmpleado.id == empleado.id);

                var r = from i in historico
                        where i.hraSalida.HasValue && i.hraEntrada.HasValue
                        group i by ci.DateTimeFormat.GetMonthName(i.fechaRegistro.Value.Month).ToString() into grp
                        select new
                        {
                            mes = grp.Key,
                            horasTrabajadas = historico.Where(a => a.hraSalida.HasValue && a.hraSalida.HasValue && ci.DateTimeFormat.GetMonthName(a.fechaRegistro.Value.Month).ToString() == grp.Key.ToString()).Sum(a => (a.hraSalida.Value - a.hraEntrada.Value).TotalHours)
                        };


                foreach (var item in r)
                {
                    if (item.horasTrabajadas != 0)
                    {
                        listaValores.Add(item.horasTrabajadas);
                    }
                }
                listaSeries.Add(new series()
                {
                    data = listaValores.ToArray(),
                    name = empleado.nomEmpleado
                });

            }
            graficaColumna.xAxis.categories = listaCategorias.ToArray();
            graficaColumna.series = listaSeries.ToArray();
            return graficaColumna;
        }
    }
}
