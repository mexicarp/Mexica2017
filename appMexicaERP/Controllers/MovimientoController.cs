using appMexicaERP.DAL;
using appMexicaERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace appMexicaERP.Controllers
{
    public class MovimientoController : Controller
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

            ViewBag.listaNegocios = DbContext.Negocios.OrderByDescending(x => x.idNegocio);

            ViewBag.listaCuentas = DbContext.Cuentas.OrderByDescending(x => x.idCuenta);

            ViewBag.listaConcepto = DbContext.Conceptos.OrderByDescending(x => x.idConcepto);

            return View();
        }

        [HttpPost]
        public string Registrar(FormCollection formCollection)
        {

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            string mensajeGlobal = "";

            try
            {
                TCuenta tCuenta = DbContext.Cuentas.Find(formCollection["selectCuentas"]);

                if (formCollection["selectTipoTransacion"] == "1")
                {
                    tCuenta.saldoTotal += decimal.Parse(formCollection["txtCantidad"]);
                }
                else
                {
                    tCuenta.saldoTotal -= decimal.Parse(formCollection["txtCantidad"]);
                }

                TMovimiento Movimiento = new TMovimiento();

                Movimiento.idMovimiento = Guid.NewGuid().ToString();
                Movimiento.idUsuario = "51f78c71-6afb-4ca5-b791-dd6bfdf3c9e5";
                //Movimiento.idConcepto = formCollection["selectConceptos"];
                Movimiento.idCuenta = formCollection["selectCuentas"];
                Movimiento.tipoTransacion = formCollection["selectTipoTransacion"];
                Movimiento.deposito = decimal.Parse(formCollection["selectTipoTransacion"]== "1" ? formCollection["txtCantidad"] : "0");
                Movimiento.retiro = decimal.Parse(formCollection["selectTipoTransacion"] == "0" ? formCollection["txtCantidad"] : "0");
                Movimiento.saldo = tCuenta.saldoTotal;
                Movimiento.descripcion = formCollection["txtDescripcion"];
                Movimiento.referencia = formCollection["txtReferencia"];
                Movimiento.fecha = DateTime.Parse(formCollection["datepicker-default"].ToString());
                Movimiento.autorizacion = formCollection["txtxAutorizadopor"];
                //Movimiento.concepto = formCollection["txtConcepto"];
                Movimiento.fechaRegistro = DateTime.Now;
                Movimiento.fechaModificacion = DateTime.Now;

                DbContext.Movimientos.Add(Movimiento);

                DbContext.SaveChanges();

                return "<script>mostrarMensajeGlobal('Registro realizado correctamente', '" + System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"] + "');</script>";
            }

            catch (DbEntityValidationException ex)
            {
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

        [HttpGet]
        public ActionResult Ver()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.listaBancos = DbContext.Bancos.OrderByDescending(x => x.idBanco);

            ViewBag.listaNegocios = DbContext.Negocios.OrderByDescending(x => x.idNegocio);

            ViewBag.listaCuentas = DbContext.Cuentas.OrderByDescending(x => x.idCuenta);

            ViewBag.listaTMovimientos = DbContext.Movimientos.Include(x1 => x1.parentCuenta).OrderByDescending(x => x.idMovimiento);

            return View();
        }

        [HttpPost]
        public ActionResult ListarMovimientosPorCuentaConAjax(string id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaTMovimientos = dbCtx.Movimientos.Where(w1 => w1.idCuenta == id).OrderBy(o => o.fechaRegistro).ToList();


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

            ViewBag.listaBancos = dbCtx.Bancos.OrderByDescending(x => x.idBanco);

            ViewBag.listaNegocios = dbCtx.Negocios.OrderByDescending(x => x.idNegocio);

            ViewBag.listaCuentas = dbCtx.Cuentas.OrderByDescending(x => x.idCuenta);

            ViewBag.modificarTMovimiento = dbCtx.Movimientos.Find(id);


            return View();
        }
    }
}