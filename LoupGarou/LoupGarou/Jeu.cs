﻿using System;
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
        private List<Voleur> listVoleur = new List<Voleur>();
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

        }
        
                public void DefinirCartes(int nbJoueur)
        {
                //AttentionLesYeux

            /*
                int numSorciere = aleatoire.Next(nbJoueur); //Créer un lancer de dé à "nbJoueur" faces pour définir le numéro de Sorcière
                while (numSorciere == numCupidon)
                {           //S'assurer que le num n'est pas pris et relancer le dé tant que num est pris
                    numSorciere = aleatoire.Next(nbJoueur);
                }
                Sorciere Mireille = new Sorciere();

                int numLoup1 = aleatoire.Next(nbJoueur);
                while (numLoup1 == numCupidon || numLoup1 == numSorciere)
                {
                    numLoup1 = aleatoire.Next(nbJoueur);
                }

                int numLoup2 = aleatoire.Next(nbJoueur);
                while (numLoup2 == numCupidon || numLoup2 == numSorciere || numLoup2 == numLoup1)
                {
                    numLoup2 = aleatoire.Next(nbJoueur);
                }
                LoupGarou Lupin = new LoupGarou();


                while (numVoleur == numCupidon || numVoleur == numSorciere || numVoleur == numLoup1 || numVoleur == numLoup2)
                {
                    numVoleur = aleatoire.Next(nbJoueur);
                }

            */
                //Définition des roles avec le tirage au sort

                foreach (var v in listeVillageois)
                {
                Random aleatoire = new Random();
                int numCupidon = aleatoire.Next(nbJoueur); //Créer un lancer de dé à "nbJoueur" faces pour définir le numéro de Cupidon
                int numVoleur = aleatoire.Next(nbJoueur);
                if (v.PlayerOrdre == numCupidon)
                    {
                    Cupidon Culbidon = new Cupidon(v.Nom);
                    Culbidon.ajouterCupidon(v);
                    Culbidon.NbCupidon();
                }
                    else if (v.PlayerOrdre == numVoleur)
                    {
                    Voleur BouncieBarro = new Voleur(v.Nom);
                    BouncieBarro.ajouterVoleur(v);
                    BouncieBarro.NbVoleur();
                    
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


    }
}
