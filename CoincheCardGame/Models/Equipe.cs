using System.Collections;

namespace Server.Models
{
    public class Equipe
    {
        private ArrayList joueur1;
        private ArrayList joueur2;
        private int scoreCumule;

        public ArrayList Joueur1
        {
            get => joueur1;
            set => joueur1 = value;
        }

        public ArrayList Joueur2
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
            return "L'équipe de "+joueur1[0]+" et "+joueur2[0];
        }
    }
}