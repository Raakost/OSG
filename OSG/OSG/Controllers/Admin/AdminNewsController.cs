using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSG.Controllers.Admin
{
    public class AdminNewsController : Controller
    {
        // GET: AdminNews
        public ActionResult Index()
        {
            return View();
        }
    }
}