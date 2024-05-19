using eticaretUygulama.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaretUygulama.Component
{
    public class TrendList :ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TrendList(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            //ürünlerin listesini dön
            var result=_context.Products.ToList();
            return View(result);
        }
    }
}
