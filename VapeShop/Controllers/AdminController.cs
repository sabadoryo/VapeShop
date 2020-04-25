using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IVapeRepository _vapeRepository;
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IVapeRepository vapeRepository, ICategoryRepository categoryRepository, AppDbContext appDbContext)
        {
            _vapeRepository = vapeRepository;
            _appDbContext = appDbContext;
            _categoryRepository = categoryRepository;
        }
        // GET: /<controller>/

        public ActionResult Index()
        {
            return View(_vapeRepository.AllVapes.ToList());
        }

        public IActionResult CreatePage()
        {
            ViewBag.Categories = _categoryRepository.AllCategories.Select(li => new SelectListItem
            { Text = li.CategoryName, Value = li.CategoryId.ToString() });
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vape vape)
        {
            vape.CategoryId = 3;
            // _pieRepository.CreatePie(pie);
            _appDbContext.Vapes.Add(vape);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        /*
        [HttpPost]
        public ActionResult CreatePies(Pie pies)
        {
            db.Pies.Add(pies);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }*/
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Vape vape = _vapeRepository.AllVapes.Where(s => s.VapeId == id).First();
                _appDbContext.Vapes.Remove(vape);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        
        public ActionResult Update(int id)
        {
            return View(_vapeRepository.AllVapes.Where(s => s.VapeId == id).First());
        }
        
        [HttpPost]
        public ActionResult UpdateVape(Vape vapes)
        {
            Vape p = _appDbContext.Vapes.Where(s => s.VapeId == vapes.VapeId).First();
            p.Name = vapes.Name;
            p.Price = vapes.Price;
            p.ShortDescription = vapes.ShortDescription;
            p.LongDescription = vapes.LongDescription;
            _appDbContext.Vapes.Update(p);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


    }
}
