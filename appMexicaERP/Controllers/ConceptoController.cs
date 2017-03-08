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
    }
}