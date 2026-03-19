namespace _5TTI_DayaniPoty_Mael_UNO_UAA9;

public class FonctionProgram
{
    public static void AffichageAccueil(out string touche)
    {
        Console.WriteLine("Bienvenue dans le jeu UNO !");
        Console.WriteLine("But du jeu : se débarrasser de toutes ses cartes.");
        Console.WriteLine("Règles : vous devez poser une carte de même couleur, numéro ou symbole.");
        Console.WriteLine("Si vous ne pouvez pas jouer, vous devez piocher.");
        Console.WriteLine("Appuyez sur une touche pour commencer...");

        touche = Console.ReadLine() ?? string.Empty;
    }

    public static void InitialiserCartes(out string[] jeuCartes)
    {
        jeuCartes = new string[50];
        int indexCarte = 0; //indice du tableau des cartes
        string[] couleurs = { "Rouge", "Bleu", "Vert", "Jaune" }; //tableau contenant les divers couleurs

        foreach (string couleur in couleurs)
        {
            for (int numeroCarte = 0; numeroCarte <= 9; numeroCarte++)
            {
                jeuCartes[indexCarte] = couleur + " " + numeroCarte; //numéro de la carte en cours
                indexCarte++;
            }

            jeuCartes[indexCarte] = "+2 " + couleur; //carte spéciale +2
            indexCarte++;

            jeuCartes[indexCarte] = "Passe ton tour"; //carte spéciale Passe ton tour
            indexCarte++;
        }

        jeuCartes[indexCarte] = "+4"; //carte spéciale +4
        indexCarte++;

        jeuCartes[indexCarte] = "Changement de couleur"; //carte spéciale Changement de couleur
    }

    public static void MelangerCartes(string[] jeuCartes)
    {
        string carteTemp; //carte temporaire utilisée pour l'échange
        int iAleatoire; //index aléatoire utilisé pour l'échange
        int nbrCarte; //nombre total de cartes dans le paquet
        
        Random alea = new Random();
        nbrCarte = jeuCartes.Length; 

        for (int iCarte = 0; iCarte < nbrCarte; iCarte++) //index courant des cartes dans le paquet
        {
            iAleatoire = alea.Next(0, nbrCarte);
            carteTemp = jeuCartes[iCarte];
            jeuCartes[iCarte] = jeuCartes[iAleatoire];
            jeuCartes[iAleatoire] = carteTemp;
        }
    }

    public static void AfficherPremieresCartes(string[] jeuCartes, int nombre, string titre) //sert a tester les carte du paquet avant et après mélange
    {
        Console.WriteLine();
        Console.WriteLine(titre);

        int limite = Math.Min(nombre, jeuCartes.Length);
        for (int i = 0; i < limite; i++)
        {
            Console.WriteLine($"{i + 1}. {jeuCartes[i]}");
        }
    }

    public static void DistributionCartes(string[] jeuCartes, out string[] mainJoueur, out string[] mainOrdinateur, out string carteTable)
    {
        int indexPaquet;
        
        if (jeuCartes.Length < 15)
        {
            throw new ArgumentException("Le paquet doit contenir au moins 15 cartes.", nameof(jeuCartes));
        }

        mainJoueur = new string[7];
        mainOrdinateur = new string[7];
        indexPaquet = 0; //l’index des cartes dans le paquet global

        for (int iCarte = 0; iCarte <= 6; iCarte++)
        {
            mainJoueur[iCarte] = jeuCartes[indexPaquet];
            indexPaquet++;

            mainOrdinateur[iCarte] = jeuCartes[indexPaquet];
            indexPaquet++;
        }

        carteTable = jeuCartes[indexPaquet];
    }

    public static void AfficherEtatJeu(string carteTable, string[] mainJoueur, string[] mainOrdinateur)
    {
        Console.WriteLine();
        Console.WriteLine("Carte sur la table : " + carteTable);
        Console.WriteLine("Cartes du joueur :");

        for (int iCarte = 0; iCarte < mainJoueur.Length; iCarte++)
        {
            Console.WriteLine(iCarte + " : " + mainJoueur[iCarte]);
        }

        Console.WriteLine("Nombre de cartes de l'ordinateur : " + mainOrdinateur.Length);
        Console.WriteLine("Tour du joueur actuel");
    }
}