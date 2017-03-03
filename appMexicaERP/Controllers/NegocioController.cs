using appMexicaERP.DAL;
using appMexicaERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace appMexicaERP.Controllers
{
    public class NegocioController : Controller
    {
        
        [HttpGet]
        public ActionResult Registrar()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.listaBancos = DbContext.Bancos.OrderByDescending(x => x.idBanco);

            return View();
        }

        [HttpPost]
        public string Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            using (DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = DbContext.Database.BeginTransaction())
                {
                    try
                    {

                        TNegocio Negocio = new TNegocio();

                        Negocio.idNegocio = Guid.NewGuid().ToString();
                        Negocio.idBanco = formCollection["selecIdBanco"];
                        Negocio.nombre = formCollection["txtNegocio"];
                        Negocio.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Negocio.fechaRegistro = DateTime.Now;
                        Negocio.fechaModificacion = DateTime.Now;

                        DbContext.Negocios.Add(Negocio);

                        DbContext.SaveChanges();

                        dbContextTransaction.Commit();

                        return "<script>mostrarMensajeGlobal('Se ha registrado correctamente', '" + System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"] + "');</script>";
                    }

                    catch (DbEntityValidationException ex)
                    {
                        dbContextTransaction.Rollback();

                        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                        {
                            string entityName = item.Entry.Entity.GetType().Name;

                            foreach (DbValidationError error in item.ValidationErrors)
                            {
                                mensajeGlobal += error.ErrorMessage;
                            }
                        }

                        return "<script>mostrarMensajeGlobal('" + mensajeGlobal + "', '" + System.Configuration.ConfigurationManager.AppSettings["colorError"] + "');</script>";
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Ver()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTNegocio = dbCtx.Negocios.Include(i1 => i1.parentBanco).ToList();

            ViewBag.listaBancos = dbCtx.Bancos.OrderByDescending(x => x.idBanco);

            return View();
        }

        [HttpGet]
        public ActionResult Modificar(string id)
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }       

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.modificarNegocioPorBanco = dbCtx.Negocios.Find(id);

            // ViewBag.modificarNegocioPorBanco = dbCtx.Negocios.Include(x => x.parentBanco).Where(x1 => x1.idNegocio == id).First();

            ViewBag.listaBancos = dbCtx.Bancos.OrderByDescending(x => x.idBanco);

            return View();
        }

        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            using (DBappWebMexicaERPcontext DbCtx = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = DbCtx.Database.BeginTransaction())
                {
                    try
                    {

                        TNegocio Negocio = DbCtx.Negocios.Find(formCollection["txtIdNegocio"]);

                        Negocio.idBanco = formCollection["selecIdBanco"];
                        Negocio.nombre = formCollection["txtNegocio"];
                        Negocio.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Negocio.fechaModificacion = DateTime.Now;

                        DbCtx.SaveChanges();

                        dbContextTransaction.Commit();

                        TempData["mensajeGlobal"] = "Datos actualizado con exito!.";
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];

                        return RedirectToAction("ver", "Negocio");
                    }

                    catch (DbEntityValidationException ex)
                    {
                        dbContextTransaction.Rollback();

                        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                        {
                            string entityName = item.Entry.Entity.GetType().Name;

                            foreach (DbValidationError error in item.ValidationErrors)
                            {
                                mensajeGlobal += error.ErrorMessage;
                            }
                        }

                        TempData["mensajeGlobal"] = mensajeGlobal;
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorError"];

                        return RedirectToAction("Modificar", "Negocio");
                    }
                }
            }
        }


        [HttpPost]
        public ActionResult ListarNegociosPorBancoConAjax(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTNegocio = dbCtx.Negocios.Include(i1 => i1.parentBanco).Where(w1 => w1.idBanco == id).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult VerPorIdBancoConAjaxParaMovimiento(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTNegocio = dbCtx.Negocios.Where(w1 => w1.idBanco == id).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult VerPorIdBancoConAjaxParaCuenta(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTNegocio = dbCtx.Negocios.Where(w1 => w1.idBanco == id).ToList();

            return View();
        }
    }
}