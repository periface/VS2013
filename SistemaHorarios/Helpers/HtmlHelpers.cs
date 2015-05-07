using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
namespace SistemaHorarios.Helpers
{
    public static class HtmlHelpers
    {
        /// <summary>
        /// Crea un menu dependiendo del tipo de usuario que este accediendo a la aplicación.
        /// Contiene un div contenedor y dentro de el una lista de url.
        /// Estructura div - > multiple a -> /div
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="user"></param>
        /// <param name="divClass"></param>
        /// <param name="hrefClass"></param>
        /// <returns></returns>
        public static MvcHtmlString MenuOpciones(this HtmlHelper helper, IPrincipal user, string divClass, string hrefClass)
        {
            if (user == null) return null;
            StringBuilder menu = new StringBuilder();
            if (user.IsInRole("Administrador"))
            {
                menu = new generadores().adminHtmlMenuGenerador(divClass, hrefClass);
            }
            else
            {
                menu = new generadores().usuarioHtmlMenuGenerador(divClass, hrefClass);
            }
            return MvcHtmlString.Create(menu.ToString());
        }
        public static MvcHtmlString MenuConfiguracion(this HtmlHelper helper, IPrincipal user)
        {
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            StringBuilder menu = new StringBuilder();
            menu = new generadores().adminHtmlConfigMenuGenerador(urlHelper,user);
            return MvcHtmlString.Create(menu.ToString()); //TODO: Implementar al volver

        }
        public static MvcHtmlString TablaReporte(this HtmlHelper helper, IEnumerable<SERVICIOS.Models.MHistorial> historial, IPrincipal user, string trClass = "")
        {
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            StringBuilder tabla = new StringBuilder();
            tabla = new generadores().admTablaGenerador(historial, urlHelper);
            return new MvcHtmlString(tabla.ToString());
        }

    }
    /// <summary>
    /// Helpers.... para los helpers
    /// </summary>
    public class generadores
    {
        private SERVICIOS.Servicios.Categoria _Categoria = new SERVICIOS.Servicios.Categoria();
        private SERVICIOS.Servicios.Empleado _Empleado = new SERVICIOS.Servicios.Empleado();
        public StringBuilder adminHtmlConfigMenuGenerador(UrlHelper url, IPrincipal user)
        {
            StringBuilder menu = new StringBuilder();
            /*
             <a class="btn btn-primary" href="@Url.Action("CategoriasEmpleados","Configuracion")">Configurar Categorias</a>
             <a class="btn btn-primary" href="@Url.Action("Permisos","Account")">Configurar Administradores</a>
             <a class="btn btn-primary" href="@Url.Action("ConfigDiasFestivos", "Configuracion")">Configurar Dias Festivos</a>
             <a class="btn btn-primary" href="@Url.Action("EditarUsuarios","Account")">Edición de Usuarios</a>
             <a class="btn btn-warning" href="@Url.Action("EditarHistorial", "Configuracion")">Editar Historial</a>
             <a class="btn btn-warning" href="@Url.Action("EditarPermisos", "Configuracion")">Editar Permisos de Salida</a>
             
             */
            if (user.IsInRole("Administrador")||user.IsInRole("PermisoConfig"))
            {
                menu.Append("<div class='row'>");
                menu.Append("<div class='col-lg-2'> <a class='btn btn-block btn-primary' href=" + url.Action("CategoriasEmpleados", "Configuracion") + ">Configurar Categorias</a></div>");
                menu.Append("<div class='col-lg-2'><a class='btn btn-block btn-primary' href=" + url.Action("Permisos", "Account") + ">Permisos Usuarios</a></div>");
                menu.Append("<div class='col-lg-2'><a class='btn btn-block btn-primary' href=" + url.Action("ConfigDiasFestivos", "Configuracion") + ">Config dias especiales</a></div>");
                menu.Append("<div class='col-lg-2'><a class='btn btn-block btn-primary' href=" + url.Action("EditarUsuarios", "Account") + ">Edición de Usuarios</a></div>");
                if (user.IsInRole("Administrador"))
                {
                    menu.Append("<div class='col-lg-2'><a class='btn btn-block btn-warning' href=" + url.Action("EditarHistorial", "Configuracion") + ">Editar Historial</a></div>");
                    menu.Append("<div class='col-lg-2'><a class='btn btn-block btn-warning' href=" + url.Action("EditarPermisos", "Configuracion") + ">Editar Permisos</a></div>");

                }
                menu.Append("</div>");
            }

            return menu;
        }
        public StringBuilder adminHtmlMenuGenerador(string divClass, string hrefClass)
        {


            StringBuilder htmlString = new StringBuilder();
            htmlString.Append("<div class='" + divClass + "'>");
            htmlString.Append("<a class='" + hrefClass + "' id='miHistLink' href='#'>Mi Historial</a>");
            htmlString.Append("<a class='" + hrefClass + "' id='capDatos' href='#'>Capturar mis datos</a>");
            htmlString.Append("<a class='" + hrefClass + "' id='agePerm' href='#'>Agendar Permiso de Salida</a>");
            htmlString.Append("<a class='" + hrefClass + "' id='histLink' href='#'>Historial de Usuarios</a>");
            htmlString.Append("<a class='" + hrefClass + "'id='repLink' href='#'>Reportes Graficos</a>");
            htmlString.Append("</div>");
            return htmlString;
        }
        public StringBuilder usuarioHtmlMenuGenerador(string divClass, string hrefClass)
        {
            StringBuilder htmlString = new StringBuilder();
            htmlString.Append("<div class='" + divClass + "'>");
            htmlString.Append("<a class='" + hrefClass + "' id='miHistLink' href='#'>Mi Historial</a>");
            htmlString.Append("<a class='" + hrefClass + "' id='capDatos' href='#'>Capturar mis datos</a>");
            htmlString.Append("<a class='" + hrefClass + "' id='agePerm' href='#'>Agendar Permiso de Salida</a>");
            htmlString.Append("</div>");
            return htmlString;
        }
        public StringBuilder admTablaGenerador(IEnumerable<SERVICIOS.Models.MHistorial> historial, UrlHelper Url)
        {
            StringBuilder htmlString = new StringBuilder();
            foreach (var item in historial)
            {
                var empleado = _Empleado.CargarEmpleados(a => a.noEmpleado == item.noEmpleado).SingleOrDefault();
                var categoria = _Categoria.CargarCategorias(a => a.idCategoria == empleado.tipoEmpleado).SingleOrDefault();
                htmlString.Append("<tr>");

                htmlString.Append("<td>");
                htmlString.Append("<a href=" + Url.Action("Usuario", "PanelControl", new { id = item.noEmpleado }) + " data-id=" + item.noEmpleado + ">" + item.noEmpleado + "</a>");
                htmlString.Append("</td>");


                htmlString.Append("<td>");

                htmlString.Append(item.hraEntrada.ToShortDateString() + " " + item.hraEntrada.ToShortTimeString());
                htmlString.Append("</td>");

                htmlString.Append("<td>");





                if (item.hraSalida.HasValue)
                {
                    if (item.hraSalida.Value.Day > categoria.hraSalAsignada.Days && item.hraSalida.Value.Date > item.fechaRegistro)
                    {
                        htmlString.Append("<a class='label label-danger'>" + item.hraSalida.Value.ToShortDateString() + " " + item.hraSalida.Value.ToShortTimeString() + " El usuario no agendo su salida a tiempo</a>");

                    }
                    else
                    {
                        htmlString.Append("<a class='label label-danger'>" + item.hraSalida.Value.ToShortDateString() + " " + item.hraSalida.Value.ToShortTimeString());
                    }

                }
                else
                {
                    htmlString.Append("<a class='label label-danger'>No definida</a>");
                }
                htmlString.Append("</td>");


                htmlString.Append("<td>");
                htmlString.Append(item.fechaRegistro.ToShortDateString());
                htmlString.Append("</td>");

                htmlString.Append("<td>");
                htmlString.Append("<p>" + (item.hraSalida.HasValue ? CalcTiempo(item.hraSalida.Value, item.hraEntrada).ToString() : "No hay hora de salida") + "</p>");
                htmlString.Append("</td>");

                htmlString.Append("<td>");
                htmlString.Append("<a href='#' class='btn btn-primary permisos' data-loading-text='Cargando Permisos...' data-id=" + item.noEmpleado + " data-fecha=" + item.fechaRegistro + ">Ver Permisos</a>");
                htmlString.Append("</td>");


                htmlString.Append("</tr>");
            }
            return htmlString;
        }
        public string CalcTiempo(DateTime x, DateTime y)
        {
            var horas = (x - y).TotalHours;
            horas = Math.Round(horas, 2, MidpointRounding.ToEven);
            var thoras = TimeSpan.FromHours((double)horas);
            return thoras.ToString();
        }
    }
}