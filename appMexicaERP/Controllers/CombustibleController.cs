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
    public class CombustibleController : Controller
    {
        // GET: CatPuesto
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaCombustibles = dbCtx.combustibles.OrderByDescending(x => x.idCombustible).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TCombustible Combustibles = new TCombustible();
                //Combustibles.idCombustible  = int.Parse(formCollection["txtidCombustible"]);
                Combustibles.descripcion = formCollection["txtdescripcion"];
                Combustibles.costoLitro = double.Parse(formCollection["txtcostoLitro"]);
                Combustibles.estatus = int.Parse(formCollection["selectEstatus"]);
                dbCtx.combustibles.Add(Combustibles);

                dbCtx.SaveChanges();

                return RedirectToAction("Consulta", "Combustible");


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
            ViewBag.listaCombustible = dbCtx.combustibles.OrderByDescending(x => x.idCombustible).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaCombustible = dbCtx.combustibles.OrderByDescending(x => x.idCombustible).ToList();

            ViewBag.modificarCombustible = dbCtx.combustibles.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TCombustible Combustibles = dbCtx.combustibles.Find(int.Parse(formCollection["txtidCombustible"]));

            //Combustibles.idCombustible  = int.Parse(formCollection["txtidCombustible"]);
            Combustibles.descripcion = formCollection["txtdescripcion"];
            Combustibles.costoLitro = double.Parse(formCollection["txtcostoLitro"]);
            Combustibles.estatus = int.Parse(formCollection["selectEstatus"]);
            dbCtx.SaveChanges();
            return RedirectToAction("Registrar", "Combustible");
        }
    }
}