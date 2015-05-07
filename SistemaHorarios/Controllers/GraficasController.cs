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
	}
}