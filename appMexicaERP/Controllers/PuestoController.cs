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
    public class PuestoController : Controller
    {
        // GET: CatPuesto
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaPuestos = dbCtx.puestos.OrderByDescending(x => x.idPuesto);
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TPuesto Puesto = new TPuesto();

                Puesto.categoria = formCollection["txtcategoria"];
                Puesto.descripcion = formCollection["txtdescripcion"];
                Puesto.alcancePuesto = formCollection["txtalcancePuesto"];
                if (formCollection["txthoras"].ToString() == "")
                {
                    Puesto.horas = 0;
                }
                else
                {
                    Puesto.horas = int.Parse(formCollection["txthoras"]);
                }

                if (formCollection["txtcosto"].ToString() == "")
                {
                    Puesto.costo = 0.00;
                }
                else
                {
                    Puesto.costo = double.Parse(formCollection["txtcosto"]);
                }
                dbCtx.puestos.Add(Puesto);

                dbCtx.SaveChanges();

                return RedirectToAction("Consulta", "Puesto");


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
            ViewBag.listaPuestos = dbCtx.puestos.OrderByDescending(x => x.idPuesto);
            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaPuestos = dbCtx.puestos.OrderByDescending(x => x.idPuesto);

            ViewBag.modificarPuesto = dbCtx.puestos.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TPuesto Puesto = dbCtx.puestos.Find(int.Parse(formCollection["txtIdPuesto"]));

            Puesto.categoria = formCollection["txtcategoria"];
            Puesto.descripcion = formCollection["txtdescripcion"];
            Puesto.alcancePuesto = formCollection["txtalcancePuesto"];
            if (formCollection["txthoras"].ToString() == "")
            {
                Puesto.horas = 0;
            }
            else
            {
                Puesto.horas = int.Parse(formCollection["txthoras"]);
            }

            if (formCollection["txtcosto"].ToString() == "")
            {
                Puesto.costo = 0.00;
            }
            else
            {
                Puesto.costo = double.Parse(formCollection["txtcosto"]);
            }
            dbCtx.SaveChanges();
            return RedirectToAction("Registrar", "Puesto");
        }
    }
}