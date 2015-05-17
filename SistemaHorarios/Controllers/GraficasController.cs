using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SERVICIOS.Servicios;
namespace SistemaHorarios.Controllers
{
    public class GraficasController : Controller
    {
        //
        Graficas _Graficas = new Graficas();
        // GET: /Graficas/
        
        public ActionResult Index(int id,DateTime? Inicio,DateTime? Fin)
        {

            var model = _Graficas.GraficaRendimientoUsuario(id,Inicio,Fin);
            return Json(model,JsonRequestBehavior.AllowGet);
        }
        public ActionResult PromedioMensual(int id, DateTime? Inicio, DateTime? Fin)
        {
            var model = _Graficas.GraficaPromedioMensual(id, Inicio, Fin);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GraficaCompleta(int id) {
            var model = _Graficas.GraficaAñoDrill(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GraficaTodos() {
            var model = _Graficas.GraficaTodosEmpleados();
            return Json(model,JsonRequestBehavior.AllowGet);
        }
	}
}