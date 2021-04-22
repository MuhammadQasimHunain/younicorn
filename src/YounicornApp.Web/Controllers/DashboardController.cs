using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YounicornApp.Core.Interfaces;
using YounicornApp.Web.ApiModels;

namespace YounicornApp.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IAnalyticsService _analyticsService;
        public DashboardController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAnalyticValues(AnalyticsRequestDTO request) 
        {
            var result = await _analyticsService.GetAnalytics(request: request.ToRequest());
            return Json(result);
        }
    }
}
