using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Models
{
    /**
     * une partie est composée de plusieurs manches
     */
    public class Partie
    {
        public static int SCORE_END_GAME = 1000;

        // liste des joueurs connectés à la partie
        private Equipe equipe1 = new Equipe();
        private Equipe equipe2 = new Equipe();
        private int joueurEnCours;
        private List<Manche> manches = new List<Manche>();

        /**
         * on ajoute le joueur qui rejoins la partie dans une equipe
         */
        public bool addPlayer(ArrayList joueur)
        {
            if (equipe1.Joueur1 == null) equipe1.Joueur1 = joueur;
            else if (equipe2.Joueur1 == null) equipe2.Joueur1 = joueur;
            else if (equipe1.Joueur2 == null) equipe1.Joueur2 = joueur;
            else if (equipe2.Joueur2 == null)
            {
                equipe2.Joueur2 = joueur;
                // lancer 1ere Manche
                startGame();
            } else return false;

            return true;
        }

        private void startGame()
        {
            while (equipe1.ScoreCumule < SCORE_END_GAME && equipe2.ScoreCumule < SCORE_END_GAME)
            {
                Manche manche = new Manche(equipe1, equipe2);
                manches.Add(manche);
                joueurEnCours = manches.Count % 4;
                //manche.lancerLesMises();
            }

            Equipe gagnant;
            Equipe perdant;
            if (equipe1.ScoreCumule > SCORE_END_GAME)
            {
                gagnant = equipe1;
                perdant = equipe2;
            } else
            {
                gagnant = equipe2;
                perdant = equipe1;
            }

            Console.Out.WriteLine("FELICITATIONS !");
            Console.Out.WriteLine(gagnant + " ont gagné avec " + gagnant.ScoreCumule + " contre " +
                                  perdant.ScoreCumule);
        }

        public Equipe Equipe1 => equipe1;

        public Equipe Equipe2 => equipe2;

        public List<Manche> Manches => manches;
    }
}