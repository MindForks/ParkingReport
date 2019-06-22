using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR.Business.Services;
using PR.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.Web.Controllers
{
    public class ReportController : Controller
    {
        private string _userId { get { return User.Identity.GetUserId(); } }
        private readonly ReportService _ReportService;
        private readonly IHostingEnvironment _appEnvironment;

        public ReportController(ReportService ReportService, IHostingEnvironment appEnvironment)
        {
            _ReportService = ReportService;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult List()
        {
            var reports = _ReportService.GetAll(_userId);
            return View(reports);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var report = new ReportDTO()
            {
                UserId = _userId
            };
            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]ReportDTO report)
        {
            if (ModelState.IsValid)
            {
                _ReportService.Create(report, _appEnvironment);
            }

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var report = _ReportService.GetById(id, _userId);
            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]ReportDTO report)
        {
            if (ModelState.IsValid)
            {
                _ReportService.Update(report, _userId);
            }
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _ReportService.Delete(id, _userId);
            return RedirectToAction(nameof(List));
        }
    }
}
