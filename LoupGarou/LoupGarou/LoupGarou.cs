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
        private List<Villagois> listLoupGarou = new List<Villagois>();

        public LoupGarou(string nom) {
            this.nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }
    }
}
