using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TpAchatSqlite.Data;
using TpAchatSqlite.Models;

namespace TpAchatSqlite.Pages.Produits
{
    public class DeleteModel : PageModel
    {
        private readonly TpAchatSqlite.Data.TpAchatSqliteContext _context;

        public DeleteModel(TpAchatSqlite.Data.TpAchatSqliteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Produit Produit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }

            var produit = await _context.Produit.FirstOrDefaultAsync(m => m.IDProduit == id);

            if (produit == null)
            {
                return NotFound();
            }
            else 
            {
                Produit = produit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }
            var produit = await _context.Produit.FindAsync(id);

            if (produit != null)
            {
                Produit = produit;
                _context.Produit.Remove(Produit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
