﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SERVICIOS.Models;
using SERVICIOS.Servicios;
using Microsoft.AspNet.Identity;
namespace SistemaHorarios.Controllers
{
    [Authorize]
    public class PanelControlController : Controller
    {
        private Historial _Historial = new Historial();
        private Empleado _Empleado = new Empleado();
        private Categoria _Categoria = new Categoria();
        private FechasEspeciales _Fechas = new FechasEspeciales();
        private Permisos _Permisos = new Permisos();
        private Graficas _Graficas = new Graficas();
        //
        // GET: /PanelControl/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Historial()
        {
            var model = _Historial.CargaHistorial();
            return View(model);
        }
        public ActionResult Usuarios()
        {
            //TODO
            return View();
        }

        public ActionResult Usuario(int id)
        {
            if (!User.IsInRole("Administrador"))
            {
                var empleado = _Empleado.CargarEmpleados(a => a.noEmpleado == id).SingleOrDefault();
                var idAsp = User.Identity.GetUserId();
                var empleadoAsp = _Empleado.CargarEmpleados(a => a.AspNetUsers.Id == idAsp).SingleOrDefault();
                if (CheckEmpleado(empleado, empleadoAsp))
                {

                    var historial = _Historial.CargaHistorial(a => a.noEmpleado == empleado.noEmpleado);
                    HorasTrabajadas(empleado, historial);
                    return View(empleado);
                }
                else
                {
                    ViewBag.error = "No esta autorizado a ver información de usuarios";
                    return View("Error");
                }
            }
            else
            {
                var empleado = _Empleado.CargarEmpleados(a => a.noEmpleado == id).SingleOrDefault();
                if (empleado != null)
                {

                    var historial = _Historial.CargaHistorial(a => a.noEmpleado == empleado.noEmpleado);
                    HorasTrabajadas(empleado, historial);
                    return View(empleado);
                }

            }

            return HttpNotFound();
        }
        public ActionResult Reportes()
        {
            //TODO
            return View();
        }

        [HttpPost]
        ///Funcion AJAX
        public ActionResult Filtrar(DateTime? fechaInicio, DateTime? fechaFin, string usuario)
        {
            if (Request.IsAjaxRequest())
            {
                IEnumerable<MHistorial> model;
                model = _Historial.CargaHistorial();
                if (!string.IsNullOrEmpty(usuario))
                {
                    ViewBag.id = usuario;
                    model = _Historial.CargaHistorial(a => a.catEmpleado.noEmpleado.ToString() == usuario
                        || a.catEmpleado.nomEmpleado.ToUpper() == usuario.ToUpper());
                }
                else
                {
                    model = _Historial.CargaHistorial();
                }
                if (fechaInicio == null || fechaInicio == null)
                {
                    var query = model;
                    return PartialView("tabla", query);

                }
                else
                {
                    var query = model.Where(a => a.fechaRegistro >= fechaInicio && a.fechaRegistro <= fechaFin);
                    return PartialView("tabla", query);
                }

            }
            else
            {
                return PartialView("tabla");
            }
        }
        public ActionResult Permisos(DateTime? fecha, int id)
        {
            //TODO Vista parcial de los permisos agendados, en un modal (posibles acciones adicionales dentro del mismo)
            var permisos = _Permisos.CargaPermiso(a => a.noEmpleado == id);
            var permisosActual = permisos.Where(a => a.horaSalida.ToShortDateString() == fecha.Value.ToShortDateString());
            return View(permisosActual);
        }
        public ActionResult CerrarPermiso(int idPermiso)
        {
            if (Request.IsAjaxRequest())
            {
                var permiso = _Permisos.CargaPermiso(a => a.idPermiso == idPermiso).SingleOrDefault();
                permiso.horaLlegada = DateTime.Now;
                _Permisos.EditarPermiso(permiso);
                return JavaScript("permisoCerrado();");
            }
            return JavaScript("errorCerrar();");
        }
        public ActionResult CapturarDatos()
        {
            var id = User.Identity.GetUserId();
            var empleado = _Empleado.CargarEmpleados(a => a.AspNetUsers.Id == id);
            var lista = _Categoria.CargarCategorias().OrderBy(r => r.nomCategoria).ToList().Select(rr => new SelectListItem { Value = rr.idCategoria.ToString(), Text = rr.nomCategoria });
            ViewBag.tipos = lista;
            if (empleado != null)
            {
                return View(empleado.SingleOrDefault());
            }
            return View();
        }
        [HttpPost]
        public ActionResult CapturarDatos(FormCollection forms, MEmpleado model)
        {
            model.id = User.Identity.GetUserId();
            var originalUser = _Empleado.CargarEmpleados(a => a.noEmpleado == model.noEmpleado);
            if (originalUser.SingleOrDefault() != null)
            {
                _Empleado.EditarEmpleado(model);
            }
            else
            {
                _Empleado.GuardarDatosEmpleado(model);
            }
            return RedirectToAction("Index"); //Redireccionamos al inicio para renderizar la vista de datos del usuario
        }
        public ActionResult MiHistorial()
        {
            var id = User.Identity.GetUserId();
            var historial = _Historial.CargaHistorial(a => a.catEmpleado.AspNetUsers.Id == id);
            return View(historial);
        }

