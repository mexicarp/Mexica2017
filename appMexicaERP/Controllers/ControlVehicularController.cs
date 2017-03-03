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
    public class ControlVehicularController : Controller
    {
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaControlVehicular = dbCtx.ctrolvehiculares.OrderByDescending(x1 => x1.idControl);

            //ViewBag.listaFlotilla = dbCtx.flotillas.OrderByDescending(x => x.idFlotilla);
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            try
            {

                DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

                TControlVehicular Control = new TControlVehicular();

                //Control.idControl = int.Parse(formCollection["txtidControl"]);
                Control.claveServicio = formCollection["txtclaveServicio"];
                Control.destino = formCollection["txtdestino"];
                Control.fechaRegistro = DateTime.Now;
                Control.idFlotilla = 1;
                Control.fechaSalida = DateTime.Parse(formCollection["datefechaSalida"]);
                Control.horaSalida = formCollection["txthoraSalida"];
                Control.eluces = bool.Parse(((formCollection["checkeluces"]) == null ? "false" : "true").ToString());
                Control.ecuartoLuces = bool.Parse(((formCollection["checkecuartoLuces"]) == null ? "false" : "true").ToString());
                Control.eantena = bool.Parse(((formCollection["checkeantena"]) == null ? "false" : "true").ToString());
                Control.eespejoDerecho = bool.Parse(((formCollection["checkeespejoDerecho"]) == null ? "false" : "true").ToString());
                Control.eespejoIzquierdo = bool.Parse(((formCollection["checkeespejoIzquierdo"]) == null ? "false" : "true").ToString());
                Control.ecristales = bool.Parse(((formCollection["checkecristales"]) == null ? "false" : "true").ToString());
                Control.elogoMarca = bool.Parse(((formCollection["checkelogoMarca"]) == null ? "false" : "true").ToString());
                Control.ellantas4 = bool.Parse(((formCollection["checkellantas4"]) == null ? "false" : "true").ToString());
                Control.etapones4 = bool.Parse(((formCollection["checketapones4"]) == null ? "false" : "true").ToString());
                Control.emolduras = bool.Parse(((formCollection["checkemolduras"]) == null ? "false" : "true").ToString());
                Control.etaponGas = bool.Parse(((formCollection["checketaponGas"]) == null ? "false" : "true").ToString());
                Control.ecarroceria = bool.Parse(((formCollection["checkecarroceria"]) == null ? "false" : "true").ToString());
                Control.eclaxon = bool.Parse(((formCollection["checkeclaxon"]) == null ? "false" : "true").ToString());

                Control.itablero = bool.Parse(((formCollection["checkitablero"]) == null ? "false" : "true").ToString());
                Control.iclima = bool.Parse(((formCollection["checkiclima"]) == null ? "false" : "true").ToString());
                Control.iplumas = bool.Parse(((formCollection["checkiplumas"]) == null ? "false" : "true").ToString());
                Control.iradio = bool.Parse(((formCollection["checkiradio"]) == null ? "false" : "true").ToString());
                Control.ipantalla = bool.Parse(((formCollection["checkipantalla"]) == null ? "false" : "true").ToString());
                Control.icamara = bool.Parse(((formCollection["checkicamara"]) == null ? "false" : "true").ToString());
                Control.ibocinas = bool.Parse(((formCollection["checkibocinas"]) == null ? "false" : "true").ToString());
                Control.iencendedor = bool.Parse(((formCollection["checkiencendedor"]) == null ? "false" : "true").ToString());
                Control.iceniceros = bool.Parse(((formCollection["checkiceniceros"]) == null ? "false" : "true").ToString());
                Control.icinturones = bool.Parse(((formCollection["checkicinturones"]) == null ? "false" : "true").ToString());
                Control.imanijas = bool.Parse(((formCollection["checkimanijas"]) == null ? "false" : "true").ToString());
                Control.itapetes = bool.Parse(((formCollection["checkitapetes"]) == null ? "false" : "true").ToString());
                Control.ivestiduras = bool.Parse(((formCollection["checkivestiduras"]) == null ? "false" : "true").ToString());
                Control.agato = bool.Parse(((formCollection["checkagato"]) == null ? "false" : "true").ToString());
                Control.allave = bool.Parse(((formCollection["checkallave"]) == null ? "false" : "true").ToString());
                Control.aherramienta = bool.Parse(((formCollection["checkaherramienta"]) == null ? "false" : "true").ToString());
                Control.atriangulo = bool.Parse(((formCollection["checkatriangulo"]) == null ? "false" : "true").ToString());
                Control.allantarefa = bool.Parse(((formCollection["checkallantarefa"]) == null ? "false" : "true").ToString());
                Control.aextinguidor = bool.Parse(((formCollection["checkaextinguidor"]) == null ? "false" : "true").ToString());

                Control.tanque = formCollection["selecttanque"];

                Control.tcirculacion = bool.Parse(((formCollection["checktcirculacion"]) == null ? "false" : "true").ToString());
                Control.pseguro = bool.Parse(((formCollection["checkpseguro"]) == null ? "false" : "true").ToString());
                Control.tverficacion = bool.Parse(((formCollection["checktverficacion"]) == null ? "false" : "true").ToString());
                Control.licencia = bool.Parse(((formCollection["checklicencia"]) == null ? "false" : "true").ToString());
                Control.kmSalida = long.Parse(formCollection["txtkmSalida"]);
                Control.kmEntrada = long.Parse(formCollection["txtkmEntrada"]);
                Control.kmRecorrido = long.Parse(formCollection["txtkmRecorrido"]);

                Control.fechaEntrada = DateTime.Parse(formCollection["datefechaEntrada"]);
                Control.horaEntrada = formCollection["txthoraEntrada"];
                Control.observaciones = formCollection["txtobservaciones"];
                Control.estatus = 1;

                dbCtx.ctrolvehiculares.Add(Control);
                dbCtx.SaveChanges();

                return RedirectToAction("Registrar", "ControlVehicular");


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
            ViewBag.listaControlVehicular = dbCtx.ctrolvehiculares.OrderByDescending(x => x.idControl);
            return View();
        }

        [HttpGet]
        public ActionResult Modificar(int id) //-> idControl
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            //ViewBag.listaControlVehicular = dbCtx.ctrlvehicular.OrderByDescending(x => x.idControl);


            //ViewBag.modificarControl = dbCtx.ctrlvehicular.Find(id);

            ViewBag.modificarControl = dbCtx.ctrolvehiculares.Include(x1 => x1.parentFlotilla).Where(w1 => w1.idControl == id).First();

            return View();
        }

        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TControlVehicular Control = dbCtx.ctrolvehiculares.Find(int.Parse(formCollection["txtidControl"]));

            Control.destino = formCollection["txtdestino"];
            Control.idFlotilla = 2;
            Control.eluces = bool.Parse(((formCollection["checkeluces"]) == null ? "false" : "true").ToString());
            Control.ecuartoLuces = bool.Parse(((formCollection["checkecuartoLuces"]) == null ? "false" : "true").ToString());
            Control.eantena = bool.Parse(((formCollection["checkeantena"]) == null ? "false" : "true").ToString());
            Control.eespejoDerecho = bool.Parse(((formCollection["checkeespejoDerecho"]) == null ? "false" : "true").ToString());
            Control.eespejoIzquierdo = bool.Parse(((formCollection["checkeespejoIzquierdo"]) == null ? "false" : "true").ToString());
            Control.ecristales = bool.Parse(((formCollection["checkecristales"]) == null ? "false" : "true").ToString());
            Control.elogoMarca = bool.Parse(((formCollection["checkelogoMarca"]) == null ? "false" : "true").ToString());
            Control.ellantas4 = bool.Parse(((formCollection["checkellantas4"]) == null ? "false" : "true").ToString());
            Control.etapones4 = bool.Parse(((formCollection["checketapones4"]) == null ? "false" : "true").ToString());
            Control.emolduras = bool.Parse(((formCollection["checkemolduras"]) == null ? "false" : "true").ToString());
            Control.etaponGas = bool.Parse(((formCollection["checketaponGas"]) == null ? "false" : "true").ToString());
            Control.ecarroceria = bool.Parse(((formCollection["checkecarroceria"]) == null ? "false" : "true").ToString());
            Control.eclaxon = bool.Parse(((formCollection["checkeclaxon"]) == null ? "false" : "true").ToString());

            Control.itablero = bool.Parse(((formCollection["checkitablero"]) == null ? "false" : "true").ToString());
            Control.iclima = bool.Parse(((formCollection["checkiclima"]) == null ? "false" : "true").ToString());
            Control.iplumas = bool.Parse(((formCollection["checkiplumas"]) == null ? "false" : "true").ToString());
            Control.iradio = bool.Parse(((formCollection["checkiradio"]) == null ? "false" : "true").ToString());
            Control.ipantalla = bool.Parse(((formCollection["checkipantalla"]) == null ? "false" : "true").ToString());
            Control.icamara = bool.Parse(((formCollection["checkicamara"]) == null ? "false" : "true").ToString());
            Control.ibocinas = bool.Parse(((formCollection["checkibocinas"]) == null ? "false" : "true").ToString());
            Control.iencendedor = bool.Parse(((formCollection["checkiencendedor"]) == null ? "false" : "true").ToString());
            Control.iceniceros = bool.Parse(((formCollection["checkiceniceros"]) == null ? "false" : "true").ToString());
            Control.icinturones = bool.Parse(((formCollection["checkicinturones"]) == null ? "false" : "true").ToString());
            Control.imanijas = bool.Parse(((formCollection["checkimanijas"]) == null ? "false" : "true").ToString());
            Control.itapetes = bool.Parse(((formCollection["checkitapetes"]) == null ? "false" : "true").ToString());
            Control.ivestiduras = bool.Parse(((formCollection["checkivestiduras"]) == null ? "false" : "true").ToString());
            Control.agato = bool.Parse(((formCollection["checkagato"]) == null ? "false" : "true").ToString());
            Control.allave = bool.Parse(((formCollection["checkallave"]) == null ? "false" : "true").ToString());
            Control.aherramienta = bool.Parse(((formCollection["checkaherramienta"]) == null ? "false" : "true").ToString());
            Control.atriangulo = bool.Parse(((formCollection["checkatriangulo"]) == null ? "false" : "true").ToString());
            Control.allantarefa = bool.Parse(((formCollection["checkallantarefa"]) == null ? "false" : "true").ToString());
            Control.aextinguidor = bool.Parse(((formCollection["checkaextinguidor"]) == null ? "false" : "true").ToString());

            Control.tanque = formCollection["selecttanque"];

            Control.tcirculacion = bool.Parse(((formCollection["checktcirculacion"]) == null ? "false" : "true").ToString());
            Control.pseguro = bool.Parse(((formCollection["checkpseguro"]) == null ? "false" : "true").ToString());
            Control.tverficacion = bool.Parse(((formCollection["checktverficacion"]) == null ? "false" : "true").ToString());
            Control.licencia = bool.Parse(((formCollection["checklicencia"]) == null ? "false" : "true").ToString());
            Control.kmEntrada = long.Parse(formCollection["txtkmEntrada"]);
            Control.kmRecorrido = long.Parse(formCollection["txtkmRecorrido"]);
            Control.fechaEntrada = DateTime.Parse(formCollection["datefechaEntrada"]);
            Control.horaEntrada = formCollection["txthoraEntrada"];

            Control.observaciones = formCollection["txtobservaciones"]; dbCtx.SaveChanges();

            return RedirectToAction("Consulta", "ControlVehicular");
        }
    }
}