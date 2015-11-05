using Nest;
using RandomSearchTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RandomSearchTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string query)
        {
            var model = new SearchPage();
            model.Results = Business.SearchManager.FindPerson(query).ToList();

            return View(model);
        }

    }
}