using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Villageois
    {
        private string nom;
        private int playerOrdre;
        private int voteContre;

        private List<Villageois> listeVillageois = new List<Villageois>();



        public Villageois(string nom, int playerOrdre, int voteContre)
        {
            this.Nom = nom;
            this.PlayerOrdre = playerOrdre;
            this.VoteContre = voteContre;
        }

        public string Nom { get => nom; set => nom = value; }
        public int PlayerOrdre { get => playerOrdre; set => playerOrdre = value; }
        internal List<Villageois> ListeVillageois { get => listeVillageois; set => listeVillageois = value; }
        public int VoteContre { get => voteContre; set => voteContre = value; }

        public void NbVillageois() {
                Console.WriteLine(ListeVillageois.Count);
        }

        public void ajouterVillageois(Villageois v) {
            listeVillageois.Add(v);
        }
    }
}
