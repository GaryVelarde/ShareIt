using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareIt.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrate()
        {
            ViewBag.FechaActual = DateTime.Now.ToShortDateString();
            return View();
        }

        public ActionResult DatosPersonales(string idUsuario)
        {
            Session["idUsuario"] = idUsuario;
            return View();
        }


        public JsonResult RegistrarUsuario(string nombres, string apellidos, string correo,
            string clave, DateTime fechaNacimiento, string celular)
        {
            List<Entidad.ResultadoSql> resSql = null;
            Negocio.Login qadoSer = new Negocio.Login();
            resSql = qadoSer.n_registrarUsuario(nombres, apellidos, correo, clave, fechaNacimiento, celular);
            return Json(resSql, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarUsuario(string correo, string clave)
        {
            List<Entidad.ResultadoSql> resSql = null;
            Negocio.Login qadoSer = new Negocio.Login();
            resSql = qadoSer.n_validarUsuario(correo, clave);
            return Json(resSql, JsonRequestBehavior.AllowGet);
        }
    }
}