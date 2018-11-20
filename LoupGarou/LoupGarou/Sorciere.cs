using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Sorciere
    {
        private string nom;
        private List<Villageois> listSorciere = new List<Villageois>();

        public Sorciere(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }

        public void ajouterSorciere(Villageois X)
        {
            listSorciere.Add(X);
        }
    }
}
