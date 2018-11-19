using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Voleur
    {
        private string nom;
        private List<Villagois> listVoleur = new List<Villagois>();

        public Voleur(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }
    }
}
