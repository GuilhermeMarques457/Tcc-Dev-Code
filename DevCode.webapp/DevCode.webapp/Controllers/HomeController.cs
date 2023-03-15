using DevCode.webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevCode.webapp.Controllers
{
    public class HomeController : Controller
    {
        //Página Inicial
        public ActionResult Index()
        {
            return View();
        }
    }
}