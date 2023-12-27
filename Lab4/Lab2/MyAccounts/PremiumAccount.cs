using System;
using Lab2;
using Lab2.MyGames;
using Lab2.MyAccounts;


namespace Lab2.MyAccounts
{
    public class PremiumAccount : Account
    {
        public PremiumAccount(string userName) : base(userName)
        {
        }

        public override void WinGame(string typeGame, GameHistory game, Account player)
        {
            if (game.Rating < 0)
            {
                throw new ArgumentException("rating < 0");
            }


            var beforeRating = CurrentRating;
            CurrentRating += game.Rating * 2;
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.WIN, player, beforeRating,
                CurrentRating, game.Rating));
        }

        public override void LoseGame(string typeGame, GameHistory game, Account player)
        {
            var bonus = 0;
            if (game.Rating < 0)
            {
                throw new ArgumentException("rating < 0");
            }

            var beforeRating = CurrentRating;

            CurrentRating -= game.Rating / 2;
            bonus = game.Rating - game.Rating / 2;

            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.LOSE, player, beforeRating,
                CurrentRating, bonus));
        }
    }
}