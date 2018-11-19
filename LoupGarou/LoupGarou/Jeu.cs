using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Jeu
    {

        public void nbJoueurs()
        {
            Console.WriteLine("Combien de joueurs ? : ");
            int nbJoueur = int.Parse(Console.ReadLine());

            for (int i = 0; i < nbJoueur; i++){
                Console.WriteLine("Nom du joueur : ");

                
            }

            foreach (var v in listeVillagois)
            {
                Console.WriteLine(v);
            }
        }
        public void ajouterVillageois(Villagois X)
        {
            listeVillagois.Add(X);
        }
    }
}
