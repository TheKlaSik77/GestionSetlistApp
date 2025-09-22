export enum TypePage {
  Morceau = "morceau",
  Setlist = "setlist",
  Membre = "membre"
}

// Associer directement les filtres à chaque type de page
export const FILTRES_PAR_PAGE: Record<TypePage, string[]> = {
  [TypePage.Morceau]: ["Titre", "Artiste", "Album", "Récemment Ajouté"],
  [TypePage.Setlist]: ["Nom", "Date", "Nombre de morceaux"],
  [TypePage.Membre]: ["Nom", "Rôle", "Instrument"]
};
