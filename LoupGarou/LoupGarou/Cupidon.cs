using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Cupidon
    {
        private string nom;
        private List<Villageois> listCupidon = new List<Villageois>();

        public Cupidon(string nom)
        {
            this.Nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }

        public void ajouterCupidon(Villageois X)
        {
            listCupidon.Add(X);
        }
    }
}
