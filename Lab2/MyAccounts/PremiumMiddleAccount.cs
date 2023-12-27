using System;
using Lab2;
using Lab2.MyGames;
using Lab2.MyAccounts;

namespace Lab2.MyAccounts
{
    public class PremiumMiddleAccount : Account
    {
        public PremiumMiddleAccount(string userName) : base(userName)
        {
        }

        public override void WinGame(string typeGame, GameHistory game, Account player)
        {
            var bonus = 0;
            if (game.Rating < 0)
            {
                throw new ArgumentException("rating < 0");
            }

            var beforeRating = CurrentRating;

            var winners = 0;

            if (Results.Count >= 3)
            {
                for (var i = Results.Count - 1; i > Results.Count - 4; i--)
                {
                    if (Results[i].Outcome == GameOutcome.WIN)
                    {
                        winners++;
                    }
                }
            }


            if (winners == 3)
            {
                CurrentRating += (int)(game.Rating * 1.5);
                bonus = (int)(game.Rating * 1.5) - game.Rating;
            }
            else
            {
                CurrentRating += game.Rating;
            }

            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.WIN, player, beforeRating,
                CurrentRating, bonus));
        }
    }
}