﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Voleur
    {
        private string nom;
        List<Villageois> listVoleur = new List<Villageois>();

        public Voleur(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }
   
        public void ajouterVoleur(Villageois X)
        {
            listVoleur.Add(X);
        }

        public void NbVoleur() {
            Console.WriteLine("nb voleur" + listVoleur.Count);
            foreach (var v in listVoleur) {
                Console.WriteLine(" il y a le joueur "+v.Nom+" chez les arabes");
            }
        }
  
    }
}
