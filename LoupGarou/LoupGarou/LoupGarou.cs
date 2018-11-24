using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class LoupGarou
    {
        private string nom;
        private List<Villageois> listLoupGarou = new List<Villageois>();

        public LoupGarou(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }

        public void ajouterLoup(Villageois X)
        {
            listLoupGarou.Add(X);
        }

        public void NbLoup()
        {
            Console.WriteLine("nb cupidon" + listLoupGarou.Count);
            foreach (var lp in listLoupGarou)
            {
                Console.WriteLine(" il y a le joueur " + lp.Nom + " chez les bats de loups");
            }
        }
    }
}
