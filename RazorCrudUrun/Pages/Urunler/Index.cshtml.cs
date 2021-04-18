using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudUrun.Data;
using RazorCrudUrun.Models;

namespace RazorCrudUrun.Pages.Urunler
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostDelete(int id)
        {
            var urun = _db.Urunler.Find(id);
            if (urun != null)
            {
                _db.Urunler.Remove(urun);
                _db.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
