namespace Server.Models
{
    public enum Couleur
    {
        Coeur,
        Pique,
        Carreau,
        Trefle,
        ToutAtout,
        SansAtout
    }
    
    public class Carte
    {
        private string label;
        private Couleur _couleur;
        private int valeur;
        private Couleur trump;

        public Carte(Couleur c, string lab)
        {
            _couleur = c;
            label = lab;
        }

        public void setTrump(Couleur trumpCouleur)
        {
            trump = trumpCouleur;
            switch (label)
            {
                case "7": case "8":
                    valeur = 0;
                    break;
                case "9":
                    valeur = trump.Equals(_couleur) ? 14 : (trump.Equals(Couleur.ToutAtout) ? 9 : 0);
                    break;
                case "10":
                    valeur = trump.Equals(Couleur.ToutAtout) ? 5 : 10;
                    break;
                case "J":
                    valeur = trump.Equals(_couleur) ? 20 : (trump.Equals(Couleur.ToutAtout) ? 14 : 2);
                    break;
                case "Q":
                    valeur = trump.Equals(Couleur.ToutAtout) ? 2 : 3;
                    break;
                case "R":
                    valeur = trump.Equals(Couleur.ToutAtout) ? 3 : 4;
                    break;
                default:
                    valeur = trump.Equals(Couleur.SansAtout) ? 19 : (trump.Equals(Couleur.ToutAtout) ? 7 : 11);
                    break;
            }
        }

        private bool isSingleTrump(Couleur c)
        {
            return c.Equals(Couleur.Coeur) || c.Equals(Couleur.Pique) || c.Equals(Couleur.Carreau) || c.Equals(Couleur.Trefle);
        }

        public string Label => label;

        public Couleur Couleur => _couleur;

        public int Valeur
        {
            get => valeur;
            set => valeur = value;
        }

        public Couleur Trump => trump;
    }
}