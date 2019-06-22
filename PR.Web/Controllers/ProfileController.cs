using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PR.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Edit()
        {
            //todo create views for methods by model
            return View();
        }
        public IActionResult View()
        {
            return View();
        }
    }
}