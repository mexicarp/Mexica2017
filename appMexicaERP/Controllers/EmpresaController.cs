using appMexicaERP.DAL;
using appMexicaERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa).ToList();

            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa).ToList();

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

        [HttpGet]
        public ActionResult RelacionarConBanco()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa).ToList();

            ViewBag.listaBancos = dbCtx.Bancos.OrderByDescending(x => x.idBanco).ToList();

            return View();
        }

        [HttpPost]
        public string RelacionarConBanco(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            using (DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = dbCtx.Database.BeginTransaction())
                {
                    try
                    {

                        TEmpresa Empresa = dbCtx.empresas.Find(int.Parse(formCollection["selecIdEmpresa"]));

                        Empresa.idBanco = formCollection["selecIdBanco"];

                        dbCtx.SaveChanges();

                        dbContextTransaction.Commit();

                        return "<script>mostrarMensajeGlobal('Se ha Relacionado correctamente', '" + System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"] + "');</script>";
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
        public ActionResult VerEmpresaRelacionadoConBanco()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaBancos = dbCtx.Bancos.OrderByDescending(x => x.idBanco).ToList();

            ViewBag.listaEmpresas = dbCtx.empresas.Include(x => x.parentBanco).OrderByDescending(x => x.idEmpresa).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult ListarEmpresasPorBancoConAjax(string id)
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTEmpresas = dbCtx.empresas.Include(i1 => i1.parentBanco).Where(w1 => w1.idBanco == id).ToList();

            return View();
        }

        [HttpGet]
        public ActionResult ModificarEmpresaPorBanco(int id)
        {

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaBancos = dbCtx.Bancos.OrderByDescending(x => x.idBanco).ToList();

            ViewBag.listaEmpresas = dbCtx.empresas.Include(x => x.parentBanco).OrderByDescending(x => x.idEmpresa).ToList();

            ViewBag.modificarEmpresaPorBanco = dbCtx.empresas.Find(id);

            return View();
        }

        [HttpPost]
        public ActionResult ModificarEmpresaPorBanco(FormCollection formCollection)
        {

            string mensajeGlobal = "";

            using (DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = dbCtx.Database.BeginTransaction())
                {

                    try
                    {

                        TEmpresa Empresa = dbCtx.empresas.Find(int.Parse(formCollection["selecIdEmpresa"]));

                        Empresa.idBanco = formCollection["selecIdBanco"];

                        dbCtx.SaveChanges();

                        dbContextTransaction.Commit();

                        TempData["mensajeGlobal"] = "Datos actualizados correctamente.";
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];

                        return RedirectToAction("verEmpresaRelacionadoConBanco", "Empresa");
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

                        return RedirectToAction("ModificarEmpresaPorBanco", "Empresa");
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult VerPorIdBancoConAjaxParaCuenta(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTEmpresa = dbCtx.empresas.Where(w1 => w1.idBanco == id).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult VerPorIdBancoConAjaxParaMovimiento(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTEmpresa = dbCtx.empresas.Where(w1 => w1.idBanco == id).ToList();

            return View();
        }

    }
}