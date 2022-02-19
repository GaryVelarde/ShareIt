using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareIt.Controllers
{
    public class ShareItController : Controller
    {
        // GET: ShareIt
        public ActionResult Index()
        {
            Session["sUser"] = "Gary‡Velarde Rios";
            ViewBag.TopPublicaciones = ListarTopPublicaciones();
            return View();
        }

        public JsonResult RegistrarPublicacion(Int64 usuarioId,string descripcion, string privacidad)
         {
            List<Entidad.ResultadoSql> resSql = null;
            Negocio.ShareIt qadoSer = new Negocio.ShareIt();
            resSql = qadoSer.n_registrarPublicacion(usuarioId, descripcion, privacidad);
            return Json(resSql, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarPrivacidad()
            {
            List<Entidad.Privacidad> resSql = null;
            Negocio.ShareIt qadoSer = new Negocio.ShareIt();
            resSql = qadoSer.n_listarPrivacidad();
            return Json(resSql, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult ListarTopPublicaciones()
            {
            List<Entidad.Publicacion> resSql = null;
            Negocio.ShareIt qadoSer = new Negocio.ShareIt();
            resSql = qadoSer.n_listarTopPublicaciones();
            return Json(resSql, JsonRequestBehavior.AllowGet);
        }

    }
}