        public ActionResult Perfil()
        {
            var id = User.Identity.GetUserId();
            var perfil = _Empleado.CargarEmpleados(a => a.AspNetUsers.Id == id).SingleOrDefault();
            if (perfil != null)
            {
                return View(perfil);
            }
            return View();
        }
        public ActionResult FormCalendario(string id)
        {
            if (id != "undefined")
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ViewBag.id = id;
                }
            }
            return View();
        }
        //TODO: Funcion con solo fechas de historial
        public ActionResult Calendario(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var historial = _Historial.CargarFechas();
                return Json(historial, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int numero;
                var result = int.TryParse(id, out numero);
                if (result)
                {
                    var historial = _Historial.CargarFechas(a => a.noEmpleado == numero || a.catEmpleado.nomEmpleado == id);
                    return Json(historial, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var historial = _Historial.CargarFechas(a => a.catEmpleado.nomEmpleado == id);
                    return Json(historial, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult EntradaSalida(int id /*Numero de empleado*/)
        {

            //TODO: Simplificar esta acción
            var nuevoHistorial = new MHistorial()
            {
                fechaRegistro = DateTime.Now,
                hraEntrada = DateTime.Now,
                noEmpleado = id,
                hraSalida = null
            };
            var actual = DateTime.Now.ToShortDateString();
            var historial = _Historial.CargaHistorial(a => a.noEmpleado == id);
            var empleado = _Empleado.CargarEmpleados(e => e.noEmpleado == id).SingleOrDefault();
            var categoria = _Categoria.CargarCategorias(a => a.idCategoria == empleado.tipoEmpleado).SingleOrDefault();
            var registro = historial.Where(a => a.fechaRegistro.ToShortDateString() == actual);
            string script = validacionFechas(nuevoHistorial, historial, empleado, categoria, registro);
            return JavaScript(script);
        }
        public ActionResult Salida(int id)
        {
            //TODO: Simplificar esta acción
            var actual = DateTime.Now.ToShortDateString();
            var historial = _Historial.CargaHistorial(a => a.noEmpleado == id);
            var registro = historial.Where(a => a.fechaRegistro.ToShortDateString() == actual).SingleOrDefault();
            var empleado = _Empleado.CargarEmpleados(e => e.noEmpleado == id).SingleOrDefault();
            var categoria = _Categoria.CargarCategorias(a => a.idCategoria == empleado.tipoEmpleado).SingleOrDefault();
            if (registro != null)
            {

                //Patron de inyeccion de dependencias (SOLUCIONA: NO HACER LLAMADAS A LA BASE DE DATOS DENTRO DEL HELPER)
                if (YaChecoSalida(empleado, historial.ToList(), categoria.hraEntAsignada, categoria.hraSalAsignada))
                {
                    return JavaScript("existeSalida()");
                }
                registro.hraSalida = DateTime.Now;
                _Historial.EditarHistorial(registro);
                return JavaScript("checkadoSalida()");
            }
            return JavaScript("noRegistroEntrada()");
        }
        [HttpGet]
        public ActionResult DetalleFecha(int id)
        {
            var detalle = _Fechas.CargarFechas(a => a.id == id).SingleOrDefault();
            if (detalle != null)
            {
                return View(detalle);
            }
            ViewBag.error = "No se encontro la fecha seleccionada";
            return View("ErrorNoLayout");
        }
        public ActionResult AgendarPermiso()
        {
            if (permitePermisos())
            {
                var id = User.Identity.GetUserId();
                var empleado = _Empleado.CargarEmpleados(a => a.AspNetUsers.Id == id).SingleOrDefault();
                if (empleado == null) { ViewBag.error = "No ha capturado los datos de el usuario ó este usuario no fue encontrado"; return View("ErrorNoLayout"); }
                if (hayPermisosAbiertos(empleado.noEmpleado))
                {
                    ViewBag.error = "Usted tiene un permiso pendiente";
                    return PartialView("ErrorNoLayout");
                }
                return View();
            }
            else
            {
                ViewBag.error = "Este dia no se permiten permisos";
                return PartialView("ErrorNoLayout");
            }
        }
        [HttpPost]
        public ActionResult AgendarPermiso(MPermiso model)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    var id = User.Identity.GetUserId();
                    var empleado = _Empleado.CargarEmpleados(a => a.AspNetUsers.Id == id).SingleOrDefault();
                    model.noEmpleado = empleado.noEmpleado;
                    model.autorizacion = false;
                    _Permisos.GuardarPermiso(model);
                    ViewBag.exito = "Permiso agendado correctamente";
                    return PartialView("ExitoNoLayout");
                }
            }
            return View();
        }
        #region Helpers
        /// <summary>
        /// Genera un viewbag con el numero total de horas trabajadas
        /// </summary>
        /// <param name="empleado"></param>
        public void HorasTrabajadas(MEmpleado empleado, IEnumerable<MHistorial> historial)
        {
            if (empleado != null)
            {
                double acumulador = 0;
                foreach (var registro in historial)
                {
                    if (registro.hraSalida.HasValue)
                    {
                        var horas = (registro.hraSalida.Value - registro.hraEntrada).TotalHours;
                        acumulador = acumulador + horas;
                    }

                }

                ViewBag.horasTrabajadas = acumulador;

            }
        }
        /// <summary>
        /// Revisa si el usuario ya checo la entrada del centro esto mediante la consulta de su hora de entrada y su hora de salida
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool YaChecoEntrada(MEmpleado empleado, List<MHistorial> registros, TimeSpan? horaEntrada, TimeSpan? horaSalida)
        {
            IEnumerable<MHistorial> historial = null;
            MHistorial registro = null;
            if (registros != null)
            {

                if (registros.Count > 0)
                {
                    historial = registros.Where(a => a.noEmpleado == empleado.noEmpleado);
                    registro = historial.Where(a => a.hraEntrada.TimeOfDay >= horaEntrada.Value
                        && a.hraEntrada.TimeOfDay <= horaSalida.Value
                        || a.fechaRegistro.ToShortDateString() == DateTime.Now.ToShortDateString()).SingleOrDefault();
                    if (registro == null)
                    {
                        registro = historial.Where(a => a.hraEntrada.TimeOfDay <= horaEntrada.Value
                            || a.fechaRegistro.ToShortDateString() == DateTime.Now.ToShortDateString()).SingleOrDefault();
                    }
                }
            }

            if (registro != null)
            {
                if (registro.hraEntrada != null)
                {
                    return true;
                    //if (registro.hraSalida != null)
                    //{
                    //    var salida = historial.Where(a => a.hraSalida.HasValue == true
                    //    && a.hraSalida.Value.TimeOfDay <= horaSalida.Value).SingleOrDefault();
                    //    if (salida != null)
                    //    {
                    //        if (salida.hraSalida != null)
                    //        {
                    //            return true;
                    //        }
                    //    }
                    //}
                }
                return false;
            }

            return false;
        }
        /// <summary>
        /// Revisa si el usuario ya checo la salida del centro esto mediante la consulta de su hora de entrada y su hora de salida
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool YaChecoSalida(MEmpleado empleado, List<MHistorial> registros, TimeSpan? horaEntrada, TimeSpan? horaSalida)
        {
            IEnumerable<MHistorial> historial = null;
            MHistorial registro = null;
            if (registros != null)
            {

                if (registros.Count > 0)
                {
                    historial = registros.Where(a => a.noEmpleado == empleado.noEmpleado);
                    registro = historial.Where(a => a.hraSalida.HasValue
                        && a.hraSalida.Value.TimeOfDay <= horaSalida.Value
                        && a.hraSalida.Value.TimeOfDay >= horaEntrada
                        && a.fechaRegistro.ToShortDateString() == DateTime.Now.ToShortDateString()).SingleOrDefault();
                    if (registro == null)
                    {
                        registro = historial.Where(a => a.hraSalida.HasValue
                            && a.hraSalida.Value.TimeOfDay >= horaSalida.Value
                            && a.fechaRegistro.ToShortDateString() == DateTime.Now.ToShortDateString()).SingleOrDefault();
                    }
                }
            }
            if (registro != null)
            {
                if (registro.hraSalida.HasValue)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Para usuarios no administrativos, revisa que el usuario no este intentando acceder a un identificador que no corresponda al suyo
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool CheckEmpleado(MEmpleado empleado, MEmpleado empleadoAsp)
        {
            if (empleadoAsp.noEmpleado != empleado.noEmpleado)
            {
                return false;
            }
            return true;
        }
        public bool esDiaFestivo()
        {
            var actual = DateTime.Now;
            var fechasFestivas = _Fechas.CargarFechas(a => a.tipo == 1);
            foreach (var item in fechasFestivas.Where(a => a.fechaInicio.ToShortDateString() == actual.ToShortDateString()
                && a.fechaFin.ToShortDateString() == actual.ToShortDateString()))
            {
                var inicio = item.fechaInicio;
                var fin = item.fechaFin;
                if (actual >= inicio && actual <= fin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Revisa que la fecha actual sea laboral, ademas si no lo es revisa en la base de datos por alguna excepción de fecha
        /// </summary>
        /// <returns></returns>
        public bool esDiaLaboral()
        {
            var actual = DateTime.Now;
            if (actual.DayOfWeek == DayOfWeek.Saturday || actual.DayOfWeek == DayOfWeek.Sunday)
            {
                var diasLaborales = _Fechas.CargarFechas(a => a.tipo == 2);
                foreach (var item in diasLaborales.Where(a => a.fechaInicio.ToShortDateString() == actual.ToShortDateString()
                && a.fechaFin.ToShortDateString() == actual.ToShortDateString()))
                {
                    var inicio = item.fechaInicio;
                    var fin = item.fechaFin;
                    if (actual >= inicio && actual <= fin)
                    {
                        if (item.ignorarHorario)
                        {
                            return true;
                        }
                        return false;
                    }

                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// Revisa si en la fecha actual esta permitido agendar permisos
        /// </summary>
        /// <returns></returns>
        public bool permitePermisos()
        {
            var actual = DateTime.Now;
            var fechaSinPermisos = _Fechas.CargarFechas(a => a.tipo == 3);
            foreach (var item in fechaSinPermisos.Where(a => a.fechaInicio.ToShortDateString() == actual.ToShortDateString()))
            {
                var inicio = item.fechaInicio;
                var fin = item.fechaFin;
                if (actual >= inicio && actual <= fin)
                {
                    return false;
                }
            }
            return true;
        }
        public bool hayPermisosAbiertos(int noEmpleado)
        {
            var actual = DateTime.Now;
            var permisos = _Permisos.CargaPermiso(a => a.noEmpleado == noEmpleado);
            foreach (var item in permisos.Where(a => a.horaSalida.ToShortDateString() == actual.ToShortDateString() && a.horaLlegada == null))
            {
                if (item.horaLlegada != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public bool esDiaForzoso()
        {
            var actual = DateTime.Now;
            var fechasForzosas = _Fechas.CargarFechas(a => a.tipo == 2);
            foreach (var item in fechasForzosas)
            {
                var inicio = item.fechaInicio;
                var fin = item.fechaFin;
                if (actual >= inicio && actual <= fin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Implementación general del metodo de validación
        /// </summary>
        /// <param name="nuevoHistorial"></param>
        /// <param name="historial"></param>
        /// <param name="empleado"></param>
        /// <param name="categoria"></param>
        /// <param name="registro"></param>
        /// <returns></returns>
        public string validacionFechas(MHistorial nuevoHistorial, IEnumerable<MHistorial> historial, MEmpleado empleado, MCategoria categoria, IEnumerable<MHistorial> registro)
        {
            var id = nuevoHistorial.idHistorial;
            if (esDiaFestivo())
            {
                return "festivo();";
            }
            if (!esDiaLaboral())
            {

                return "noEsDiaLaboral();";
            }
            else
            {
                if (DateTime.Now.TimeOfDay >= categoria.hraSalAsignada)
                {
                    return "tarde();";
                }
                if (DateTime.Now.TimeOfDay <= categoria.hraEntAsignada)
                {
                    return "temprano();";
                }
                //Patron de inyeccion de dependencias (SOLUCIONA: NO HACER LLAMADAS A LA BASE DE DATOS DENTRO DEL HELPER)
                if (YaChecoEntrada(empleado, registro.ToList(), categoria.hraEntAsignada, categoria.hraSalAsignada))
                {
                    return "existe();";
                }
                _Historial.GuardarHistorial(nuevoHistorial);
                return "checkado();";
            }
        }
        #endregion
    }
}
