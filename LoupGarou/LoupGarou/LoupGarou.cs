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
        private List<Villageois> listVictime = new List<Villageois>();

        public LoupGarou(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }
        internal List<Villageois> ListLoupGarou { get => listLoupGarou; set => listLoupGarou = value; }
        internal List<Villageois> ListVictime { get => listVictime; set => listVictime = value; }

        public void ajouterLoup(Villageois X)
        {
            ListLoupGarou.Add(X);
        }

        public void ajouterVictime(Villageois X)
        {
            listVictime.Add(X);
        }

        public void NbLoup()
        {
            Console.WriteLine("nb cupidon" + ListLoupGarou.Count);
            foreach (var lp in ListLoupGarou)
            {
                Console.WriteLine(" il y a le joueur " + lp.Nom + " chez les bats de loups");
            }
        }
    }
}
