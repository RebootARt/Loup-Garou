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
        private List<Villagois> listSorciere = new List<Villagois>();

        public Sorciere(string nom)
        {
            this.nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }
    
    }
}
