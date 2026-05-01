========================================
Issue #18
Titre: Detection du UNO
État GitHub: OPEN
Labels: Analyse, codage
Status Project: Ready

Description:
Objectif : Gérer l’annonce du UNO.

Le programme doit :

- Détecter lorsqu’un joueur n’a plus qu’une carte
- Afficher un message indiquant "UNO"

Résultat attendu :
Un message UNO est affiché au bon moment.

========================================
Issue #17
Titre: Supprimer une carte du paquet
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Retirer une carte de la main d'un joueur après qu'elle a été jouée.

Le programme doit 

- Créer un nouveau tableau d'une taille inférieure de 1
- Copier toutes les cartes sauf celle à l'index indiqué
- Retourner le nouveau tableau

Résultat attendu :
La carte jouée est correctement retirée de la main du joueur et le tableau est mis à jour.

========================================
Issue #16
Titre: Vérifier fin de partie
État GitHub: OPEN
Labels: 
Status Project: In progress

Description:
Objectif : Détecter la fin du jeu.

Le programme doit :

- Vérifier si un joueur n’a plus de cartes
- Afficher le gagnant

Résultat attendu :
Le jeu s’arrête et le gagnant est annoncé correctement.

========================================
Issue #15
Titre: Affichage des premières cartes du paquet
État GitHub: OPEN
Labels: Analyse, codage
Status Project: Aucun status project trouvé

Description:
Objectif : Permettre d’afficher une partie du paquet de cartes pour vérifier son contenu.

Le programme doit :

- Afficher un titre
- Afficher les premières cartes du tableau jeuCartes
- Limiter l’affichage au nombre demandé
- Ne pas dépasser la taille du tableau

Résultat attendu :
Les premières cartes du paquet sont affichées correctement avec un titre, ce qui permet de vérifier le contenu du jeu avant et après mélange.

========================================
Issue #14
Titre: Implémentation des analyses en C#
État GitHub: CLOSED
Labels: codage
Status Project: Done

Description:
Objectif : Traduire les analyses réalisées en code C# fonctionnel.

Le programme devra :

- Implémenter le démarrage du jeu (affichage + attente utilisateur)
- Implémenter l’initialisation des cartes
- Implémenter le mélange des cartes
- Implémenter la distribution des cartes
- Implémenter l’affichage de l’état du jeu
- Implémenter le choix d’une carte par le joueur

Chaque fonctionnalité devra respecter les analyses réalisées (GNS).

Résultat attendu :
Les différentes parties du jeu fonctionnent en C# et correspondent aux analyses réalisées précédemment.

========================================
Issue #13
Titre: Gestion des cartes spéciales
État GitHub: CLOSED
Labels: 
Status Project: Done

Description:
Objectif : Appliquer les effets des cartes spéciales.

Le programme doit gérer :

- +2 → le joueur suivant pioche 2 cartes et passe son tour
- +4 → le joueur suivant pioche 4 cartes et passe son tour
- Passe ton tour → le joueur suivant ne joue pas
- Changement de couleur → nouvelle couleur choisie

Résultat attendu :
Les effets des cartes spéciales sont correctement appliqués.

========================================
Issue #12
Titre: Piocher une carte
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Permettre au joueur ou à l’ordinateur de piocher une carte.

Le programme doit :

- Prendre la prochaine carte du paquet
- L’ajouter à la main du joueur ou de l’ordinateur

Résultat attendu :
Une carte est ajoutée correctement à la main du joueur concerné.

========================================
Issue #11
Titre: Vérification d’une carte jouable
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Vérifier si une carte peut être jouée selon les règles du UNO.

Le programme doit vérifier :

- Si la couleur de la carte correspond à celle sur la table
- OU si le numéro correspond
- OU si c’est une carte spéciale

Résultat attendu :
Le programme indique si la carte est valide ou non avant de la jouer.

========================================
Issue #10
Titre: Mélanger les cartes
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Mélanger aléatoirement le paquet de cartes avant la distribution.

Avant le début d'une partie :

• Le paquet de cartes doit être mélangé.
• Les cartes doivent être placées dans un ordre aléatoire.
• Chaque partie doit donc avoir une distribution différente.

