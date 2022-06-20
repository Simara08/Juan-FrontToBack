using JuanFronttoEnd.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private AppDbContext _context { get; }
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model =await _context.Settings.ToDictionaryAsync(s => s.key, s => s.value);
            return View(model);
        }
    }
}
