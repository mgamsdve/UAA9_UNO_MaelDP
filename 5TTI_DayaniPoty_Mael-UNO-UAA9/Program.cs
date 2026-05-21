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
        bool sauterTourJoueur = false;
        bool sauterTourOrdi = false;
        string carteJoueeJoueur;
        string carteJoueeOrdi;
        string gagnant;

        FonctionProgram.AffichageAccueil(out touche);

        do
        {
            FonctionProgram.InitialiserCartes(out jeuCartes);
            FonctionProgram.MelangerCartes(jeuCartes);
            FonctionProgram.DistributionCartes(jeuCartes, out mainJoueur, out mainOrdinateur, out carteTable, out indexPaquet);

            sauterTourJoueur = false;
            sauterTourOrdi = false;

            while (true)
            {
                if (sauterTourJoueur)
                {
                    Console.WriteLine("Votre tour est sauté !");
                    sauterTourJoueur = false;
                }
                else
                {
                    FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur, true);
                    FonctionProgram.ChoixCarteJoueur(ref mainJoueur, jeuCartes, ref indexPaquet, ref carteTable, out carteJoueeJoueur);
                    FonctionProgram.AppliquerEffetCarte(carteJoueeJoueur, ref mainJoueur, ref mainOrdinateur, jeuCartes, ref indexPaquet, ref carteTable, true, out tourSaute);
                    FonctionProgram.DetectionUno(mainJoueur, true);

                    if (FonctionProgram.VerifierFinPartie(mainJoueur, mainOrdinateur, out gagnant))
                    {
                        Console.WriteLine("Fin de partie ! Le gagnant est : " + gagnant);
                        break;
                    }

                    if (tourSaute)
                    {
                        sauterTourOrdi = true;
                    }
                }

                if (sauterTourOrdi)
                {
                    Console.WriteLine("Le tour de l'ordinateur est sauté !");
                    sauterTourOrdi = false;
                }
                else
                {
                    FonctionProgram.AfficherEtatJeu(carteTable, mainJoueur, mainOrdinateur, false);
                    FonctionProgram.TourOrdinateur(ref mainOrdinateur, jeuCartes, ref indexPaquet, ref carteTable, out carteJoueeOrdi);
                    FonctionProgram.AppliquerEffetCarte(carteJoueeOrdi, ref mainJoueur, ref mainOrdinateur, jeuCartes, ref indexPaquet, ref carteTable, false, out tourSaute);
                    FonctionProgram.DetectionUno(mainOrdinateur, false);

                    if (FonctionProgram.VerifierFinPartie(mainJoueur, mainOrdinateur, out gagnant))
                    {
                        Console.WriteLine("Fin de partie ! Le gagnant est : " + gagnant);
                        break;
                    }

                    if (tourSaute)
                    {
                        sauterTourJoueur = true;
                    }
                }
            }

            Console.WriteLine("Voulez-vous recommencer une nouvelle partie ? (Entrez un espace pour recommencer, ou n'importe quelle autre touche pour quitter)");
            recommencer = Console.ReadLine();
        } while (recommencer == " ");
    }
}
