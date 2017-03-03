using System.Data.Entity;
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
    public class FlotillaController : Controller
    {
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaFlotilla = dbCtx.flotillas.OrderByDescending(x => x.idFlotilla);

            ViewBag.listaMarcas = dbCtx.marcavehiculos.OrderByDescending(x => x.idMarca);

            ViewBag.listaCombustible = dbCtx.combustibles.OrderByDescending(x => x.idCombustible);

            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa);

            ViewBag.listaEmpleados = dbCtx.empleados.OrderByDescending(x => x.idEmpleado);

            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TFlotilla Flotilla = new TFlotilla();

                Flotilla.idMarca = int.Parse(formCollection["selectIdMarca"]);
                Flotilla.modelo = int.Parse(formCollection["txttmodelo"]);
                Flotilla.tipo = formCollection["txttipo"];
                Flotilla.serie = formCollection["txtserie"];
                Flotilla.idCombustible = int.Parse(formCollection["selectidCombustible"]);
                Flotilla.litros = int.Parse(formCollection["txtlitros"]);
                Flotilla.capacidad = int.Parse(formCollection["txtcapacidad"]);
                Flotilla.kilometraje = int.Parse(formCollection["txtkilometraje"]);
                Flotilla.placas = formCollection["txtplacas"];
                Flotilla.numEconomico = formCollection["txtnumEconomico"];
                Flotilla.seguro = int.Parse(formCollection["selectseguro"]);
                Flotilla.ciaSeguro = formCollection["txtciaSeguro"];
                Flotilla.montoPagoSeguro = double.Parse(formCollection["txtmontoPagoSeguro"]);
                Flotilla.vigenciaIniciaSeguro = DateTime.Parse(formCollection["datevigenciaIniciaSeguro"]);
                Flotilla.vigenciaFinSeguro = DateTime.Parse(formCollection["datevigenciaFinSeguro"]);
                Flotilla.idEmpresa = int.Parse(formCollection["selectIdEmpleado"]);
                Flotilla.idEmpleado = int.Parse(formCollection["selectOperador"]);
                Flotilla.estatusPago = int.Parse(formCollection["selectestatusPago"]);
                Flotilla.pagoMensual = double.Parse(formCollection["txtpagoMensual"]);
                Flotilla.diaPagoUnidad = int.Parse(formCollection["txtdiaPagoUnidad"]);
                Flotilla.observaciones = formCollection["txtobservaciones"];
                Flotilla.estatus = int.Parse(formCollection["selectestatus"]);

                dbCtx.flotillas.Add(Flotilla);
                dbCtx.SaveChanges();

                return RedirectToAction("Registrar", "Flotilla");


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

            ViewBag.listaFlotilla = dbCtx.flotillas.Include(x1 => x1.parentEmpresas).Include(x1 => x1.parentEmpleados).OrderByDescending(x => x.idFlotilla);

            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaFlotilla = dbCtx.flotillas.OrderByDescending(x => x.idFlotilla).ToList();
            ViewBag.listaEmpleados = dbCtx.empleados.OrderByDescending(x => x.idEmpleado).ToList();
            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa).ToList();
            ViewBag.listaMarcas = dbCtx.marcavehiculos.OrderByDescending(x => x.idMarca);
            ViewBag.listaCombustibles = dbCtx.combustibles.OrderByDescending(x => x.idCombustible).ToList();

            ViewBag.modificarFlotilla = dbCtx.flotillas.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TFlotilla Flotilla = dbCtx.flotillas.Find(int.Parse(formCollection["txtidFlotilla"]));
            Flotilla.idMarca = int.Parse(formCollection["selectIdMarca"]);
            Flotilla.modelo = int.Parse(formCollection["txttmodelo"]);
            Flotilla.tipo = formCollection["txttipo"];
            Flotilla.serie = formCollection["txtserie"];
            Flotilla.idCombustible = int.Parse(formCollection["selectidCombustible"]);
            Flotilla.litros = int.Parse(formCollection["txtlitros"]);
            Flotilla.capacidad = int.Parse(formCollection["txtcapacidad"]);
            Flotilla.kilometraje = int.Parse(formCollection["txtkilometraje"]);
            Flotilla.placas = formCollection["txtplacas"];
            Flotilla.numEconomico = formCollection["txtnumEconomico"];
            Flotilla.seguro = int.Parse(formCollection["selectseguro"]);
            Flotilla.ciaSeguro = formCollection["txtciaSeguro"];
            Flotilla.montoPagoSeguro = double.Parse(formCollection["txtmontoPagoSeguro"]);
            Flotilla.vigenciaIniciaSeguro = DateTime.Parse(formCollection["datevigenciaIniciaSeguro"]);
            Flotilla.vigenciaFinSeguro = DateTime.Parse(formCollection["datevigenciaFinSeguro"]);
            Flotilla.idEmpresa = int.Parse(formCollection["selectIdEmpleado"]);
            Flotilla.idEmpleado = int.Parse(formCollection["selectOperador"]);
            Flotilla.estatusPago = int.Parse(formCollection["selectestatusPago"]);
            Flotilla.pagoMensual = double.Parse(formCollection["txtpagoMensual"]);
            Flotilla.diaPagoUnidad = int.Parse(formCollection["txtdiaPagoUnidad"]);
            Flotilla.observaciones = formCollection["txtobservaciones"];
            Flotilla.estatus = int.Parse(formCollection["selectestatus"]);
            dbCtx.SaveChanges();
            return RedirectToAction("Consulta", "Flotilla");
        }

    }
}