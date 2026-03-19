namespace _5TTI_DayaniPoty_Mael_UNO_UAA9;

class Program
{
    static void Main(string[] args)
    {
        string touche; //contient la touche entré par le joueur
        string[] jeuCartes; //paquet des cartes
        string[] mainJoueur; //paquet du joueur
        string[] mainOrdinateur; //paquet de l'ordinateur
        string carteTable; //carte sur la table

        FonctionProgram.AffichageAccueil(out touche);
        FonctionProgram.InitialiserCartes(out jeuCartes);

        // FonctionProgram.AfficherPremieresCartes(jeuCartes, 5, "5 premières cartes avant mélange :");
        FonctionProgram.MelangerCartes(jeuCartes);
        // FonctionProgram.AfficherPremieresCartes(jeuCartes, 5, "5 premières cartes après mélange :");

        FonctionProgram.DistributionCartes(jeuCartes, out mainJoueur, out mainOrdinateur, out carteTable);
        FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur);
    }
}