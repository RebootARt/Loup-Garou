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

        public Cupidon(string nom)
        {
            this.Nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }

    }
}
