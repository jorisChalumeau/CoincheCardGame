using System;
using System.Collections.Generic;

namespace CoincheCardGame.Models
{
    public class Deck
    {
        public List<Carte> Cartes;
        
        public Deck()
        {
            Cartes = new List<Carte>();
            foreach (Couleur c in Enum.GetValues(typeof(Couleur)))
            {
                if (!c.Equals(Couleur.ToutAtout) && !c.Equals(Couleur.SansAtout))
                {
                    for (int i = 7; i < 11; i++)
                    {
                        Cartes.Add(new Carte(c, i.ToString()));
                    }

                    Cartes.Add(new Carte(c, "J"));
                    Cartes.Add(new Carte(c, "Q"));
                    Cartes.Add(new Carte(c, "R"));
                    Cartes.Add(new Carte(c, "A"));
                }
            }
        }

        /**
         * to shuffle the deck at the begin of every game
         */
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = Cartes.Count; i > 1; i--)
            {
                int rand = random.Next(i + 1);
                Carte save = Cartes[rand];
                Cartes[rand] = Cartes[i];
                Cartes[i] = save;
            }

            int nb = random.Next(4, 30);
            List<Carte> cartes2 = new List<Carte>();
            for (int i = nb; i < Cartes.Count; i++)
            {
                cartes2.Add(Cartes[i]);
            }
            for (int i = 0; i < nb; i++)
            {
                cartes2.Add(Cartes[i]);
            }
            for (int i = 0; i < Cartes.Count; i++)
            {
                Cartes[i] = cartes2[i];
            }
        }

        /**
         * once the trump is set (trump=atout)
         */
        public void setTrump(Couleur trump)
        {
            foreach (var carte in Cartes)
            {
                carte.setTrump(trump);
            }
        }
    }
}