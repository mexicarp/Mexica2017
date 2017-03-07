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
    public class MarcaController : Controller
    {
        // GET: CatPuesto
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaMarcas = dbCtx.marcavehiculos.OrderByDescending(x => x.idMarca).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TMarca Marcas = new TMarca();

                //Marcas.idMarca = int.Parse(formCollection["txtidMarca"]);
                Marcas.descripcion = formCollection["txtdescripcion"];
                dbCtx.marcavehiculos.Add(Marcas);

                dbCtx.SaveChanges();

                return RedirectToAction("Registrar", "Marca");


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
            ViewBag.listaMarcas = dbCtx.marcavehiculos.OrderBy(x => x.idMarca).ToList(); ;
            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaMarcas = dbCtx.marcavehiculos.OrderByDescending(x => x.idMarca).ToList(); ;

            ViewBag.modificarMarca = dbCtx.marcavehiculos.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TMarca Marcas = dbCtx.marcavehiculos.Find(int.Parse(formCollection["txtIdMarca"]));

            Marcas.descripcion = formCollection["txtdescripcion"];
            Marcas.estatus = int.Parse(formCollection["selectEstatus"]);
            dbCtx.SaveChanges();

            return RedirectToAction("Registrar", "Marca");
        }
    }
}