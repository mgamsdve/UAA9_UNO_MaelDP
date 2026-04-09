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
        
        FonctionProgram.AffichageAccueil(out touche);
        FonctionProgram.InitialiserCartes(out jeuCartes);
        FonctionProgram.MelangerCartes(jeuCartes);
        FonctionProgram.DistributionCartes(jeuCartes, out mainJoueur, out mainOrdinateur, out carteTable, out indexPaquet);
        FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur);
        
        do
        {
            FonctionProgram.ChoixCarteJoueur(ref mainJoueur, jeuCartes, ref indexPaquet, ref carteTable);
            FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur);
            Console.WriteLine("Voulez-vous recommencer ? (tapez ' ' pour recommencer)");
            recommencer = Console.ReadLine();
        } while (recommencer == " ");

    }
}