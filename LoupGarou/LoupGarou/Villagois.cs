using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Villagois
    {
        private string nom;
        private int playerOrdre;

        private List<Villagois> listeVillagois = new List<Villagois>();

        public Villagois(string nom, int playerOrdre)
        {
            this.Nom = nom;
            this.PlayerOrdre = playerOrdre;
        }

        public string Nom { get => nom; set => nom = value; }
        public int PlayerOrdre { get => playerOrdre; set => playerOrdre = value; }
        internal List<Villagois> ListeVillagois { get => listeVillagois; set => listeVillagois = value; }
    }
}
