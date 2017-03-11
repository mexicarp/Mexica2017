using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using appMexicaERP.Models;
using System.Data.Entity;
using appMexicaERP.DAL;

namespace appMexicaERP.Controllers
{
    public class VentaController : Controller
    {

        [HttpGet]
        public ActionResult Insertar()
        {

            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            //ViewBag.listaTour = DbContext.Tours.OrderBy(x => x.id_tour);
            //ViewBag.listaTour = DbContext.CatalogoTours.OrderBy(x => x.idTour);
            ViewBag.listaAgencia = DbContext.Agencias.OrderBy(x => x.idAgencia).Where(x => x.estatus==1);

            ViewBag.listaFormaPago = DbContext.FormaPagos.OrderBy(x => x.idFormaPago);
            ViewBag.listaPaquete = DbContext.Paquetes.OrderBy(x => x.idPaquete);
            //ViewBag.listaPaqueteTour = DbContext.PaqueteDetalles.Include(i1 => i1.parenTour).Where(w1 => w1.idPaquete == 0).ToList();

            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();
            return View();
        }

        [HttpPost]
        public ActionResult TblPaquete(int id)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();
            //ViewBag.listaPaqueteTour = DbContext.PaqueteDetalles.Include(i1 => i1.parenTour).Where(w1 => w1.idPaquete == id).ToList();
            return View();
        }

        //---------------------------------------------------------------------------------

        [HttpPost]
        public ActionResult InsertarTour(FormCollection formCollection)//recolectar toda la informacion que hay dentro del formulario
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TVenta Venta = new TVenta();
            Venta.fechaRegistro = DateTime.Now;
            Venta.idEmpleado = 1;
            Venta.fechaVenta = DateTime.Parse(formCollection["fechaVentat"]);
            Venta.idProducto = 0; //int.Parse(formCollection["idProducto"]);
            if (formCollection["idTour"] != null)
            {
                Venta.idTour = int.Parse(formCollection["idTour"]);
            }
            else
            {
                Venta.idTour = 0;
            }
            if (formCollection["idPaquete"] != null)
            {
                Venta.idPaquete = int.Parse(formCollection["idPaquete"]);
            }
            else
            {
                Venta.idPaquete = 0;
            }            
            Venta.tipo_costo = "MEXICA";//formCollection["tipo_costot"];
            Venta.costoVenta = 13.3;//double.Parse(formCollection["costoVentat"]);
            Venta.costoVendido = double.Parse(formCollection["ttpagar"]);
            Venta.adultos = int.Parse(formCollection["adultost"]);
            Venta.ninos = int.Parse(formCollection["ninost"]);
            Venta.pax = int.Parse(formCollection["paxt"]);
            Venta.fechaInicio = DateTime.Parse(formCollection["fechaIniciot"]);
            Venta.fechaFin = DateTime.Parse(formCollection["fechaFint"]);
            Venta.cliente = formCollection["clientet"];
            Venta.telefono = formCollection["telefonot"];
            Venta.correo = formCollection["correot"];
            Venta.observaciones = formCollection["observacionest"];
            Venta.recoger = formCollection["recogert"];
            Venta.idFormaPago = int.Parse(formCollection["idFormaPagot"]);
            Venta.banco = "banco_x";//formCollection["banco"];
            Venta.total = double.Parse(formCollection["totalt"]);
            Venta.anticipo = double.Parse(formCollection["anticipot"]);
            Venta.saldo = double.Parse(formCollection["saldot"]);
            Venta.utilidadBruta = double.Parse("100");//(formCollection["utilidadBrutat"]);
            Venta.comisionPagar = double.Parse("100");//(formCollection["comisionPagart"]);
            Venta.utilidadNeta = double.Parse("100");//(formCollection["utilidadNetat"]);
            Venta.referencia = formCollection["referenciat"];
            Venta.fechaModificacion = DateTime.Now;//DateTime.Parse(formCollection["fechaVentat"]);
            Venta.fechaCancelacion = DateTime.Now;//DateTime.Parse(formCollection["fechaVentat"]);
            Venta.motivoCancelacion = "NoDatos";// formCollection["motivoCancelaciont"];
            Venta.estatus = 1;
            Venta.nombreusu = (HttpContext.Application["Usuario"]).ToString();
            Venta.costoaxkan = double.Parse(formCollection["costoVentaax"]);
            Venta.costoagencia = double.Parse(formCollection["costoVentaag"]);
            Venta.ventanino = double.Parse(formCollection["costonino"]);
            Venta.ventaadulto = double.Parse(formCollection["costoAdulto"]);
            DbContext.Ventas.Add(Venta);
            DbContext.SaveChanges();
            return RedirectToAction("Insertar", "Venta");
        }

        [HttpPost]
        public ActionResult InsertarPaquete(FormCollection formCollection)//recolectar toda la informacion que hay dentro del formulario
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TVenta Venta = new TVenta();
            Venta.fechaRegistro = DateTime.Now;
            Venta.idEmpleado = 1;
            Venta.fechaVenta = DateTime.Parse(formCollection["fechaVentap"]);
            Venta.idProducto = 0; //int.Parse(formCollection["idProducto"]);
            if (formCollection["idTour"] != null)
            {
                Venta.idTour = int.Parse(formCollection["idTour"]);
            }
            else
            {
                Venta.idTour = 0;
            }
            if (formCollection["idPaquete"] != null)
            {
                Venta.idPaquete = int.Parse(formCollection["idPaquete"]);
            }
            else
            {
                Venta.idTour = 0;
            }


            Venta.tipo_costo = "MEXICA";//formCollection["tipo_costo"];
            Venta.costoVenta = double.Parse(formCollection["costoVentap"]);
            Venta.costoVendido = double.Parse(formCollection["costoVendidop"]);
            Venta.adultos = int.Parse(formCollection["adultosp"]);
            Venta.ninos = int.Parse(formCollection["ninosp"]);
            Venta.pax = int.Parse(formCollection["paxp"]);
            Venta.fechaInicio = DateTime.Parse(formCollection["fechaIniciop"]);
            Venta.fechaFin = DateTime.Parse(formCollection["fechaFinp"]);
            Venta.cliente = formCollection["clientep"];
            Venta.telefono = formCollection["telefonop"];
            Venta.correo = formCollection["correop"];
            Venta.observaciones = formCollection["observacionesp"];
            Venta.recoger = formCollection["recogerp"];
            Venta.idFormaPago = int.Parse(formCollection["idFormaPagop"]);
            Venta.banco = "banco_x";//formCollection["banco"];
            Venta.total = double.Parse(formCollection["totalp"]);
            Venta.anticipo = double.Parse(formCollection["anticipop"]);
            Venta.saldo = double.Parse(formCollection["saldop"]);
            Venta.utilidadBruta = double.Parse("100");//(formCollection["utilidadBruta"]);
            Venta.comisionPagar = double.Parse("100");//(formCollection["comisionPagar"]);
            Venta.utilidadNeta = double.Parse("100");//(formCollection["utilidadNeta"]);
            Venta.referencia = formCollection["referenciap"];
            Venta.fechaModificacion = DateTime.Now;//DateTime.Parse(formCollection["fechaVenta"]);
            Venta.fechaCancelacion = DateTime.Now;//DateTime.Parse(formCollection["fechaVenta"]);
            Venta.motivoCancelacion = "CENCELACION";// formCollection["motivoCancelacion"];
            Venta.estatus = 1;
            DbContext.Ventas.Add(Venta);
            DbContext.SaveChanges();
            return RedirectToAction("Insertar", "Venta");
        }
    }
}