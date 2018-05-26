using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CoincheCardGame.Models
{
    public class Equipe
    {
        private string joueur1;
        private string joueur2;
        private int scoreCumule = 0;

        public string Joueur1
        {
            get => joueur1;
            set => joueur1 = value;
        }

        public string Joueur2
        {
            get => joueur2;
            set => joueur2 = value;
        }

        public void addScore(int score)
        {
            scoreCumule += score;
        }

        public int ScoreCumule => scoreCumule;

        public override string ToString()
        {
            return "L'équipe de "+joueur1+" et "+joueur2;
        }
    }
}