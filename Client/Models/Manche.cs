using Microsoft.AspNetCore.Mvc;

namespace CoincheCardGame.Models
{
    /**
     * il y a plusieurs manches par partie
     */
    public class Manche
    {
        private Equipe equipe1;
        private Equipe equipe2;
        private Contrat contrat1;
        private Contrat contrat2;
        private int score1;
        private int score2;

        public Manche(Equipe e1, Equipe e2)
        {
            equipe1 = e1;
            equipe2 = e2;
        }

        public Equipe Equipe1 => equipe1;

        public Equipe Equipe2 => equipe2;

        public Contrat Contrat1 => contrat1;

        public Contrat Contrat2 => contrat2;

        public int Score1 => score1;

        public int Score2 => score2;
    }
}