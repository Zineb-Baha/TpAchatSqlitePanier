using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TpAchatSqlite.Data;
using TpAchatSqlite.Models;

namespace TpAchatSqlite.Pages.Produits
{
    public class CreateModel : PageModel
    {
        private readonly TpAchatSqlite.Data.TpAchatSqliteContext _context;
        private readonly IWebHostEnvironment _e;


        public CreateModel(TpAchatSqlite.Data.TpAchatSqliteContext context, IWebHostEnvironment e)
        {
            _context = context;
            _e = e;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;
        [BindProperty]
        public IFormFile? Pic { get; set; } 


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Produit == null || Produit == null)
            {
                return Page();
            }
            if (Pic != null && Pic.Length > 0)
            {
                // Generate a unique filename using a timestamp
                var fileName = DateTime.Now.Ticks + Path.GetExtension(Pic.FileName);

                var uploadsFolder = Path.Combine(_e.WebRootPath, "Images");
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Ensure the uploads folder exists
                Directory.CreateDirectory(uploadsFolder);

                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Pic.CopyToAsync(fileStream);
                }

                // Save the file path in your database
                Produit.Images = "/Images/" + fileName; // Update the path as per your project structure
            }

            _context.Produit.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
