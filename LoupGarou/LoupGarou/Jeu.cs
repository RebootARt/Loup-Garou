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
            foreach (var v in listeVillagois)
            {
                Console.WriteLine(v);
            }
        }

    }
}
