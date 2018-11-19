using System;
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
                Villageois Villageois = new Villageois(nomJoueur, numCarte);


            }


            foreach (var v in Villageois.listeVillageois)
            {
                Console.WriteLine("nb villageois" + v);
            }
            ajouterVillageois(Villageois);
        }
        public void ajouterVillageois(Villageois Villageois)
        {
            listeVillageois.Add(Villageois);
        }
    }
}
