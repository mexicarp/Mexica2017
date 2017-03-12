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
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult Registrar()
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listaEmpleados = dbCtx.empleados.OrderByDescending(x => x.idEmpleado).ToList();

            ViewBag.listaCiudades = dbCtx.ciudades.OrderByDescending(x => x.idCiudad).ToList();

            ViewBag.listaIden = dbCtx.tipoidentificaciones.OrderByDescending(x => x.idIdentificacion).ToList();

            //ViewBag.listaTipoEmp = dbCtx.tiposempleados.OrderByDescending(x => x.idTipoEmpleado).ToList();

            //ViewBag.listaTipoEmp = dbCtx.tiposempleados.OrderByDescending(x => x.idTipoEmpleado).ToList();

            ViewBag.listaPuestos = dbCtx.puestos.OrderByDescending(x => x.idPuesto).ToList();

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

                TEmpleado Empleados = new TEmpleado();

                //Empleados.idEmpleado = long.Parse(formCollection["txtidEmpleado"]);
                Empleados.fechaRegistro = DateTime.Now;
                Empleados.fechaIngreso = DateTime.Parse(formCollection["datefechaIngreso"]);
                Empleados.idEmpresa = int.Parse(formCollection["selectidEmpresa"]);
                Empleados.idPuesto = int.Parse(formCollection["selectidPuesto"]);
                Empleados.nombre = formCollection["txtnombre"];
                Empleados.paterno = formCollection["txtpaterno"];
                Empleados.materno = formCollection["txtmaterno"];
                Empleados.fechaNacimiento = DateTime.Parse(formCollection["datefechaNacimiento"]);
                Empleados.sexo = formCollection["selectsexo"];
                Empleados.curp = formCollection["txtcurp"];
                Empleados.rfc = formCollection["txtrfc"];
                Empleados.tipoSangre = formCollection["txttipoSangre"];
                Empleados.nacionalidad = int.Parse(formCollection["selectnacionalidad"]);
                Empleados.idCiudad = int.Parse(formCollection["selectidCiudad"]);
                Empleados.domicilio = formCollection["txtdomicilio"];
                Empleados.numero = formCollection["txtnumero"];
                Empleados.cp = int.Parse(formCollection["txtcp"]);
                Empleados.colonia = formCollection["txtcolonia"];
                Empleados.municipio = formCollection["txtmunicipio"];
                Empleados.idCiudad2 = int.Parse(formCollection["selectidCiudad2"]);
                Empleados.telefono = formCollection["txttelefono"];
                Empleados.email = formCollection["txtemail"];
                Empleados.idIdentificacion = int.Parse(formCollection["selectidIdentificacion"]);
                Empleados.numIdentificacion = formCollection["txtnumIdentificacion"];
                Empleados.fechaBaja = DateTime.Now;
                Empleados.motivoBaja = "-";
                Empleados.foto = "-";
                Empleados.estatus = int.Parse(formCollection["selectestatus"]);
                dbCtx.empleados.Add(Empleados);
                dbCtx.SaveChanges();

                return RedirectToAction("Consulta", "Empleado");
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
          
            ViewBag.listaEmpleados = dbCtx.empleados.Include(x1 => x1.parentcatEmpresas).OrderBy(x => x.idEmpleado).ToList();
            ViewBag.listaPuestos = dbCtx.puestos.OrderByDescending(x => x.idPuesto).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Modificar(int id)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();
            ViewBag.listaEmpleados = dbCtx.empleados.OrderByDescending(x => x.idEmpleado).ToList(); ;
            ViewBag.listaEmpresas = dbCtx.empresas.OrderByDescending(x => x.idEmpresa).ToList();
            ViewBag.listaCiudades = dbCtx.ciudades.OrderByDescending(x => x.idCiudad).ToList();
            ViewBag.listaIden = dbCtx.tipoidentificaciones.OrderByDescending(x => x.idIdentificacion).ToList();
            //ViewBag.listaTipoEmp = dbCtx.tiposempleados.OrderByDescending(x => x.idTipoEmpleado).ToList();
            ViewBag.listaPuestos = dbCtx.puestos.OrderByDescending(x => x.idPuesto).ToList();
            ViewBag.modificarEmpleado = dbCtx.empleados.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Modificar(FormCollection formCollection)
        {
            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            TEmpleado Empleados = dbCtx.empleados.Find(int.Parse(formCollection["txtidEmpleado"]));
            //Empleados.idEmpleado = long.Parse(formCollection["txtidEmpleado"]);
            Empleados.fechaRegistro = DateTime.Now;
            Empleados.fechaIngreso = DateTime.Parse(formCollection["datefechaIngreso"]);
            Empleados.idEmpresa = int.Parse(formCollection["selectidEmpresa"]);
            Empleados.idPuesto = int.Parse(formCollection["selectidPuesto"]);
            Empleados.nombre = formCollection["txtnombre"];
            Empleados.paterno = formCollection["txtpaterno"];
            Empleados.materno = formCollection["txtmaterno"];
            Empleados.fechaNacimiento = DateTime.Parse(formCollection["datefechaNacimiento"]);
            Empleados.sexo = formCollection["selectsexo"];
            Empleados.curp = formCollection["txtcurp"];
            Empleados.rfc = formCollection["txtrfc"];
            Empleados.tipoSangre = formCollection["txttipoSangre"];
            Empleados.nacionalidad = int.Parse(formCollection["selectnacionalidad"]);
            Empleados.idCiudad = int.Parse(formCollection["selectidCiudad"]);
            Empleados.domicilio = formCollection["txtdomicilio"];
            Empleados.numero = formCollection["txtnumero"];
            Empleados.cp = int.Parse(formCollection["txtcp"]);
            Empleados.colonia = formCollection["txtcolonia"];
            Empleados.municipio = formCollection["txtmunicipio"];
            Empleados.idCiudad2 = int.Parse(formCollection["selectidCiudad2"]);
            Empleados.telefono = formCollection["txttelefono"];
            Empleados.email = formCollection["txtemail"];
            Empleados.idIdentificacion = int.Parse(formCollection["selectidIdentificacion"]);
            Empleados.numIdentificacion = formCollection["txtnumIdentificacion"];
            Empleados.fechaBaja = DateTime.Now;
            Empleados.motivoBaja = "-";
            Empleados.foto = "-";
            Empleados.estatus = int.Parse(formCollection["selectestatus"]);
            dbCtx.SaveChanges();
            return RedirectToAction("Consulta", "Empleado");
        }
    }
}