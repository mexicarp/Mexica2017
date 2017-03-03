using appMexicaERP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appMexicaERP.Controllers
{
    public class CiudadController : Controller
    {
        [HttpGet]
        public ActionResult Consulta()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaCiudades = dbCtx.ciudades.OrderByDescending(x => x.idCiudad).ToList();
            return View();
        }
    }
}