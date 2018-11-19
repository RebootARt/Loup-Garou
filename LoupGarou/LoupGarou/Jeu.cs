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

            for (int i = 0; i < nbJoueur; i++)
            {
                Console.WriteLine("Nom du joueur : ");
                string nomJoueur = Console.In.ReadLine();
                Villageois v = new Villageois(nomJoueur, numCarte);



                numCarte = v.PlayerOrdre+1;
                ajouterVillageois(villageois);

            }
            
            
        }

    }
}
