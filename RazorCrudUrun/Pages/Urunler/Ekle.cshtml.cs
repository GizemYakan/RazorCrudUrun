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
    public class EkleModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Urun Urun { get; set; }
        public EkleModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Urunler.Add(Urun);
                _db.SaveChanges();
                return RedirectToPage("/Urunler/Index");
            }
            return Page();
        }

    }
}
