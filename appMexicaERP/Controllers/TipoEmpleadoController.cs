using appMexicaERP.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appMexicaERP.Models;

namespace appMexicaERP.Controllers
{
    public class TipoEmpController : Controller
    {

        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaTipoEmp = dbCtx.tiposempleados.OrderByDescending(x => x.idTipoEmpleado);
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TTipoEmpleado tipoEmpleado = new TTipoEmpleado();

                tipoEmpleado.descripcion = formCollection["txtdescripcion"];
                tipoEmpleado.estatus = 1;

                dbCtx.tiposempleados.Add(tipoEmpleado);

                dbCtx.SaveChanges();

                return RedirectToAction("Consulta", "TipoEmpleado");


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
            ViewBag.listaTipoEmp = dbCtx.tiposempleados.OrderByDescending(x => x.idTipoEmpleado);
            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaTipoEmp = dbCtx.tiposempleados.OrderByDescending(x => x.idTipoEmpleado);

            ViewBag.modificarTipoEmp = dbCtx.tiposempleados.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            TTipoEmpleado TipoEmpleado = dbCtx.tiposempleados.Find(int.Parse(formCollection["txtidTipoEmpleado"]));
            TipoEmpleado.descripcion = formCollection["txtdescripcion"];
            dbCtx.SaveChanges();
            return RedirectToAction("Consulta", "TipoEmpleado");
        }
    }
}