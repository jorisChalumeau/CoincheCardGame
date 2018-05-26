using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using SQLitePCL;

namespace CoincheCardGame.Models
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
        
        private List<Manche> manches = new List<Manche>();

        /**
         * on ajoute le joueur qui rejoins la partie dans une equipe
         */
        public void addPlayer(string joueur)
        {
            if (equipe1.Joueur1 == null)
                equipe1.Joueur1 = joueur;
            else if (equipe2.Joueur1 == null)
                equipe2.Joueur1 = joueur;
            else if (equipe1.Joueur2 == null)
                equipe1.Joueur2 = joueur;
            else if (equipe2.Joueur2 == null)
            {
                equipe2.Joueur2 = joueur;
                // lancer 1ere Manche
                startGame();
            }
            else
                Console.Out.WriteLine("This game is already full ; there are alreadu 4 players in this game.");
        }

        private void startGame()
        {
            while (equipe1.ScoreCumule < SCORE_END_GAME && equipe2.ScoreCumule < SCORE_END_GAME)
            {
                Manche manche = new Manche(equipe1, equipe2);
                manches.Add(manche);
                //manche.lancerLesMises();
            }
            Equipe gagnant = (equipe1.ScoreCumule > SCORE_END_GAME ? equipe1 : equipe2);
            Equipe perdant = (equipe1.ScoreCumule > SCORE_END_GAME ? equipe2 : equipe1);
            Console.Out.WriteLine("FELICITATIONS !");
            Console.Out.WriteLine(gagnant+" ont gagné avec "+gagnant.ScoreCumule+" contre "+perdant.ScoreCumule);
        }

        public Equipe Equipe1 => equipe1;
        
        public Equipe Equipe2 => equipe2;

        public List<Manche> Manches => manches;
    }
}