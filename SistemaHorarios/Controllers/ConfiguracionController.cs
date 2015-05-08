using SERVICIOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHorarios.Controllers
{
    public class ConfiguracionController : Controller
    {
        SERVICIOS.Servicios.FechasEspeciales _Fechas = new SERVICIOS.Servicios.FechasEspeciales();
        SERVICIOS.Servicios.Categoria _Categorias = new SERVICIOS.Servicios.Categoria();
        //
        // GET: /Configuracion/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoriasEmpleados()
        {
            var categorias = _Categorias.CargarCategorias();
            return View(categorias);
        }
        public ActionResult FrmNuevaCategoria()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FrmNuevaCategoria(MCategoria model)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _Categorias.GuardarCategoria(model);
                    return JavaScript("cambiosGuardados();");
                }
            }
            return PartialView();
        }
        public ActionResult FrmEditarCategoria(int id)
        {
            var categoria = _Categorias.CargarCategorias(a => a.idCategoria == id);

            return View(categoria.SingleOrDefault());
        }
        [HttpPost]
        public ActionResult FrmEditarCategoria(MCategoria model)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {

                    _Categorias.EditarCategoria(model);
                    return JavaScript("cambiosGuardados();");
                }
            }
            return PartialView();
        }
        public ActionResult FrmEliminarCategoria(int id)
        {
            return View();
        }
        public ActionResult ConfigDiasFestivos()
        {
            return View();
        }
        public ActionResult FormularioFechas(double? inicio, double? fin)
        {
            ///Recibimos los valores de la funcion de JS y creamos un medio modelo
            var fechaEspecial = new SERVICIOS.Models.MFechaEspecial()
            {
                inicio = inicio.Value,
                fin = fin.Value,
            };
            return View(fechaEspecial);
        }
        [HttpPost]
        public ActionResult FormularioFechas(SERVICIOS.Models.MFechaEspecial model)
        {
            if (ModelState.IsValid)
            {
                _Fechas.GuardarFecha(model);
                return JavaScript("refresh();");
            }
            return JavaScript("error();");
        }
        [HttpPost]
        public ActionResult ModificarFecha(int id, DateTime start, DateTime end)
        {
            //Para la funcion drop y resize de full calendar
            var original = _Fechas.CargarFechas(a=>a.id==id).SingleOrDefault();
            var inicio = _Fechas.ConvertirDeFechaAUnix(start);
            var fin = _Fechas.ConvertirDeFechaAUnix(end);
            var fecha = new SERVICIOS.Models.MFechaEspecial()
            {
                inicio = inicio,
                fin = fin,
                id = id,
                clase = original.className,
                descripcion = original.descripcion,
                ignorarHorario = original.ignorarHorario,
                tipo = original.tipo,
                titulo = original.title,
                todoElDia = original.allDay,
                
            };
            _Fechas.EditarFecha(fecha);
            return Json("OK");
        }
        public ActionResult ModificarEvento(int id)
        {
            var evento = _Fechas.CargarFechas(a => a.id == id).SingleOrDefault();
            var editable = new SERVICIOS.Models.MFechaEspecial()
            {
                descripcion = evento.descripcion,
                tipo = evento.tipo,
                id = evento.id,
                titulo = evento.title,
                todoElDia = evento.allDay,
                ignorarHorario = evento.ignorarHorario,
                fin = evento.endd,
                inicio = evento.startd

            };
            return View(editable);
        }
        [HttpPost]
        public ActionResult ModificarEvento(SERVICIOS.Models.MFechaEspecial model)
        {
            if (Request.IsAjaxRequest())
            {

                if (ModelState.IsValid)
                {
                    _Fechas.EditarFecha(model);
                    return JavaScript("modificado();");
                }
            }
            return PartialView();
        }
        public ActionResult EliminarEvento(int id) {
            var fecha = _Fechas.CargarFechas(a=>a.id==id).SingleOrDefault();
            var fechaEspecial = new MFechaEspecial() { 
                id = id
            };
            _Fechas.EliminarFecha(fechaEspecial);
            return JavaScript("eliminado();");
        }
        public ActionResult EditarHistorial()
        {
            return View();
        }
        public ActionResult EditarPermisos()
        {
            return View();
        }
        public ActionResult Fechas()
        {
            var fechas = _Fechas.CargarFechas();
            var data = fechas.ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}