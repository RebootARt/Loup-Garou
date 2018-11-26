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
        List<Villageois> listCupidon = new List<Villageois>();
        List<Villageois> listDesAmoureux = new List<Villageois>();

        public Cupidon(string nom)
        {
            this.Nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }
        internal List<Villageois> ListDesAmoureux { get => listDesAmoureux; set => listDesAmoureux = value; }
        internal List<Villageois> ListCupidon { get => listCupidon; set => listCupidon = value; }

        public void ajouterCupidon(Villageois X) // méthode pour stocker le cupidon
        {
            ListCupidon.Add(X);
        }

        public void NbCupidon()
        {
            Console.WriteLine("nb cupidon" + ListCupidon.Count);
            foreach (var c in ListCupidon)
            {
                Console.WriteLine(" il y a le joueur " + c.Nom + " chez les Gays");
            }
        }

        public void ajouterAmoureux(Villageois X)  // méthode pour stocker les amoureux 
        {
            ListDesAmoureux.Add(X);
        }

        public void listeAmoureux()  // méthode pour stocker les amoureux 
        {
            Console.WriteLine("il y a " + listDesAmoureux.Count + " amoureux");
        }

    }
}
