﻿using appMexicaERP.DAL;
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
    public class CuentaController : Controller
    {
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.listasBancos = DbContext.Bancos.OrderByDescending(x => x.idBanco);

            ViewBag.listasNegocios = DbContext.Negocios.OrderByDescending(x => x.idNegocio);

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

                        TCuenta Cuenta = new TCuenta();

                        Cuenta.idCuenta = Guid.NewGuid().ToString();
                        Cuenta.idNegocio = formCollection["selectNegocio"];
                        Cuenta.numeroCuenta = int.Parse(formCollection["txtNumeroCuenta"]);
                        Cuenta.saldoInicial = decimal.Parse(formCollection["txtSaldoInicial"]);
                        Cuenta.saldoTotal = decimal.Parse(formCollection["txtSaldoInicial"]);
                        Cuenta.referencia = formCollection["txtReferencia"];
                        Cuenta.fecha = DateTime.Parse(formCollection["txtFecha"]);
                        Cuenta.observacion = formCollection["txtObservacion"];
                        Cuenta.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Cuenta.fechaRegistro = DateTime.Now;
                        Cuenta.fechaModificacion = DateTime.Now;

                        DbContext.Cuentas.Add(Cuenta);

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

                        return "<script>mostrarMensajeGlobal('" + mensajeGlobal + "', '" + System.Configuration.ConfigurationManager.AppSettings["colorError"] + "');</script>";
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Ver()
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.listasBancos = DbContext.Bancos.OrderByDescending(x => x.idBanco);

            ViewBag.listasCuentas = DbContext.Cuentas.OrderByDescending(x => x.idCuenta);

            return View();
        }

        [HttpGet]
        public ActionResult Modificar(string id)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.listasBancos = DbContext.Bancos.OrderByDescending(x => x.idBanco);

            ViewBag.listasNegocios = DbContext.Negocios.OrderByDescending(x => x.idNegocio);

            ViewBag.modificarCuenta = DbContext.Cuentas.Find(id);

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

                        TCuenta Cuenta = DbContext.Cuentas.Find(formCollection["txtIdCuenta"]);

                        Cuenta.idNegocio = formCollection["selectNegocio"];
                        Cuenta.numeroCuenta = int.Parse(formCollection["txtNumeroCuenta"]);
                        Cuenta.saldoInicial = decimal.Parse(formCollection["txtSaldoInicial"]);
                        Cuenta.saldoTotal = decimal.Parse(formCollection["txtSaldoInicial"]);
                        Cuenta.referencia = formCollection["txtReferencia"];
                        Cuenta.fecha = DateTime.Parse(formCollection["txtFecha"]);
                        Cuenta.observacion = formCollection["txtObservacion"];
                        Cuenta.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Cuenta.fechaModificacion = DateTime.Now;

                        DbContext.SaveChanges();

                        dbContextTransaction.Commit();

                        TempData["mensajeGlobal"] = "Datos Actualizados correctamente.";
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];

                        return RedirectToAction("ver", "Cuenta");
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

                        TempData["mensajeGlobal"] = mensajeGlobal;
                        TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorError"];

                        return RedirectToAction("Modificar", "Cuenta");
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult VerPorIdCuentaConAjaxParaMovimiento(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTCuenta = dbCtx.Cuentas.Where(w1 => w1.idNegocio == id).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult ListarCuentasPorNegocioConAjax(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTCuenta = dbCtx.Cuentas.Include(i1 => i1.parentNegocio).Where(w1 => w1.idNegocio == id).ToList();
           

            return View();
        }
    }
}