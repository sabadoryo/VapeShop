using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VapeShop.Models;
using VapeShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop.Controllers
{
    public class VapeController : Controller
    {
        private readonly IVapeRepository _vapeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public VapeController(IVapeRepository vapeRepository, ICategoryRepository categoryRepository)
        {
            _vapeRepository = vapeRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /<controller>/
        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Cheese cakes";

        //    //return View(_pieRepository.AllPies);
        //    PiesListViewModel piesListViewModel = new PiesListViewModel();
        //    piesListViewModel.Pies = _pieRepository.AllPies;

        //    piesListViewModel.CurrentCategory = "Cheese cakes";
        //    return View(piesListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Vape> vapes;
            string currentCategory;

    

            if (string.IsNullOrEmpty(category))
            {
                vapes = _vapeRepository.AllVapes.OrderBy(p => p.VapeId);
                currentCategory = "All vapes";
            }
            else
            {
                vapes = _vapeRepository.AllVapes.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.VapeId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new VapesListViewModel
            {
                Vapes = vapes,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {

            var vape = _vapeRepository.GetVapeById(id);
            
            if (vape == null)
                return NotFound();

            return View(vape);
        }
    }
}
