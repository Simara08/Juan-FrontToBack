using JuanFronttoEnd.DAL;
using JuanFronttoEnd.Helpers;
using JuanFronttoEnd.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env { get; }
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Slides);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!slider.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Image size must be smaller than 200kb");
                return View();
            }
            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file  must be image");
                return View();
            }

            slider.Image = await slider.Photo.SaveFileAsync(_env.WebRootPath, "img","slider");
            await _context.Slides.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async  Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var SlideDb = _context.Slides.Find(id);
            if (SlideDb==null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            var path = Helper.GetPath(_env.WebRootPath, "img", "slider",SlideDb.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
             _context.Slides.Remove(SlideDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var SlideDb = _context.Slides.Find(id);
            return View(SlideDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(int? id,Slider slide)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var SlideDb = _context.Slides.Find(id);
            if (SlideDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!slide.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Image size must be smaller than 200kb");
                return View();
            }
            if (!slide.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file  must be image");
                return View();
            }
            slide.Image = await slide.Photo.SaveFileAsync(_env.WebRootPath, "img", "slider");
            var path = Helper.GetPath(_env.WebRootPath, "img", "slider", SlideDb.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            SlideDb.Image = slide.Image;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
