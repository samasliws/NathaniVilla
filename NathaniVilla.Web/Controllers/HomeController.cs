using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using NathaniVilla.Application.Common.Interfaces;
using NathaniVilla.Web.Models;
using NathaniVilla.Web.ViewModels;
using System.Diagnostics;

namespace NathaniVilla.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll(includeProperties: "VillaAmenity"),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(HomeVM homeVM)
        {
            homeVM.VillaList = _unitOfWork.Villa.GetAll(includeProperties: "VillaAmenity");  
            
            return View(homeVM);
        }

        public IActionResult GetVillasByDate(int nights, DateOnly checkInDate)
        {
            //Thread.Sleep(2000);
            var villaList = _unitOfWork.Villa.GetAll(includeProperties: "VillaAmenity").ToList();
            foreach (var villa in villaList)
            {
                if (villa.Id % 2 == 0)
                {
                    villa.IsAvailable = false;
                }
            }
            HomeVM homeVM = new()
            {
                CheckInDate = checkInDate,
                VillaList = villaList,
                Nights = nights
            };

            return PartialView("_VillaList", homeVM);
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
