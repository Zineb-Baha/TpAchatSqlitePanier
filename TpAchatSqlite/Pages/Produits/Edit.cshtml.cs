using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpAchatSqlite.Data;
using TpAchatSqlite.Models;

namespace TpAchatSqlite.Pages.Produits
{
    public class EditModel : PageModel
    {
        private readonly TpAchatSqlite.Data.TpAchatSqliteContext _context;
        private readonly IWebHostEnvironment _e;
        public EditModel(TpAchatSqlite.Data.TpAchatSqliteContext context, IWebHostEnvironment e)
        {
            _context = context;
            _e = e;
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;
        [BindProperty]
        public IFormFile Pic2 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produit == null)
            {
                return NotFound();
            }

            var produit =  await _context.Produit.FirstOrDefaultAsync(m => m.IDProduit == id);
            if (produit == null)
            {
                return NotFound();
            }
            Produit = produit;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produit).State = EntityState.Modified;

            try
            {

                if (Pic2 != null && Pic2.Length > 0)
                {
                    // Generate a unique filename using a timestamp
                    var fileName = DateTime.Now.Ticks + Path.GetExtension(Pic2.FileName);

                    var uploadsFolder = Path.Combine(_e.WebRootPath, "Images");
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Ensure the uploads folder exists
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Pic2.CopyToAsync(fileStream);
                    }

                    // Save the file path in your database
                    Produit.Images = "/Images/" + fileName; // Update the path as per your project structure
                }

                // ...
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(Produit.IDProduit))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProduitExists(int id)
        {
          return (_context.Produit?.Any(e => e.IDProduit == id)).GetValueOrDefault();
        }
    }
}
