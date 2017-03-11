using appMexicaERP.DAL;
using appMexicaERP.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace appMexicaERP.Controllers
{
    public class ConceptoController : Controller
    {
        [HttpGet]
        public ActionResult Insertar()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            return View();
        }

        [HttpPost]
        public string Insertar(FormCollection formCollection)
        {
            string mensajeGlobal = "";


            using (DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = DbContext.Database.BeginTransaction())
                {
                    try
                    {

                        TConcepto Concepto = new TConcepto();

                        Concepto.idConcepto = Guid.NewGuid().ToString();
                        Concepto.concepto = formCollection["txtConcepto"];
                        Concepto.descripcion = formCollection["txtDescripcion"];
                        Concepto.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Concepto.fechaRegistro = DateTime.Now;
                        Concepto.fechaModificacion = DateTime.Now;

                        DbContext.Conceptos.Add(Concepto);

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
                                mensajeGlobal += error.ErrorMessage+"<br>";
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

            ViewBag.listaTConcepto = dbCtx.Conceptos.OrderByDescending(x => x.idConcepto).ToList();

            return View();
        }

        [HttpGet]
        public ActionResult Modificar(string id)
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext DbCtx = new DBappWebMexicaERPcontext();


            ViewBag.modificarConcepto = DbCtx.Conceptos.Find(id);

            return View();
        }

        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {

            string mensajeGlobal = "";

            using (DBappWebMexicaERPcontext ctxDb = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = ctxDb.Database.BeginTransaction())
                {

                    try
                    {

                        TConcepto Concepto = ctxDb.Conceptos.Find(formCollection["txtIdConcepto"]);

                        Concepto.concepto = formCollection["txtConcepto"];
                        Concepto.descripcion = formCollection["txtDescripcion"];
                        Concepto.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Concepto.fechaModificacion = DateTime.Now;

                        ctxDb.SaveChanges();

                        dbContextTransaction.Commit();

                        TempData["mensajeGlobal"] = "Datos registrados correctamente.";
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];

                        return RedirectToAction("ver", "Concepto");
                    }

                    catch (DbEntityValidationException ex)
                    {
                        dbContextTransaction.Rollback();

                        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                        {
                            string entityName = item.Entry.Entity.GetType().Name;

                            foreach (DbValidationError error in item.ValidationErrors)
                            {
                                mensajeGlobal += error.ErrorMessage + "<br>";
                            }
                        }

                        //return "<script>mostrarMensajeGlobal('"+ mensajeGlobal + "', '"+System.Configuration.ConfigurationManager.AppSettings["colorError"] +"');</script>";

                        TempData["mensajeGlobal"] = mensajeGlobal;
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorError"];

                        return RedirectToAction("Modificar", "Concepto");
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext DbCtx = new DBappWebMexicaERPcontext();

            DbCtx.Conceptos.Remove(DbCtx.Conceptos.Find(id));

            DbCtx.SaveChanges();

            TempData["mensajeGlobal"] = "Eliminacion exitosa. ";
            TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];

            return RedirectToAction("Ver");
        }

        [HttpGet]
        public ActionResult VerDetalles()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTConcepto = dbCtx.Conceptos.OrderByDescending(x => x.idConcepto).ToList();

            return View();
        }
    }
}