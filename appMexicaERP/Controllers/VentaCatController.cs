using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using appMexicaERP.Models;
using System.Data.Entity;
using appMexicaERP.DAL;
using System.Data.Entity.Validation;

namespace appMexicaERP.Controllers
{
    public class VentaCatController : Controller
    {
        // GET: VentaCat
        [HttpGet]
        public ActionResult CatVentas()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.listaCategoria = DbContext.CategoriasTours.OrderBy(x => x.idcategoriatour).ToList();
            ViewBag.listaTour = DbContext.CatalogoTours.OrderBy(x => x.idTour).Where(x => x.estatus == 1).ToList();
            ViewBag.listaAgencia = DbContext.Agencias.OrderBy(x => x.idAgencia).Where(x => x.estatus == 1).ToList();
            ViewBag.listaTourPrecios = DbContext.Precios.Include(i1 => i1.parenTours).Include(i1 => i1.parenAgencias).Where(x=> x.estatus==1).ToList();//Where(w1 => w1.idAgencia == id).ToList();

            return View();
        }

        [HttpGet]
        public ActionResult EliminaTour(FormCollection formCollection, string id)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TTourCat EliminaTour = DbContext.CatalogoTours.Find(int.Parse(id));
            EliminaTour.estatus = 0;
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpGet]
        public ActionResult EliminaAgencia(FormCollection formCollection, string id)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TAgencia EliminaAgencia = DbContext.Agencias.Find(int.Parse(id));
            EliminaAgencia.estatus = 0;
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpGet]
        public ActionResult EliminaPrecio(FormCollection formCollection, string id)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TPrecio EliminaPrecio = DbContext.Precios.Find(int.Parse(id));
            EliminaPrecio.estatus = 0;
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpPost]
        public ActionResult InsertarCatTour(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();
            TTourCat InsertCatTour = new TTourCat();

            InsertCatTour.idcategoriatour = int.Parse(formCollection["idcategoriatour"]);
            InsertCatTour.fechaRegistro = DateTime.Now;
            InsertCatTour.tour = formCollection["tour"];
            InsertCatTour.descripcion = formCollection["descripcion"];
            InsertCatTour.origen = formCollection["origen"];
            InsertCatTour.destino = formCollection["destino"];
            InsertCatTour.horaSalida = formCollection["horaSalida"];
            InsertCatTour.horaRegreso = formCollection["horaRegreso"];
            InsertCatTour.duracion = formCollection["duracion"];
            InsertCatTour.lunes = 0;//int.Parse(formCollection["lunes"]);
            InsertCatTour.martes = 0;//int.Parse(formCollection["martes"]);
            InsertCatTour.miercoles = 0;//int.Parse(formCollection["miercoles"]);
            InsertCatTour.jueves = 0;//int.Parse(formCollection["jueves"]);
            InsertCatTour.viernes = 0;//int.Parse(formCollection["viernes"]);
            InsertCatTour.sabado = 0;//int.Parse(formCollection["sabado"]);
            InsertCatTour.domingo = 0;//int.Parse(formCollection["domingo"]);
            InsertCatTour.km = 0;//int.Parse(formCollection["domingo"]);
            InsertCatTour.gas = 0;//int.Parse(formCollection["domingo"]);
            InsertCatTour.casetas = 0;//int.Parse(formCollection["domingo"]);
            InsertCatTour.extra = 0;//int.Parse(formCollection["domingo"]);
            InsertCatTour.numPasajeros = 0;//int.Parse(formCollection["domingo"]);
            InsertCatTour.estatus = 1;//int.Parse(formCollection["domingo"]);
            DbContext.CatalogoTours.Add(InsertCatTour);
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpPost]
        public ActionResult InsertarCatAgencia(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();
            TAgencia InsertCatAgencia = new TAgencia();
            InsertCatAgencia.idTour = int.Parse(formCollection["idTour"]);
            InsertCatAgencia.nombre = formCollection["nombre"];
            InsertCatAgencia.direccion = formCollection["direccion"];
            InsertCatAgencia.descripcion = formCollection["descripcion"];
            InsertCatAgencia.fechaRegistro = DateTime.Now;
            InsertCatAgencia.fechaModificacion = DateTime.Now;
            InsertCatAgencia.estatus = 1;
            DbContext.Agencias.Add(InsertCatAgencia);
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpPost]
        public ActionResult InsertarCatPrecio(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();
            TPrecio InserCatPrecios = new TPrecio();
            InserCatPrecios.idAgencia = int.Parse(formCollection["idAgencia"]);
            InserCatPrecios.idTour = int.Parse(formCollection["idTour"]);
            InserCatPrecios.nombre = "OK";//formCollection["nombre"];
            InserCatPrecios.precioALta = Double.Parse(formCollection["precioALta"]);
            InserCatPrecios.precioBaja = Double.Parse(formCollection["precioBaja"]);
            InserCatPrecios.fechaRegistro = DateTime.Now;
            InserCatPrecios.fechaModificacion = DateTime.Now;
            InserCatPrecios.estatus = 1;
            DbContext.Precios.Add(InserCatPrecios);
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpPost]
        public ActionResult LlenaTour(int id)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();
            ViewBag.listaTour = DbContext.Precios.Include(i1 => i1.parenTours).Where(w1 => w1.idAgencia == id).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult EditaTour(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TTourCat EditaTour = DbContext.CatalogoTours.Find(int.Parse(formCollection["idTourEdit"]));
            EditaTour.tour = formCollection["tourEdit"];
            EditaTour.descripcion = formCollection["descripcionEdit"];
            EditaTour.origen = formCollection["origenEdit"];
            EditaTour.destino = formCollection["destinoEdit"];
            EditaTour.horaSalida = formCollection["horaSalidaEdit"];
            EditaTour.horaRegreso = formCollection["horaRegresoEdit"];
            EditaTour.duracion = formCollection["duracionEdit"];
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpPost]
        public ActionResult EditaAgencia(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TAgencia EditaAgencia = DbContext.Agencias.Find(int.Parse(formCollection["idAgenciaEdit"]));
            EditaAgencia.nombre = formCollection["nombreEdit"];
            EditaAgencia.direccion = formCollection["direccionEdit"];
            EditaAgencia.descripcion = formCollection["descripcionEditA"];
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

        [HttpPost]
        public ActionResult EditaPrecio(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TPrecio EditaPrecio = DbContext.Precios.Find(int.Parse(formCollection["idPrecioEdit"]));
            EditaPrecio.precioALta = Double.Parse(formCollection["precioAltaEdit"]);
            EditaPrecio.precioBaja = Double.Parse(formCollection["precioBajaEdit"]);
            DbContext.SaveChanges();
            return RedirectToAction("CatVentas", "VentaCat");
        }

    }
}