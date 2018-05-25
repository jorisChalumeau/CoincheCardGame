using System;

namespace CoincheCardGame.Models
{
    public enum Couleur
    {
        Coeur,
        Pique,
        Carreau,
        Trefle
    };
    
    public class Carte
    {
        private Couleur _couleur;
        private String valeur;

        public Carte(Couleur c, String val)
        {
            _couleur = c;
            valeur = val;
        }
    }
}