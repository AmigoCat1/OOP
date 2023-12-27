using System;
using System.Collections.Generic;
using System.Linq;
using Lab2;
using Lab2.MyGames;


namespace Lab2.MyAccounts
{
    public class Account
    {
        public Account(string userName)
        {
            UserName = userName;
            Results = new List<PlayerHistory>();
        }

        public string UserName { get; }

        private int _currentRating = 1;

        protected int CurrentRating
        {
            get => _currentRating;
            set => _currentRating = value < 1 ? 1 : value;
        }

        protected List<PlayerHistory> Results { get; }

        public void InformationForPlayer()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t\t\t\t\t\t      Information for " + UserName);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t\t      Type account: " + GetType().ToString().Substring(GetType().ToString().LastIndexOf('.') + 1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t\t\t      Player: " + UserName);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t\t      Rating : " + CurrentRating);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t\t\t      All game : " + Results.Count);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t\t\t      Win game : " + Results.Count(x => x.Outcome == GameOutcome.WIN));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t\t\t      Lose game : " + Results.Count(x => x.Outcome == GameOutcome.LOSE));


            Console.ResetColor();
        }

        public void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\t\t{"Stats about",65} " + UserName);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "________________________________________________________________________________________________________________________________________________________________\n" +
                "| № |       | Type game  |       |                 ID                 |       |RATING GAME|       |     RESULT     |       |CHANGE|       |RATING|       |BONUS|\n" +
                "----------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (var result in Results)
            {
                Console.WriteLine(
                    $"|{PlayerHistory.Number,2} |  -->  |{result.TypeGame,-12}|  -->  |{result.Id,6}|  -->  |     " +
                    $"{result.Rating}     |  -->  |{UserName,5} {result.Outcome,-4} {result.Oponent.UserName,-5}|" +
                    $"  -->  |{result.BeforeRating,2} {(result.Outcome == GameOutcome.LOSE ? $"-{result.BeforeRating - result.AfterRating,2}" : $"+{result.AfterRating - result.BeforeRating,2}")}|" +
                    $"  -->  |  {result.AfterRating,2}  |  -->  | +{result.Bonus}  |");
                PlayerHistory.Number++;
            }

            PlayerHistory.Number = 1;

            Console.WriteLine(
                "----------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }
        public virtual void WinGame(string typeGame, GameHistory game, Account player)
        {
            if (game.Rating < 0)
            {
                throw new ArgumentException("rating < 0");
            }


            var beforeRating = CurrentRating;
            CurrentRating += game.Rating;
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.WIN, player, beforeRating, CurrentRating, 0));
        }

        public virtual void LoseGame(string typeGame, GameHistory game, Account player)
        {

            if (game.Rating < 0)
            {
                throw new ArgumentException("rating < 0");
            }

            var beforeRating = CurrentRating;
            CurrentRating -= game.Rating;
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.LOSE, player, beforeRating, CurrentRating, 0));
        }





    }
}