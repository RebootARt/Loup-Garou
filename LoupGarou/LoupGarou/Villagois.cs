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

        private List<Villageois> listeVillageois = new List<Villageois>();

        public Villageois(string nom, int playerOrdre)
        {
            this.Nom = nom;
            this.PlayerOrdre = playerOrdre;
        }

        public string Nom { get => nom; set => nom = value; }
        public int PlayerOrdre { get => playerOrdre; set => playerOrdre = value; }

    }
}
