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
            Session["sUser"] = "Juanito‡Velarde Rios";
            return View();
        }
    }
}