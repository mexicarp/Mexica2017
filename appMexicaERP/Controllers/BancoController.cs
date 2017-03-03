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
    public class BancoController : Controller
    {
        [HttpGet]
        public ActionResult Registrar()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

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

                        TBanco Banco = new TBanco();

                        Banco.idBanco = Guid.NewGuid().ToString();
                        Banco.nombre = formCollection["nombreBanco"];
                        Banco.estatus = formCollection["estatus"].ToString() == "1" ? true : false;
                        Banco.fechaRegistro = DateTime.Now;
                        Banco.fechaModificacion = DateTime.Now;

                        DbContext.Bancos.Add(Banco);

                        DbContext.SaveChanges();

                        dbContextTransaction.Commit();

                        return "<script>mostrarMensajeGlobal('Registro realizado correctamente', '" + System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"] + "');</script>";
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

                        return "<script>mostrarMensajeGlobal('"+ mensajeGlobal + "', '"+System.Configuration.ConfigurationManager.AppSettings["colorError"] +"');</script>";
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

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.listasBancos = DbContext.Bancos.OrderByDescending(x => x.idBanco);

            return View();
        }

        [HttpGet]
        public ActionResult Modificar(string id)
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.modificarBanco = DbContext.Bancos.Find(id);

            return View();
        }

        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            using (DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = DbContext.Database.BeginTransaction())
                {

                    try
                    {

                        TBanco Banco = DbContext.Bancos.Find(formCollection["txtIdBanco"]);

                        Banco.nombre = formCollection["txtNombreBanco"];
                        Banco.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Banco.fechaModificacion = DateTime.Now;

                        DbContext.SaveChanges();

                        dbContextTransaction.Commit();

                        TempData["mensajeGlobal"] = "Datos registrados correctamente.";
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];

                        return RedirectToAction("ver", "Banco");
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

                        //return "<script>mostrarMensajeGlobal('"+ mensajeGlobal + "', '"+System.Configuration.ConfigurationManager.AppSettings["colorError"] +"');</script>";

                        TempData["mensajeGlobal"] = mensajeGlobal;
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorError"];

                        return RedirectToAction("Modificar","Banco");
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Eliminar(string id)
        {
            //string mensajeGlobal = "";

            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext DbCtx = new DBappWebMexicaERPcontext();

            DbCtx.Bancos.Remove(DbCtx.Bancos.Find(id));

            DbCtx.SaveChanges();

            TempData["mensajeGlobal"] = "Eliminacion exitosa. ";
            TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];

            return RedirectToAction("ver");
        }
    }

}
