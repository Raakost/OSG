using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;

namespace OSG.Controllers.Admin
{
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

    }
}