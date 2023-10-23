/*function ajouterAuPanier(idProduit) {
    // R�cup�rer la quantit� saisie par l'utilisateur
    var quantite = parseInt(document.getElementById('quantite-' + idProduit).value);

    // V�rifier si la quantit� est valide (sup�rieure � 0)
    if (quantite > 0) {
        // R�cup�rer le panier actuel depuis le stockage local
        var panier = JSON.parse(localStorage.getItem('panier')) || {};

        // V�rifier si le produit est d�j� dans le panier
        if (panier.hasOwnProperty(idProduit)) {
            // Si le produit est d�j� dans le panier, ajouter la quantit� s�lectionn�e
            panier[idProduit] += quantite;
        } else {
            // Si le produit n'est pas encore dans le panier, l'ajouter
            panier[idProduit] = quantite;
        }

        // Stocker le panier mis � jour dans le stockage local
        localStorage.setItem('panier', JSON.stringify(panier));

        // Afficher un message de succ�s
        alert('Produit ajout� au panier.');

        // Vous pouvez �galement mettre � jour l'affichage du panier si n�cessaire
    } else {
        alert('Veuillez saisir une quantit� valide (sup�rieure � 0).');
    }
}*/
function ajouterAuPanier(idProduit) {
    // R�cup�rer la quantit� saisie par l'utilisateur
    var quantite = parseInt(document.getElementById('quantite-' + idProduit).value);

    // R�cup�rer les informations du produit depuis la page
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

    // V�rifier si la quantit� est valide (sup�rieure � 0)
    if (quantite > 0) {
        // R�cup�rer le panier actuel depuis le stockage local
        var panier = JSON.parse(localStorage.getItem('panier')) || {};

        // V�rifier si le produit est d�j� dans le panier
        if (panier.hasOwnProperty(idProduit)) {
            // Si le produit est d�j� dans le panier, ajouter la quantit� s�lectionn�e
            panier[idProduit].Quantite += quantite;
        } else {
            // Si le produit n'est pas encore dans le panier, l'ajouter avec toutes les informations du produit
            panier[idProduit] = produit;
        }

        // Stocker le panier mis � jour dans le stockage local
        localStorage.setItem('panier', JSON.stringify(panier));

        // Afficher un message de succ�s
        alert('Produit ajout� au panier.');

        // Vous pouvez �galement mettre � jour l'affichage du panier si n�cessaire
    } else {
        alert('Veuillez saisir une quantit� valide (sup�rieure � 0).');
    }
}
/*
function ajouterAuPanier(idProduit) {
    // R�cup�rer la quantit� saisie par l'utilisateur
    var quantite = parseInt(document.getElementById('quantite-' + idProduit).value);

    // V�rifier si la quantit� est valide (sup�rieure � 0)
    if (quantite > 0) {
        // R�cup�rer le panier actuel depuis le stockage local
        var panier = JSON.parse(localStorage.getItem('panier')) || {};

        // V�rifier si le produit est d�j� dans le panier
        if (panier.hasOwnProperty(idProduit)) {
            // Si le produit est d�j� dans le panier, ajouter la quantit� s�lectionn�e
            panier[idProduit] += quantite;
        } else {
            // Si le produit n'est pas encore dans le panier, l'ajouter
            panier[idProduit] = quantite;
        }

        // Stocker le panier mis � jour dans le stockage local
        localStorage.setItem('panier', JSON.stringify(panier));

        // Afficher un message de succ�s
        alert('Produit ajout� au panier.');

        // Vous pouvez �galement mettre � jour l'affichage du panier si n�cessaire
    } else {
        alert('Veuillez saisir une quantit� valide (sup�rieure � 0).');
    }
}*/