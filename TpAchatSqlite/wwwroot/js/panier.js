/*function ajouterAuPanier(idProduit) {
    // Récupérer la quantité saisie par l'utilisateur
    var quantite = parseInt(document.getElementById('quantite-' + idProduit).value);

    // Vérifier si la quantité est valide (supérieure à 0)
    if (quantite > 0) {
        // Récupérer le panier actuel depuis le stockage local
        var panier = JSON.parse(localStorage.getItem('panier')) || {};

        // Vérifier si le produit est déjà dans le panier
        if (panier.hasOwnProperty(idProduit)) {
            // Si le produit est déjà dans le panier, ajouter la quantité sélectionnée
            panier[idProduit] += quantite;
        } else {
            // Si le produit n'est pas encore dans le panier, l'ajouter
            panier[idProduit] = quantite;
        }

        // Stocker le panier mis à jour dans le stockage local
        localStorage.setItem('panier', JSON.stringify(panier));

        // Afficher un message de succès
        alert('Produit ajouté au panier.');

        // Vous pouvez également mettre à jour l'affichage du panier si nécessaire
    } else {
        alert('Veuillez saisir une quantité valide (supérieure à 0).');
    }
}*/
function ajouterAuPanier(idProduit) {
    // Récupérer la quantité saisie par l'utilisateur
    var quantite = parseInt(document.getElementById('quantite-' + idProduit).value);

    // Récupérer les informations du produit depuis la page
    var produit = {
        IDProduit: idProduit,
        NomProduit: document.getElementById('nomp-' + idProduit).textContent,
        Description: document.getElementById('description-' + idProduit).textContent,
        Prix: parseFloat(document.getElementById('prix-' + idProduit).textContent),
        //Stock: parseInt(document.getElementById('stock-' + idProduit).value),
        Marque: document.getElementById('marque-' + idProduit).textContent,
        Images: document.getElementById('imag-' + idProduit).textContent,
        Quantite: quantite
    };

    // Vérifier si la quantité est valide (supérieure à 0)
    if (quantite > 0) {
        // Récupérer le panier actuel depuis le stockage local
        var panier = JSON.parse(localStorage.getItem('panier')) || {};

        // Vérifier si le produit est déjà dans le panier
        if (panier.hasOwnProperty(idProduit)) {
            // Si le produit est déjà dans le panier, ajouter la quantité sélectionnée
            panier[idProduit].Quantite += quantite;
        } else {
            // Si le produit n'est pas encore dans le panier, l'ajouter avec toutes les informations du produit
            panier[idProduit] = produit;
        }

        // Stocker le panier mis à jour dans le stockage local
        localStorage.setItem('panier', JSON.stringify(panier));

        // Afficher un message de succès
        alert('Produit ajouté au panier.');

        // Vous pouvez également mettre à jour l'affichage du panier si nécessaire
    } else {
        alert('Veuillez saisir une quantité valide (supérieure à 0).');
    }
}
/*
function ajouterAuPanier(idProduit) {
    // Récupérer la quantité saisie par l'utilisateur
    var quantite = parseInt(document.getElementById('quantite-' + idProduit).value);

    // Vérifier si la quantité est valide (supérieure à 0)
    if (quantite > 0) {
        // Récupérer le panier actuel depuis le stockage local
        var panier = JSON.parse(localStorage.getItem('panier')) || {};

        // Vérifier si le produit est déjà dans le panier
        if (panier.hasOwnProperty(idProduit)) {
            // Si le produit est déjà dans le panier, ajouter la quantité sélectionnée
            panier[idProduit] += quantite;
        } else {
            // Si le produit n'est pas encore dans le panier, l'ajouter
            panier[idProduit] = quantite;
        }

        // Stocker le panier mis à jour dans le stockage local
        localStorage.setItem('panier', JSON.stringify(panier));

        // Afficher un message de succès
        alert('Produit ajouté au panier.');

        // Vous pouvez également mettre à jour l'affichage du panier si nécessaire
    } else {
        alert('Veuillez saisir une quantité valide (supérieure à 0).');
    }
}*/