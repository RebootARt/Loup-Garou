using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Jeu
    {
        private List<Villageois> listeVillageois = new List<Villageois>();
        private List<Cupidon> listCupidon = new List<Cupidon>();
        private List<LoupGarou> listLoupGarou = new List<LoupGarou>();
        public void debutDuGame()
        {
            int numCarte = 1;
            Console.WriteLine("Combien de joueurs êtes-vous? (Vous devez être entre 8 et 12 joueurs) : ");
            int nbJoueur = int.Parse(Console.ReadLine());
            while (nbJoueur < 8 || nbJoueur > 12)
            {
                Console.WriteLine("ERREUR : Le nombre de joueurs ne convient pas, recommencez : ");
                nbJoueur = int.Parse(Console.ReadLine());
            }


            for (int i = 0; i < nbJoueur; i++)
            {
                Console.WriteLine("Nom du joueur : ");
                string nomJoueur = Console.In.ReadLine();
                Villageois v = new Villageois(nomJoueur, numCarte);



                numCarte = v.PlayerOrdre + 1;
                listeVillageois.Add(v);

            }

            afficherVillageois(); // mettre cette méthode dans hors de la boucle "for"
            DefinirCartes(nbJoueur);
            debutTour();
        }
        
        public void DefinirCartes(int nbJoueur)
        {
            int nbLoup, nbCupidon, nbVoleur;               //Variable pour donner le nombre de loups, cupidon et voleur

            //Définition des roles avec le tirage au sort
            Random aleatoire = new Random();
            int numCupidon = aleatoire.Next(nbJoueur); //Créer un lancer de dé à "nbJoueur" faces pour définir le numéro de Cupidon
            int numVoleur = aleatoire.Next(nbJoueur);
            int numLoup1 = aleatoire.Next(nbJoueur);
            int numLoup2 = aleatoire.Next(nbJoueur);
            foreach (var v in listeVillageois)
                {
                Console.WriteLine("numCupidon " + numCupidon+" numVoleur "+numVoleur+" "); // Ligne de debogage pour verifier les nombre aleatoire
                Console.WriteLine("numLoup1 int "+numLoup1);
                Console.WriteLine("numLoup2 int " + numLoup2);
                if(numVoleur == numCupidon)
                {
                    numVoleur = aleatoire.Next(nbJoueur);
                }

                if (numLoup1 == numCupidon || numLoup1 == numVoleur)
                {
                    numLoup1 = aleatoire.Next(nbJoueur);         
                }

                if (numLoup2 == numCupidon || numLoup2 == numVoleur || numLoup2 == numLoup1)
                {
                    numLoup2 = aleatoire.Next(nbJoueur);
                }

                // on ajoute les objets aux listes 

                if (v.PlayerOrdre == numCupidon)
                {
                    Cupidon Culbidon = new Cupidon(v.Nom);
                    //Culbidon.ajouterCupidon(v);
                    //Culbidon.NbCupidon();
                    listCupidon.Add(Culbidon);
                }
                else if (v.PlayerOrdre == numVoleur)
                {
                    Voleur BouncieBarro = new Voleur(v.Nom);
                    BouncieBarro.ajouterVoleur(v);
                    BouncieBarro.NbVoleur();

                }
                else if (v.PlayerOrdre == numLoup1) {
                    
                    LoupGarou lp1 = new LoupGarou(v.Nom);
                    /*
                    lp1.ajouterLoup(v);
                    lp1.NbLoup();
                    */
                    listLoupGarou.Add(lp1);
                }
                else if (v.PlayerOrdre == numLoup2)
                {
                    LoupGarou lp2 = new LoupGarou(v.Nom);
                    /*
                    lp2.ajouterLoup(v);
                    lp2.NbLoup();
                    */
                    listLoupGarou.Add(lp2);
                }
                /*
                    else if (v.PlayerOrdre == numSorciere)
                    {
                        Mireille.ajouterSorciere(v);
                    }
                    else if (v.PlayerOrdre == numLoup1)
                    {
                        Lupin.ajouterLoup(v);
                    }
                    else if (v.PlayerOrdre == numLoup2)
                    {
                        Lupin.ajouterLoup(v);
                    }
                    */
            }
         }

        public void afficherVillageois() {
            foreach (var v in listeVillageois) {
                Console.WriteLine("Joueur "+v.PlayerOrdre+ " : Bienvenue " + v.Nom+" num joueur "+v.PlayerOrdre);
            }
        }

        public void debutTour()
        {
            Console.WriteLine("La nuit est là... ");
            foreach (var c in listCupidon) {
                Console.WriteLine("Cupidon veux tu de ton pouvoir ? O/N");
                string choixPouvoir = Console.In.ReadLine();
                if (choixPouvoir == "O")
                {
                    Console.WriteLine(" Cupidon fait ton choix pour les amoureux ");
                    string choixAmoureux = Console.In.ReadLine();
                    for (int i = 0; i < listeVillageois.Count; i++)
                    {
                        if (choixAmoureux == listeVillageois.ElementAt(i).Nom)
                        {
                            c.ajouterAmoureux(listeVillageois.ElementAt(i));
                        }

                    }
                    c.listeAmoureux();
                    if (c.ListDesAmoureux.Count < 2) {
                        Console.WriteLine(" Encore un gros fragile ");
                        string choixAmoureux2 = Console.In.ReadLine();
                        for (int i = 0; i < listeVillageois.Count; i++)
                        {
                            if (choixAmoureux2 == listeVillageois.ElementAt(i).Nom)
                            {
                                c.ajouterAmoureux(listeVillageois.ElementAt(i));
                            }

                        }
                    }
                    c.listeAmoureux();
                }
                else {
                    Console.WriteLine(" Cupidon tu es une grosse merde ");
                }
            }
            Console.WriteLine(" Mtn les loups garous vont jouer ");
            foreach (var loup in listLoupGarou) {
                Console.WriteLine(" Choix de la Misquine ");
                string choixMisquine = Console.In.ReadLine();
                for (int i = 0; i < listeVillageois.Count; i++) {
                    if (choixMisquine == listeVillageois.ElementAt(i).Nom) {
                        loup.ajouterVictime(listeVillageois.ElementAt(i));
                    }
                }
                Console.WriteLine(" list misquine "+ loup.ListVictime.Count);
            }
        }

    }
}