Résultat attendu :
Les cartes sont dans un ordre aléatoire avant la distribution.

========================================
Issue #9
Titre: Système des tours
État GitHub: OPEN
Labels: documentation
Status Project: Backlog

Description:
Objectif : Organiser le déroulement des tours de jeu.

Le système devra :
- Indiquer clairement à qui c’est le tour.
- Alterner entre le joueur et l’ordinateur.
- Prendre en compte les effets des cartes spéciales (passe ton tour, +2, +4).
- Assurer la continuité correcte de la partie jusqu’à la fin.

Résultat attendu :
Le déroulement du jeu est fluide et respecte les règles du UNO.

========================================
Issue #8
Titre: Tour de l'ordinateur
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Permettre à l’ordinateur de jouer automatiquement.

Le système devra :
- Vérifier quelles cartes de l’ordinateur sont valides.
- En choisir une automatiquement.
- La poser sur la table.
- Piocher une carte si aucune carte ne peut être jouée.

Résultat attendu :
L’ordinateur joue de manière automatique et respecte les règles du jeu.

========================================
Issue #7
Titre: Choix d'une carte pour le joueur
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Permettre au joueur de sélectionner une carte parmi celles qu’il possède.

Le système devra :
- Permettre au joueur d’indiquer la carte qu’il souhaite jouer.
- Vérifier que la carte appartient bien à sa main.
- Vérifier que la carte respecte les règles du jeu.
- Informer le joueur si son choix est invalide.
- Permettre au joueur de piocher si aucune carte ne peut être jouée.

Résultat attendu :
Le joueur peut jouer son tour correctement sans possibilité de tricher ou d’entrer une valeur incorrecte.

========================================
Issue #6
Titre: Affichage de l’état du jeu à chaque tour
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Permettre au joueur de comprendre la situation du jeu à tout moment.

À chaque tour, le programme doit afficher :
- La carte actuellement posée sur la table.
- Les cartes du joueur de manière claire et numérotée.
- Le nombre de cartes restantes de l'ordinateur.
- Un message indiquant à qui c’est le tour.

Résultat attendu :
Le joueur dispose de toutes les informations nécessaires pour prendre une décision.

========================================
Issue #5
Titre: Distribution des cartes
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Mettre en place la distribution initiale.

Au démarrage d’une partie :
- Le joueur reçoit 7 cartes.
- L’ordinateur reçoit 7 cartes.
- Une carte est placée au centre pour démarrer la partie.
- Un message indique que la partie commence.

Résultat attendu :
La partie démarre avec une distribution des cartes correcte.

========================================
Issue #4
Titre: Initialisation des cartes
État GitHub: CLOSED
Labels: Analyse
Status Project: Done

Description:
Objectif : Préparer toutes les cartes nécessaires au déroulement d’une partie.

Le jeu doit contenir :
- Les cartes numérotées de chaque couleur.
- Les cartes spéciales : +2, +4, changement de couleur et passe ton tour.

Résultat attendu :
Toutes les cartes nécessaires sont prêtes à être utilisées lors de la distribution.

========================================
Issue #3
Titre: Démarrage du jeu - écran d'accueil
État GitHub: CLOSED
Labels: documentation, Analyse
Status Project: Done

Description:
Objectif : Mettre en place le lancement du jeu.

Le programme devra :
- Afficher un message de bienvenue clair.
- Présenter brièvement le but du jeu.
- Expliquer les règles principales.
- Attendre que le joueur commence la partie.

Résultat attendu :
Au lancement, le joueur comprend immédiatement le fonctionnement du jeu avant le début de la partie.

========================================
Issue #2
Titre: Dossier partagé
État GitHub: CLOSED
Labels: documentation
Status Project: Done

Description:
Créer un dossier partagé sur le drive nommé proprement, comprenant : 

- 1 google Doc Bibliographie détaillé
- 1 google doc avec analyse, spécifications et gns des divers morceaux de programme réalisés
- 1 google doc avec le lien vers le repository github et vers la ligne du temps

========================================
Issue #1
Titre: Cahier de charge
État GitHub: CLOSED
Labels: documentation
Status Project: Done

Description:
Créer le cahier de charge pour le projet Uno

