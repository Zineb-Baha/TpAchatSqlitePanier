using System.ComponentModel.DataAnnotations;

namespace TpAchatSqlite.Models
{
    public class Produit
    {
        [Key]
        public int IDProduit { get; set; }           // Identifiant unique du produit
        public string NomProduit { get; set; } = string.Empty;      // Nom du produit
        public string Description { get; set; } = string.Empty;      // Description du produit
        public decimal Prix { get; set; }           // Prix du produit
        public int Stock { get; set; }              // Stock disponible
        public string Marque { get; set; } = string.Empty;          // Marque du produit
        public string Images { get; set; } = string.Empty;          // Liens vers les images
        public DateTime DateAjout { get; set; }     // Date d'ajout
    }
}
