﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Jeu
    {

        public void debutDuGame()
        {
            int numCarte = 1;
            Console.WriteLine("Combien de joueurs ? : ");
            int nbJoueur = int.Parse(Console.ReadLine());

            for (int i = 1; i < nbJoueur; i++)
            {
                Console.WriteLine("Nom du joueur : ");
                string nomJoueur = Console.In.ReadLine();
                Villagois villagois = new Villagois(nomJoueur, numCarte);


            }


            foreach (var v in Villagois.listeVillagois)
            {
                Console.WriteLine("nb villageois" + v);
            }
            ajouterVillageois(villagois);
        }
        public void ajouterVillageois(Villagois villagois)
        {
            listeVillagois.Add(villagois);
        }
    }
}
