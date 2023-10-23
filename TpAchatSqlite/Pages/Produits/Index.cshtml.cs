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
    public class IndexModel : PageModel
    {
        private readonly TpAchatSqlite.Data.TpAchatSqliteContext _context;

        public IndexModel(TpAchatSqlite.Data.TpAchatSqliteContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string nom { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string marque { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public double prix_min { get; set; } 
        [BindProperty(SupportsGet = true)]
        public double prix_max { get; set; } 
        public IList<Produit> Produit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var produits = from m in _context.Produit where (double)m.Prix>=prix_min select m ;
            if (!String.IsNullOrEmpty(nom))
            {
                produits = produits.Where(s => s.NomProduit.ToUpper().Contains(nom.ToUpper()));
            }
            if (marque!=null)
            {
                produits = produits.Where(s => s.Marque.ToUpper().Contains(marque.ToUpper()));
            }
            

            if (prix_max > 0)
            {
                produits = produits.Where(s => (double)s.Prix <= prix_max);
            }
            Produit = await produits.ToListAsync();

        }

    
    }
}
