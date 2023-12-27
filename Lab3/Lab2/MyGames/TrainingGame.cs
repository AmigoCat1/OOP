using System.Linq;
using Lab2;
using Lab2.MyAccounts;
using Lab2.MyGames;
using System.Security.Principal;
using System;

namespace Lab2.MyGames
{
    public class TrainingGame : Game
    {


        public TrainingGame()
        {
            TypeGame = GetType().ToString().Substring(GetType().ToString().LastIndexOf('.') + 1);
        }


        public override void PlayingGame(Account player1, Account player2, int rating = 0)
        {
            rating = 0;

            var random = Random.Next(1, 3);

            if (random == 1)
            {
                Results.Add(new GameHistory(player1, player2, rating, GameOutcome.WIN));
                player1.WinGame(TypeGame, Results.Last(), player2);
                player2.LoseGame(TypeGame, Results.Last(), player1);
            }
            else
            {
                Results.Add(new GameHistory(player1, player2, rating, GameOutcome.LOSE));
                player1.LoseGame(TypeGame, Results.Last(), player2);
                player2.WinGame(TypeGame, Results.Last(), player1);
            }
        }
    }
}