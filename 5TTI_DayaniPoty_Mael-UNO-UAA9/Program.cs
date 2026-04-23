namespace _5TTI_DayaniPoty_Mael_UNO_UAA9;

class Program
{
    static void Main(string[] args)
    {
        string recommencer;
        string touche; //contient la touche entré par le joueur
        string[] jeuCartes; //paquet des cartes
        string[] mainJoueur; //paquet du joueur
        string[] mainOrdinateur; //paquet de l'ordinateur
        string carteTable; //carte sur la table
        int indexPaquet; //index des cartes dans le paquet global
        bool tourSaute;

        FonctionProgram.AffichageAccueil(out touche);
        FonctionProgram.InitialiserCartes(out jeuCartes);
        FonctionProgram.MelangerCartes(jeuCartes);
        FonctionProgram.DistributionCartes(jeuCartes, out mainJoueur, out mainOrdinateur, out carteTable, out indexPaquet);
        FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur, true);

        do
        {
            // Tour du joueur
            FonctionProgram.ChoixCarteJoueur(ref mainJoueur, jeuCartes, ref indexPaquet, ref carteTable);
            FonctionProgram.AppliquerEffetCarte(carteTable, ref mainJoueur, ref mainOrdinateur, jeuCartes, ref indexPaquet, ref carteTable, true, out tourSaute);

            if (!tourSaute) // tour ordi sauté si carte spéciale
            {
                FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur, false);
                FonctionProgram.TourOrdinateur(ref mainOrdinateur, jeuCartes, ref indexPaquet, ref carteTable);
                FonctionProgram.AppliquerEffetCarte(carteTable, ref mainJoueur, ref mainOrdinateur, jeuCartes, ref indexPaquet, ref carteTable, false, out tourSaute);
            }

            FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur, true);

            // Console.WriteLine("Voulez-vous recommencer ? (tapez ' ' pour recommencer)");
            // recommencer = Console.ReadLine() ?? "";
        } while (true);

    }
}