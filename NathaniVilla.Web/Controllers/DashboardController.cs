﻿using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NathaniVilla.Application.Common.Interfaces;
using NathaniVilla.Application.Common.Utility;
using NathaniVilla.Application.Services.Implementation;
using NathaniVilla.Application.Services.Interface;
using NathaniVilla.Web.ViewModels;

namespace NathaniVilla.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;        

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetTotalBookingRadialChartData()
        {            
            return Json(await _dashboardService.GetTotalBookingRadialChartData());
        }
        public async Task<IActionResult> GetRegisteredUserChartData()
        {
            return Json(await _dashboardService.GetRegisteredUserChartData());
        }
        public async Task<IActionResult> GetRevenueChartData()
        {
            return Json(await _dashboardService.GetRevenueChartData());
        }
        public async Task<IActionResult> GetBookingPieChartData()
        {
            return Json(await _dashboardService.GetBookingPieChartData());
        }
        public async Task<IActionResult> GetMemberAndBookingLineChartData()
        {
            return Json(await _dashboardService.GetMemberAndBookingLineChartData());
        }
    }
}
