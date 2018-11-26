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

        internal List<Villageois> GetListLoupGarou()
        {
            return listLoupGarou;
        }

        internal void SetListLoupGarou(List<Villageois> value)
        {
            listLoupGarou = value;
        }

        internal List<Villageois> GetListVictime()
        {
            return listVictime;
        }

        internal void SetListVictime(List<Villageois> value)
        {
            listVictime = value;
        }

        public void ajouterLoup(Villageois X)
        {
            GetListLoupGarou().Add(X);
        }

        public void ajouterVictime(Villageois X)
        {
            listVictime.Add(X);
        }

        public void NbLoup()
        {
            Console.WriteLine("nb cupidon" + GetListLoupGarou().Count);
            foreach (var lp in GetListLoupGarou())
            {
                Console.WriteLine(" il y a le joueur " + lp.Nom + " chez les bats de loups");
            }
        }
    }
}
