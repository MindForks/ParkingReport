using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PR.Business.Services;
using PR.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR.Web.Controllers
{
    public class Assistant_ReportController : Controller
    {
        private string _userId { get { return User.Identity.GetUserId(); } }
        private readonly ReportAssistantService _ReportService;
        private readonly ReportStatusService _reportStatusService;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserService _userService;
        public Assistant_ReportController(ReportAssistantService ReportService, ReportStatusService reportStatusService, UserService userService, IHostingEnvironment appEnvironment)
        {
            _ReportService = ReportService;
            _reportStatusService = reportStatusService;
            _appEnvironment = appEnvironment;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewData["Statuses"] = _reportStatusService.GetAll()
               .Select(taskStatus => new SelectListItem
               {
                   Value = taskStatus.Id.ToString(),
                   Text = taskStatus.Title
               });

            var reports = _ReportService.GetAll();
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Statuses"] = _reportStatusService.GetAll()
                .Select(taskStatus => new SelectListItem
                {
                    Value = taskStatus.Id.ToString(),
                    Text = taskStatus.Title
                });
            var report = _ReportService.GetById(id);
            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]ReportDTO report)
        {
            _ReportService.Update(report);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var report = _ReportService.GetById(id);

            ViewData["Users"] = (await _userService.GetAllAsync())
             .Select(user => new SelectListItem
             {
                 Value = user.Id,
                 Text = String.Format("{0} {1} ({2})", user.LastName, user.FirstName, user.PhoneNumber)
             });
            ViewData["Statuses"] = _reportStatusService.GetAll()
                .Select(taskStatus => new SelectListItem
                {
                    Value = taskStatus.Id.ToString(),
                    Text = taskStatus.Title
                });

            return View(report);
        }
    }
}
