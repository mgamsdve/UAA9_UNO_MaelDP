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

            jeuCartes[indexCarte] = couleur + " +2"; //carte spéciale +2
            indexCarte++;

            jeuCartes[indexCarte] = couleur + " Passe ton tour"; //carte spéciale Passe ton tour
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
    
    public static void LireEntier(string question, out int resultat)
    {
        do
        {
            Console.WriteLine(question);
        }
        while (!int.TryParse(Console.ReadLine(), out resultat));
    }

    public static void DistributionCartes(string[] jeuCartes, out string[] mainJoueur, out string[] mainOrdinateur, out string carteTable, out int indexPaquet)
    {
        indexPaquet = 0;
        
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

    // public static void AfficherEtatJeu(string carteTable, string[] mainJoueur, string[] mainOrdinateur)
    // {
    //     Console.WriteLine();
    //     Console.WriteLine("Carte sur la table : " + carteTable);
    //     Console.WriteLine("Cartes du joueur :");
    //
    //     for (int iCarte = 0; iCarte < mainJoueur.Length; iCarte++)
    //     {
    //         Console.WriteLine(iCarte + " : " + mainJoueur[iCarte]);
    //     }
    //
    //     Console.WriteLine("Nombre de cartes de l'ordinateur : " + mainOrdinateur.Length);
    //     Console.WriteLine("Tour du joueur actuel");
    // }
    public static void AfficherEtatJeu(string carteTable, string[] mainJoueur, string[] mainOrdinateur, bool tourJoueur)
    {
        Console.WriteLine();

        // ── Carte sur la table ──
        Console.Write("┌─────────────────────────┐\n│   ");
        Console.Write("🃏 Carte sur la table : ");
        AfficherCarte(carteTable);
        Console.WriteLine("\n└─────────────────────────┘");

        // ── Main de l'ordinateur ──
        Console.Write("🤖 Ordinateur : ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        for (int i = 0; i < mainOrdinateur.Length; i++)
            Console.Write("[?] ");
        Console.ResetColor();
        Console.WriteLine($" ({mainOrdinateur.Length} cartes)");

        Console.WriteLine(new string('─', 40));

        // ── Main du joueur ──
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🧑 Vos cartes :");
        Console.ResetColor();

        for (int i = 0; i < mainJoueur.Length; i++)
        {
            Console.Write($"  [{i}] ");
            AfficherCarte(mainJoueur[i]);
            Console.WriteLine();
        }

        Console.WriteLine(new string('─', 40));
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (tourJoueur)
        {
            Console.WriteLine("👉 C'est votre tour ! Choisissez une carte :");

        }
        else
        {
            Console.WriteLine("👉 C'est le tour de l'ordinateur !");

        }
        Console.ResetColor();
    }

    private static void AfficherCarte(string carte)
    {
        // Format attendu : "Rouge 5", "Bleu +2", "Jaune Inversion", etc.
        string[] parts = carte.Split(' ');
        string couleur = parts[0];

        Console.ForegroundColor = couleur switch
        {
            "Rouge"  => ConsoleColor.Red,
            "Bleu"   => ConsoleColor.Blue,
            "Vert"   => ConsoleColor.Green,
            "Jaune"  => ConsoleColor.Yellow,
            _        => ConsoleColor.White
        };

        Console.Write(carte);
        Console.ResetColor();
    }
    public static string[] PiocherCarte(ref int indexPaquet, string[] mainJoueur, string[] jeuCartes)
    {
        if (indexPaquet >= jeuCartes.Length) // paquet épuisé
        {
            Console.WriteLine("Le paquet est épuisé !");
            return mainJoueur; // on retourne la main sans modification
        }
    
        string[] nouvellMain = new string[mainJoueur.Length + 1];
        for (int iCarte = 0; iCarte < mainJoueur.Length; iCarte++)
            nouvellMain[iCarte] = mainJoueur[iCarte];
    
        nouvellMain[mainJoueur.Length] = jeuCartes[indexPaquet];
        indexPaquet++;
    
        return nouvellMain;
    }

    public static string[] SupprimerCarte(int indexChoix, string[] mainJoueur)
    {
        string[] nouvellMain = new string[mainJoueur.Length - 1]; // nouveau tableau - 1
        int iNouveau = 0;
        
        for (int iCarte = 0; iCarte < mainJoueur.Length; iCarte++) // copie sans la carte à supprimer
        {
            if (iCarte != indexChoix)
            {
                nouvellMain[iNouveau] = mainJoueur[iCarte];
                iNouveau++;
            }
        }
        
        return nouvellMain;
    }

    public static bool EstCarteJouable(string carteCourante, string carteTable)
    {
        string couleurCourante;
        string valeurCourante;
        string couleurTable;
        string valeurTable;
        bool estJouable = false;
    
        if (carteCourante == "+4" || carteCourante == "Changement de couleur") // cartes spéciales toujours jouables
        {
            estJouable = true;
        }
        else if (carteTable.Split(' ').Length < 2) // protection si carteTable n'a pas de couleur (+4 sur table)
        {
            estJouable = false;
        }
        else
        {
            couleurCourante = carteCourante.Split(' ')[0];
            valeurCourante = carteCourante.Split(' ')[1];
            couleurTable = carteTable.Split(' ')[0];
            valeurTable = carteTable.Split(' ')[1];
        
            if (couleurCourante == couleurTable || valeurCourante == valeurTable) // même couleur ou même valeur
            {
                estJouable = true;
            }
        }
    
        return estJouable;
    }

    public static void ChoixCarteJoueur(ref string[] mainJoueur, string[] jeuCartes, ref int indexPaquet, ref string carteTable)
    {
        bool carteValide = false;
        bool peutJouer = false;
        int choix;
        string carteChoisie;
        
        for (int iCarte = 0; iCarte < mainJoueur.Length; iCarte++) // vérifie si au moins une carte jouable
        {
            if (EstCarteJouable(mainJoueur[iCarte], carteTable))
            {
                peutJouer = true;
            }
        }
        
        if (!peutJouer) // aucune carte jouable -> pioche
        {
            Console.WriteLine("Aucune carte jouable. Vous piochez une carte.");
            mainJoueur = PiocherCarte(ref indexPaquet, mainJoueur, jeuCartes);
        }
        else
        {
            while (!carteValide) // boucle jusqu'à un choix valide
            {
                LireEntier("Entrez le numéro de la carte : ", out choix);
                
                if (choix < 0 || choix >= mainJoueur.Length) // numéro hors plage
                {
                    Console.WriteLine("Numéro invalide. Réessayez.");
                }
                else
                {
                    carteChoisie = mainJoueur[choix];
                    
                    if (EstCarteJouable(carteChoisie, carteTable)) // carte valide selon les règles
                    {
                        carteTable = carteChoisie;
                        mainJoueur = SupprimerCarte(choix, mainJoueur);
                        carteValide = true;
                    }
                    else
                    {
                        Console.WriteLine("Carte non valide selon les règles. Réessayez.");
                    }
                }
            }
        }
    }
    
    public static void TourOrdinateur(ref string[] mainOrdinateur, string[] jeuCartes, ref int indexPaquet, ref string carteTable)
    {
        bool peutJouer = false;
        int indexJouable = -1;

        for (int iCarte = 0; iCarte < mainOrdinateur.Length; iCarte++) // cherche première carte jouable
        {
            if (EstCarteJouable(mainOrdinateur[iCarte], carteTable) && !peutJouer)
            {
                peutJouer = true;
                indexJouable = iCarte;
            }
        }

        if (!peutJouer) // aucune carte jouable → pioche
        {
            Console.WriteLine("L'ordinateur pioche une carte.");
            mainOrdinateur = PiocherCarte(ref indexPaquet, mainOrdinateur, jeuCartes);
        }
        else // pose la première carte jouable trouvée
        {
            Console.WriteLine("L'ordinateur joue : " + mainOrdinateur[indexJouable]);
            carteTable = mainOrdinateur[indexJouable];
            mainOrdinateur = SupprimerCarte(indexJouable, mainOrdinateur);

            // l'ordinateur choisit une couleur automatiquement après changement de couleur ou +4
            if (carteTable == "Changement de couleur" || carteTable == "+4")
            {
                string[] couleursValides = { "Rouge", "Bleu", "Vert", "Jaune" };
                string couleurChoisie = mainOrdinateur.Length > 0 ? mainOrdinateur[0].Split(' ')[0] : "Rouge";

                if (!couleursValides.Contains(couleurChoisie))
                    couleurChoisie = "Rouge";

                carteTable = couleurChoisie + " Changement de couleur";
                Console.WriteLine("L'ordinateur choisit la couleur : " + couleurChoisie);
            }
        }
    }
    public static void AppliquerEffetCarte(string carteJouee, ref string[] mainJoueur, ref string[] mainOrdinateur, string[] jeuCartes, ref int indexPaquet, ref string carteTable, bool tourJoueur, out bool tourSaute)
{
    tourSaute = false;

    if (carteJouee.Contains("Passe ton tour"))
    {
        tourSaute = true;
        Console.WriteLine("Le joueur suivant passe son tour !");
        // neutralise l'effet
        string couleur = carteJouee.Split(' ')[0];
        carteTable = couleur + " 0";
    }
    else if (carteJouee.Contains("+2")) // suivant pioche 2 et passe
    {
        tourSaute = true;
        if (tourJoueur) // joueur a joué → ordinateur pioche
        {
            for (int iCarte = 0; iCarte < 2; iCarte++)
                mainOrdinateur = PiocherCarte(ref indexPaquet, mainOrdinateur, jeuCartes);
            Console.WriteLine("L'ordinateur pioche 2 cartes et passe son tour !");
        }
        else // ordinateur a joué → joueur pioche
        {
            for (int iCarte = 0; iCarte < 2; iCarte++)
                mainJoueur = PiocherCarte(ref indexPaquet, mainJoueur, jeuCartes);
            Console.WriteLine("Vous piochez 2 cartes et passez votre tour !");
        }
    }
    else if (carteJouee.Contains("+2"))
    {
        tourSaute = true;
        if (tourJoueur)
        {
            for (int iCarte = 0; iCarte < 2; iCarte++)
                mainOrdinateur = PiocherCarte(ref indexPaquet, mainOrdinateur, jeuCartes);
            Console.WriteLine("L'ordinateur pioche 2 cartes et passe son tour !");
        }
        else
        {
            for (int iCarte = 0; iCarte < 2; iCarte++)
                mainJoueur = PiocherCarte(ref indexPaquet, mainJoueur, jeuCartes);
            Console.WriteLine("Vous piochez 2 cartes et passez votre tour !");
        }
        // neutralise l'effet pour le prochain tour
        string couleur = carteJouee.Split(' ')[0];
        carteTable = couleur + " 0"; // remplace par une carte neutre de même couleur
    }
    else if (carteJouee == "+4")
    {
        tourSaute = true;
        if (tourJoueur)
        {
            for (int iCarte = 0; iCarte < 4; iCarte++)
                mainOrdinateur = PiocherCarte(ref indexPaquet, mainOrdinateur, jeuCartes);
            Console.WriteLine("L'ordinateur pioche 4 cartes et passe son tour !");
        }
        else
        {
            for (int iCarte = 0; iCarte < 4; iCarte++)
                mainJoueur = PiocherCarte(ref indexPaquet, mainJoueur, jeuCartes);
            Console.WriteLine("Vous piochez 4 cartes et passez votre tour !");
        }
        // neutralise l'effet — pas de couleur sur +4 donc on met Rouge par défaut
        carteTable = "Rouge 0";
    }
}
    
    
}