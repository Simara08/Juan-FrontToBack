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
    public class ShopControllers : Controller
    {
        private AppDbContext _db { get; }
        public ShopControllers(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
