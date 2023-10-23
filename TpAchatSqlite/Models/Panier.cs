namespace TpAchatSqlite.Models
{
    public class Panier
    {
        public List<LignePanier> Items { get; set; } //panier composé de 1..* items

        public Panier()
        {
            Items = new List<LignePanier>();
        }

        public void AddItem(Produit product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProduitId == product.IDProduit);

            if (existingItem != null)
            {
                existingItem.Quantite += quantity; // si l item existe deja dans le panier on augmente que sa nouvelle quantité
            }
            else//sinon on ajoute un nouveu item dans le panier avec la quantité specifiée lors de l'ajout dans le panier
            {
                var newItem = new LignePanier
                {
                    ProduitId = product.IDProduit,
                    Prix = product.Prix,
                    Quantite = quantity
                };
                Items.Add(newItem);
            }
        }

        public void RemoveItem(int productId)
        {
            // remove items from panier
            var itemToRemove = Items.FirstOrDefault(item => item.ProduitId == productId);

            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

    }
}
