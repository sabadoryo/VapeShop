using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;
using VapeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVapeRepository _vapeRepository;

        public HomeController(IVapeRepository vapeRepository)
        {
            _vapeRepository = vapeRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                VapesOfTheWeek = _vapeRepository.VapesOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
