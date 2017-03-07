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
    public class EmpresaController : Controller
    {
        // GET: CatPuesto
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TEmpresa Empresas = new TEmpresa();

                Empresas.idEmpresa = int.Parse(formCollection["txtIdEmpresa"]);
                Empresas.idTipoEmpresa = int.Parse(formCollection["txtidTipoEmpresa"]);
                Empresas.fechaCreacion = DateTime.Parse(formCollection["txtfechaCreacion"]);
                Empresas.descripcion = formCollection["txtIdEmpresa"];
                Empresas.domicilio = formCollection["txtIdEmpresa"];
                Empresas.numero = formCollection["txtIdEmpresa"];
                Empresas.cp = int.Parse(formCollection["txtIdEmpresa"]);
                Empresas.colonia = formCollection["txtIdEmpresa"];
                Empresas.municipio = formCollection["txtIdEmpresa"];
                Empresas.idCiudad = int.Parse(formCollection["selectIdCiudad"]);
                Empresas.telefono = formCollection["txtIdEmpresa"];
                Empresas.email = formCollection["txtIdEmpresa"];
                Empresas.rfc = formCollection["txtdescripcion"];
                Empresas.fechaModificacion = DateTime.Parse(formCollection["txtdescripcion"]);
                Empresas.estatus = 1;

                dbCtx.empresas.Add(Empresas);
                dbCtx.SaveChanges();

                return RedirectToAction("Consulta", "Empresa");


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
            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa);

            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa);

            ViewBag.modificarEmpresa = dbCtx.empresas.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TEmpresa Empresas = dbCtx.empresas.Find(int.Parse(formCollection["txtIdEmpresa"]));

            Empresas.idTipoEmpresa = int.Parse(formCollection["txtidTipoEmpresa"]);
            Empresas.fechaCreacion = DateTime.Parse(formCollection["txtfechaCreacion"]);
            Empresas.descripcion = formCollection["txtIdEmpresa"];
            Empresas.domicilio = formCollection["txtIdEmpresa"];
            Empresas.numero = formCollection["txtIdEmpresa"];
            Empresas.cp = int.Parse(formCollection["txtIdEmpresa"]);
            Empresas.colonia = formCollection["txtIdEmpresa"];
            Empresas.municipio = formCollection["txtIdEmpresa"];
            Empresas.idCiudad = int.Parse(formCollection["selectIdCiudad"]);
            Empresas.telefono = formCollection["txtIdEmpresa"];
            Empresas.email = formCollection["txtIdEmpresa"];
            Empresas.rfc = formCollection["txtdescripcion"];
            Empresas.fechaModificacion = DateTime.Now;
            dbCtx.SaveChanges();

            return RedirectToAction("Consulta", "Empresa");
        }
    }
}