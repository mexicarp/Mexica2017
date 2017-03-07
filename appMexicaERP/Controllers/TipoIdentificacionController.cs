using appMexicaERP.DAL;
using appMexicaERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appMexicaERP.Controllers
{
    public class TipoIndentificacionController : Controller
    {
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaIden = dbCtx.tipoidentificaciones.OrderByDescending(x => x.idIdentificacion);
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";
            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TTipoIdentificacion Identifica = new TTipoIdentificacion();

                Identifica.descripcion = formCollection["txtdescripcion"];
                Identifica.estatus = 1;
                dbCtx.tipoidentificaciones.Add(Identifica);

                dbCtx.SaveChanges();

                return RedirectToAction("Consulta", "TipoIndentificacion");


            }
            catch (DbEntityValidationException ex)
            {

                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;

                    foreach (DbValidationError error in item.ValidationErrors)
                    {
                        mensajeGlobal += error.ErrorMessage;
                    }
                }

                ViewBag.formCollection = formCollection;
                ViewBag.mensajeGlobal = mensajeGlobal;
                ViewBag.color = System.Configuration.ConfigurationManager.AppSettings["colorError"];

                return View();

                //return Redirect("Registrar");
            }
        }


        [HttpGet]
        public ActionResult Consulta()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaIden = dbCtx.tipoidentificaciones.OrderByDescending(x => x.idIdentificacion);
            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaIden = dbCtx.tipoidentificaciones.OrderByDescending(x => x.idIdentificacion);

            ViewBag.modificarIden = dbCtx.tipoidentificaciones.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TTipoIdentificacion Identifica = dbCtx.tipoidentificaciones.Find(int.Parse(formCollection["txtidIdentificacion"]));

            Identifica.descripcion = formCollection["txtdescripcion"];
            dbCtx.SaveChanges();

            return RedirectToAction("Consulta", "TipoIndentificacion");
        }
    }
}