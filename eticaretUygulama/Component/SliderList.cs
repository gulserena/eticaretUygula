﻿using eticaretUygulama.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaretUygulama.Component
{
    public class SliderList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SliderList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result=_context.Slider.ToList();
            return View(result);

        }
    }
}
