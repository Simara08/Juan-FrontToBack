using JuanFronttoEnd.DAL;
using JuanFronttoEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.Controllers
{
    public class HomeController : Controller
    {
            private AppDbContext _db { get; }
            public HomeController(AppDbContext db)
            {
                _db = db;
            }
        public IActionResult Index()
        {
            HomeViewModel home = new HomeViewModel
            {
                Slides = _db.Slides.ToList(),
                Features= _db.Features.ToList(),
                Categories = _db.Categories.Where(c => !c.IsDeleted)
                .Include(pc => pc.ProductsCategories).ThenInclude(ct => ct.Product).ToList(),
                Products = _db.Products.Where(p => !p.IsDeleted).Include(p => p.Images).ToList(),
                Blogs= _db.Blogs.ToList(),
                Brands = _db.Brands.ToList()
            };

            return View(home);
        }
    }
}
