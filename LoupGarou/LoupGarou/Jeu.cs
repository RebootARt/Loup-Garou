using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoupGarou
{
    class Jeu
    {
        private List<Villageois> listeVillageois = new List<Villageois>();
        private List<Cupidon> listCupidon = new List<Cupidon>();
        private List<LoupGarou> listLoupGarou = new List<LoupGarou>();
        private List<Sorciere> listSorciere = new List<Sorciere>();

        int validerPotionS = 0;
        int validerPotionT = 0;

        public void debutDuGame()
        {
            int numCarte = 1;
            Console.WriteLine("Combien de joueurs êtes-vous? (Vous devez être entre 8 et 12 joueurs) : ");
            int nbJoueur = int.Parse(Console.ReadLine());
            while (nbJoueur < 8 || nbJoueur > 12)
            {
                Console.WriteLine("ERREUR : Le nombre de joueurs ne convient pas, recommencez : ");
                nbJoueur = int.Parse(Console.ReadLine());
            }


            for (int i = 0; i < nbJoueur; i++)
            {
                Console.WriteLine("Nom du joueur : ");
                string nomJoueur = Console.In.ReadLine();
                Villageois v = new Villageois(nomJoueur, numCarte,0);



                numCarte = v.PlayerOrdre + 1;
                listeVillageois.Add(v);

            }
            DefinirCartes(nbJoueur);
            debutTour();
            while ((listeVillageois.Count!=0)||(listLoupGarou.Count!=0))
            {
                afficherVillageois();
                nuit();
                tourDesVillageois();
            }

            Console.ReadLine();
        }
        
        public void DefinirCartes(int nbJoueur)
        {

            //Définition des roles avec le tirage au sort
            Random aleatoire = new Random();
            int numCupidon = aleatoire.Next(nbJoueur); //Créer un lancer de dé à "nbJoueur" faces pour définir le numéro de Cupidon
            int numVoleur = aleatoire.Next(nbJoueur);
            int numLoup1 = aleatoire.Next(nbJoueur);
            int numLoup2 = aleatoire.Next(nbJoueur);
            int numSorciere = aleatoire.Next(nbJoueur);
            foreach (var v in listeVillageois)
                {
                Console.WriteLine("numCupidon " + numCupidon+" numVoleur "+numVoleur+" numLoup1 "+numLoup1+" numLoup2 "+numLoup2); // Ligne de debogage pour verifier les nombre aleatoire
                while (numVoleur == numCupidon)
                {
                    numVoleur = aleatoire.Next(nbJoueur);
                }

                while (numLoup1 == numCupidon || numLoup1 == numVoleur)
                {
                    numLoup1 = aleatoire.Next(nbJoueur);         
                }

                while (numLoup2 == numCupidon || numLoup2 == numVoleur || numLoup2 == numLoup1)
                {
                    numLoup2 = aleatoire.Next(nbJoueur);
                }
                while (numSorciere == numCupidon || numSorciere == numVoleur || numSorciere == numLoup1 || numSorciere == numLoup2)
                {
                    numSorciere = aleatoire.Next(nbJoueur);
                }
                // on ajoute les objets aux listes 

                if (v.PlayerOrdre == numCupidon)
                {
                    Cupidon Culbidon = new Cupidon(v.Nom);
                    //Culbidon.ajouterCupidon(v);
                    //Culbidon.NbCupidon();
                    listCupidon.Add(Culbidon);
                }
                else if (v.PlayerOrdre == numVoleur)
                {
                    Voleur BouncieBarro = new Voleur(v.Nom);
                    BouncieBarro.ajouterVoleur(v);
                    BouncieBarro.NbVoleur();

                }
                else if (v.PlayerOrdre == numLoup1) {
                    
                    LoupGarou lp1 = new LoupGarou(v.Nom);
                    
                    //lp1.ajouterLoup(v);
                    lp1.NbLoup();
                    
                    listLoupGarou.Add(lp1);
                    
                }
                else if (v.PlayerOrdre == numLoup2)
                {
                    LoupGarou lp2 = new LoupGarou(v.Nom);
                    listLoupGarou.Add(lp2);
                   
                }
                else if (v.PlayerOrdre == numSorciere)
                {
                    Sorciere Mireille = new Sorciere(v.Nom);
                    listSorciere.Add(Mireille);
                }
            }
         }

        public void afficherVillageois() {
            foreach (var v in listeVillageois) {
                Console.WriteLine("Joueur "+v.PlayerOrdre+ " : Bienvenue " + v.Nom+" num joueur "+v.PlayerOrdre);
            }
        }

        public void debutTour()
        {
            Console.WriteLine("La nuit est là... ");
            foreach (var c in listCupidon) {
                Console.WriteLine("Cupidon veux tu de ton pouvoir ? O/N");
                string choixPouvoir = Console.In.ReadLine();
                if (choixPouvoir == "O" || choixPouvoir == "o")
                {     
                    string choixAmoureux = null;
                    while (c.ListDesAmoureux.Count ==0|| choixAmoureux == null)
                    {
                        Console.WriteLine(" Cupidon fait ton choix pour les amoureux ");
                        choixAmoureux = Console.In.ReadLine();
                        for (int i = 0; i < listeVillageois.Count; i++)
                        {
                            if (choixAmoureux == listeVillageois.ElementAt(i).Nom)
                            {
                                c.ajouterAmoureux(listeVillageois.ElementAt(i));
                            }
                        }
                    }
                    c.listeAmoureux();
                    
                   
                    while (c.ListDesAmoureux.Count < 2) {
                        Console.WriteLine(" Encore un gros fragile ");
                        string choixAmoureux2 = Console.In.ReadLine();
                        for (int i = 0; i < listeVillageois.Count; i++)
                        {
                            if (choixAmoureux2 == listeVillageois.ElementAt(i).Nom && choixAmoureux2 != choixAmoureux)
                            {
                                c.ajouterAmoureux(listeVillageois.ElementAt(i));
                            }

                        }
                    }
                    c.listeAmoureux();
                    c.prenomAmoureux();

                }
                else {
                    Console.WriteLine(" Cupidon tu es une grosse merde ");
                }
            } 
        }

        public void nuit() {
            List<Villageois> listVictime = new List<Villageois>();
            Console.WriteLine(" Mtn les loups garous vont jouer ");
            foreach (var loup in listLoupGarou)
            {  
                Console.WriteLine(" Choix de la Misquine ");
                string choixMisquine = Console.In.ReadLine();
                for (int i = 0; i < listeVillageois.Count; i++) //on ajoute les nominés dans la liste des victimes
                {
                    
                    if (choixMisquine == listeVillageois.ElementAt(i).Nom)
                    {
                        listVictime.Add(listeVillageois.ElementAt(i));
                        
                    }
                }
                Console.WriteLine(" list misquine " + listVictime.Count);
            }


            if (listVictime.Count > 1)
            {
                //Si meme nom
                if (listVictime.ElementAt(0).Nom == listVictime.ElementAt(1).Nom)
                {
                    listVictime.Remove(listVictime.ElementAt(1));
                    Console.WriteLine("Les loups garous ont voté a l'unanimité " + listVictime.ElementAt(0).Nom + " comme victime ce soir");
                }
                //Si pas meme nom
                else if(listVictime.ElementAt(0).Nom != listVictime.ElementAt(1).Nom)
                {
                    Console.WriteLine("Les loups ne se sont pas mis d'accord, par conséquent le hasard décidera entre les deux: ");
                    Random aleatoire = new Random();
                    int numPasVictime = aleatoire.Next(2);
                    Console.WriteLine("La victime " + numPasVictime + " sera épargnée ce soir");
                    listVictime.Remove(listVictime.ElementAt(numPasVictime));
                    Console.WriteLine("La victime des loups sera donc : " + listVictime.ElementAt(0).Nom); // l'element 0 de la liste sera toujours la victime des loups

                }
            }
            Console.WriteLine("Il y a " + listVictime.Count + " victimes en attente"); 

            //C'est au tour de la sorciere de jouer
            foreach (var s in listSorciere)
            {

                if (validerPotionS == 0 || validerPotionT == 0)
                {
                    Console.WriteLine("Sorciere bouge toi le cul! ");
                    Console.WriteLine("Veux tu de ton pouvoir?");
                    string sortirPotion = Console.In.ReadLine();
                    if (sortirPotion == "O" || sortirPotion == "o")
                    {
                        Console.WriteLine("Le pouvoir S : " + validerPotionS + " et le pouvoir T : " + validerPotionT);
                        Console.WriteLine("Quelle potion veux-tu?");

                        Console.WriteLine("Sauver (S) ou Tuer (T)");

                        string choixPotion = Console.In.ReadLine();
                        if (choixPotion == "s" && validerPotionS == 0|| choixPotion == "S" && validerPotionS == 0)
                        {
                            Console.WriteLine("Dans un accès de bonté, tu as sauvé " + listVictime.ElementAt(0).Nom);
                            listVictime.Remove(listVictime.ElementAt(0));
                            validerPotionS = 1;

                        }
                        else if (choixPotion == "t" && validerPotionT == 0 || choixPotion == "T" && validerPotionT == 0)
                        {
                            int validerNom = 0;
                            while (validerNom == 0)
                            {
                                Console.WriteLine("Qui désires tu tuer?");
                                string victimePotion = Console.In.ReadLine();
                                for (int i = 0; i < listeVillageois.Count; i++) //on ajoute les nominés dans la liste des victimes
                                {

                                    if (victimePotion == listeVillageois.ElementAt(i).Nom)
                                    {
                                        listVictime.Add(listeVillageois.ElementAt(i));
                                        validerNom = 1;
                                        Console.WriteLine("Les victimes seront donc " + listVictime.ElementAt(0).Nom + " ainsi que " + listVictime.ElementAt(1).Nom);
                                        validerPotionT = 1;
                                    }

                                }
                                if (validerNom == 0)
                                {
                                    Console.WriteLine("T'es bon pour recommencer mongol! ");
                                }
                            }
                        }
                        else if(validerPotionS == 1)
                        {
                            Console.WriteLine("T'as déjà sifflé la bouteille pour sauver avant tocard");
                        }
                        else if(validerPotionT == 1)
                        {
                            Console.WriteLine("Non seulement t'essaies de gruger une seconde potion, mais en plus pour buter qqun, t'es vraiment un batard!");
                        }
                    }

                }



            }
            Console.WriteLine("Après passage de la sorcière, il y " + listVictime.Count + " victimes ce soir");



            //Cupidon fait son affaire SOON, need GAB

            //Eliminer les victimes

                for (int i = 0; i < listeVillageois.Count; i++)
                {
                    while (listVictime.Count != 0)
                    {
                        if (listeVillageois.ElementAt(i).Nom == listVictime.ElementAt(0).Nom)
                        {
                            Console.WriteLine(listeVillageois.ElementAt(i).Nom + " va crever comme une merde");
                            listVictime.Remove(listVictime.ElementAt(0));
                            listeVillageois.Remove(listeVillageois.ElementAt(i));
                        }
                    }
                }


            


            // on regarde les nominés de la liste

            //CHANGER DE PLACE CE QUI SUIT POUR LE METTRE DANS LE DECOMPTE DES MORTS
            /*for (int i = 0; i < listVictime.Count; i++) {
                if (listVictime.Count>1) { 
                    if (listVictime.ElementAt(0).PlayerOrdre == listVictime.ElementAt(1).PlayerOrdre)// modifier la méthode pour continuer à la parcourir
                    {
                        Console.WriteLine("C'est le même du coup "+ listVictime.ElementAt(0).Nom +" va crever");
                        Console.WriteLine(" c'est le même du coup " + listVictime.ElementAt(0).Nom + " va crever");
                        listVictime.Remove(listVictime.ElementAt(1));
                        for (int z = 0; z < listeVillageois.Count; z++) {
                            if (listeVillageois.ElementAt(z) == listVictime.ElementAt(0)) { // on compare seulement 1 vu que c'est les 2 mêmes
                                Console.WriteLine(" la misquine " + listVictime.ElementAt(1).Nom + " est crevée");
                                listeVillageois.Remove(listeVillageois.ElementAt(z));
                            }
                        }
                    break;
                    }
                     // faire si c'est pas le même et faire vider la liste des victimes
                    else if(listVictime.ElementAt(0).PlayerOrdre != listVictime.ElementAt(1).PlayerOrdre) {
                        Console.WriteLine(" c'est pas le même du coup " + listVictime.ElementAt(0).Nom + " va pas crever");
                        Random aleatoire = new Random();
                        int numVictime = aleatoire.Next(2);
                        Console.WriteLine(" c'est pas le même du coup " + listVictime.ElementAt(1).Nom + " va pas crever");
                        for (int z = 0; z < listeVillageois.Count; z++) {
                            if (numVictime == 0)
                            {
                                Console.WriteLine(" la misquine " + listVictime.ElementAt(0).Nom + " est crevée 0000");
                                listeVillageois.Remove(listVictime.ElementAt(0));
                                break;
                            }
                            else if (numVictime == 1)
                            {
                                Console.WriteLine(" la misquine " + listVictime.ElementAt(1).Nom + " est crevée 1111");
                                listeVillageois.Remove(listVictime.ElementAt(1));
                                break;
                            }
                            Console.WriteLine(" " + listVictime.ElementAt(i).Nom + " est crevé comme des merdes" + listVictime.ElementAt(i));
                            Console.WriteLine("nouvelle liste des grosse misquines " + listeVillageois.Count+" les noms qui reste "+listeVillageois.ElementAt(z).Nom);
                        }
                    }
                    Console.WriteLine("Before "+listVictime.Count);
                    break;
                    }
            }
                listVictime=null;*/


        }


        public void tourDesVillageois() { // même type de méthode pour les villageois

            Console.WriteLine(" Mtn les villageois vont chercher si il y a des loups ...");
            Console.WriteLine(" création d'une liste de save");
            List<int> lesVotes = new List<int>();
            afficherVillageois();
            foreach (var v in listeVillageois) {
                Console.WriteLine("Votre choix ");
                string choixVillageois = Console.In.ReadLine();
                //boucle pour ajouter +1 si la le nom rentré correspond à un nom
                for (int i = 0; i < listeVillageois.Count; i++) {
                    if (choixVillageois == listeVillageois.ElementAt(i).Nom) {
                        lesVotes.Add(listeVillageois.ElementAt(i).VoteContre += 1);
                        Console.WriteLine(" le nom des petits malins " + listeVillageois.ElementAt(i).Nom + " et les votes contre eux " +listeVillageois.ElementAt(i).VoteContre+ " ");
                        
                    }
                }
                Console.WriteLine(" list des votes "+lesVotes+" ");
            }
            int voteMax = lesVotes.Max();
            //for (int i = 0; i < lesVotes.Count; i++) {     //on retire le villageois qui à le plus de vote contre lui
                for (int z = 0; z < listeVillageois.Count; z++) {
                    if (voteMax == listeVillageois.ElementAt(z).VoteContre) {
                    Console.WriteLine("le jugement est rendu pour le villageois... "+"'"+listeVillageois.ElementAt(z).Nom+"'"+" tu vas crever sur la place publique");
                    listeVillageois.RemoveAt(z);
                    
                    }
                }

            for (int i = 0; i < listeVillageois.Count; i++)
            {
                listeVillageois.ElementAt(i).VoteContre = 0;
            }

                // }


            }
    }
}
