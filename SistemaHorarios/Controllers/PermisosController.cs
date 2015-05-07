using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHorarios.Controllers
{
    public class PermisosController : Controller
    {
        //
        // GET: /Permisos/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgendarPermiso() {
            return View();
        }
        [HttpPost]
        public ActionResult AgendarPermiso(FormCollection forms) {
            return View();
        }
	}
}