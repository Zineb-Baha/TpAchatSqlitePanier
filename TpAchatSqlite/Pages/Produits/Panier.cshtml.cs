using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using TpAchatSqlite.Models;
using Unity;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TpAchatSqlite.Pages.Produits
{

    public class PanierModel : PageModel
    {

       
        private readonly TpAchatSqlite.Data.TpAchatSqliteContext _context;
        [Inject]
        public IJSRuntime _jsRuntime { get; set; }

        public PanierModel(IJSRuntime jsRuntime, TpAchatSqlite.Data.TpAchatSqliteContext context)
        {
            _jsRuntime = jsRuntime;
            _context = context;
        }

        /*public List<Produit> ProduitsDansLePanier { get; set; } = new List<Produit>();
       [BindProperty(SupportsGet = true)]
       public List<Produit> ProduitsSelectionnes { get; set; } = new List<Produit>();
        */
        public decimal Total { get; set; }

        public void OnGet()
        {



        }





        /* private Produit GetProductDetailsFromDatabase(int productId)
         {
             // Utilisez Entity Framework Core pour interroger la base de données
             Produit product = _context.Produit
                 .Where(p => p.IDProduit == productId)
                 .SingleOrDefault(); // Vous pouvez utiliser SingleOrDefault pour obtenir un seul produit

             return product;
         }*/



    }
}
