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
        //
        // GET: /Configuracion/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoriasEmpleados()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoriasEmpleados(FormCollection forms)
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
        public ActionResult ModificarFecha(int id,DateTime start,DateTime end)
        {
            var inicio = _Fechas.ConvertirDeFechaAUnix(start);
            var fin = _Fechas.ConvertirDeFechaAUnix(end);
            var fecha = new SERVICIOS.Models.MFechaEspecial() { 
                inicio = inicio,
                fin = fin,
                id = id
            };
            _Fechas.EditarFecha(fecha);
            return Json("OK");
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