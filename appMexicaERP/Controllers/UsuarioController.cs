using appMexicaERP.DAL;
using appMexicaERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace appMexicaERP.Controllers
{
    public class UsuarioController : Controller
    {
        
        private string randomString(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));

                builder.Append(ch);
            }

            return builder.ToString();
        }

        [HttpGet]
        public ActionResult CrearCuentaUsuario()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            return View();
        }

        [HttpPost]
        public string CrearCuentaUsuario(FormCollection formCollection)
        {
            string mensajeGlobal = "";

            string codigoVerificacionTemporal = randomString(15);

            using (DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext())
            {

                using (var dbContextTransaction = DbContext.Database.BeginTransaction())
                {
                    try
                    {

                        TUsuario Usuario = new TUsuario();

                        Usuario.idUsuario = Guid.NewGuid().ToString();
                        Usuario.correoElectronico = formCollection["txtCorreoElectronico"];
                        Usuario.estatus = formCollection["selectEstatus"].ToString() == "1" ? true : false;
                        Usuario.rol = int.Parse(formCollection["selectRol"]);
                        Usuario.permisos = formCollection["hdPermisos"];
                        Usuario.codigoVerificacion = codigoVerificacionTemporal;
                        Usuario.fechaInicioCodigoVerificacion = DateTime.Now;
                        Usuario.fechaFinalCodigoVerificacion = DateTime.Now.AddHours(2);
                        Usuario.fechaRegistro = DateTime.Now;
                        Usuario.fechaModificacion = DateTime.Now;

                        if (DbContext.Usuarios.Where(x => x.correoElectronico == Usuario.correoElectronico).FirstOrDefault() != null)
                        {

                            mensajeGlobal += "Este Correo ya existe en la DB";
                        }

                        if (!string.IsNullOrEmpty(mensajeGlobal))
                        {
                            return "<script>mostrarMensajeGlobal('" + mensajeGlobal + "', '" + System.Configuration.ConfigurationManager.AppSettings["colorError"] + "');</script>";
                        }

                        DbContext.Usuarios.Add(Usuario);

                        DbContext.SaveChanges();

                        dbContextTransaction.Commit();

                        //MailMessage mail = new MailMessage();

                        //mail.To.Add(Usuario.correoElectronico);
                        //mail.From = new MailAddress("ovallesoft@gmail.com");
                        //mail.Subject = "Codigo de Verificación.";
                        //mail.IsBodyHtml = true;
                        //mail.Body = "Copie este código: " + codigoVerificacionTemporal + " y acceda a esta URL: " + "http://localhost:53151/Usuario/Registrar/" + Usuario.idUsuario;

                        //SmtpClient smtp = new SmtpClient();

                        //smtp.Host = "smtp.gmail.com";
                        //smtp.Port = 465;
                        //smtp.UseDefaultCredentials = false;
                        //smtp.Credentials = new System.Net.NetworkCredential("ovalles.prueba@gmail.com", "cuoa890606");
                        //smtp.EnableSsl = true;

                        //smtp.Send(mail);

                        return "<script>mostrarMensajeGlobal('Se ha registrado con exito', '" + System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"] + "');</script>";
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
        public ActionResult Registrar(string id)
        {

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            ViewBag.datosUsuario = DbContext.Usuarios.Where(x => x.idUsuario == id).FirstOrDefault();

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

                        TUsuario Usuario = DbContext.Usuarios.Find(formCollection["txtIdUsuario"]);

                        Usuario.nombre = formCollection["txtNombre"];
                        Usuario.apellidos = formCollection["txtApellidos"];
                        Usuario.correoElectronico = formCollection["txtCorreoElectronico"];
                        Usuario.contrasenia = formCollection["txtPassword"];
                        Usuario.codigoVerificacion = formCollection["txtCodigoVerificacion"];
                        Usuario.fechaModificacion = DateTime.Now;

                        DbContext.SaveChanges();

                        dbContextTransaction.Commit();

                        return "<script>mostrarMensajeGlobal('Se ha enviado un código en su correo eltrónico', '" + System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"] + "');</script>";
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

                        return "<script>mostrarMensajeGlobal('" + mensajeGlobal + "', '" + System.Configuration.ConfigurationManager.AppSettings["colorError"] + "');</script>";
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Sesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sesion(FormCollection formCollection)
        {

            string txtCorreoElectronico = formCollection["txtCorreoElectronicoTemporal"];
            string txtContrasenia = formCollection["txtContraseniaTemporal"];

            DBappWebMexicaERPcontext DbContext = new DBappWebMexicaERPcontext();

            TUsuario DatosAccesoUsuario = DbContext.Usuarios.Where(x => x.correoElectronico == txtCorreoElectronico && x.contrasenia == txtContrasenia).FirstOrDefault();

            if (DatosAccesoUsuario == null)
            {
                TempData["mensajeGlobal"] = "Correo Electrónico o password incorrecto.<br>";
                TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorError"];

                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            Session["rol"] = DatosAccesoUsuario.rol;
            Session["nombre"] = DatosAccesoUsuario.nombre;
            Session["correoElectronico"] = DatosAccesoUsuario.correoElectronico;
            Session["idUsuario"] = DatosAccesoUsuario.idUsuario;

            TempData["mensajeGlobal"] = "Bienvenido al sistema.<br>";
            TempData["color"] = System.Configuration.ConfigurationManager.AppSettings["colorCorrecto"];
            HttpContext.Application["Usuario"] = DatosAccesoUsuario.nombre;

            return Redirect("Index");


        }

        [HttpGet]
        public ActionResult Logout()
        {

            HttpContext.Session.Clear();

            return Redirect(Url.Action("Sesion", "Usuario"));
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            return View();
        }

        [HttpGet]
        public ActionResult Ver()
        {
            if (Session["correoElectronico"] == null)
            {
                return Redirect(Url.Action("Sesion", "Usuario"));
            }

            DBappWebMexicaERPcontext dbCtx = new DBappWebMexicaERPcontext();

            ViewBag.listausuarios = dbCtx.Usuarios.OrderByDescending(x => x.idUsuario).ToList();


            return View();
        }
    }
}