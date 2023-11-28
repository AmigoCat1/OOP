using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class GameAccount
    {
        public string UserName { get; }
        public int CurrentRating { get; private set; } = 1;

        private List<PlayerHistory> Results { get; }

        public GameAccount(string userName)
        {
            UserName = userName;
            Results = new List<PlayerHistory>();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t<-- Player created " + userName + " -->");
            Console.ResetColor();
        }

        public void InformationForPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t\t\t\t      Information for " + UserName);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t\t      Player: " + UserName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t      Rating : " + CurrentRating);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t      All game : " + Results.Count);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t\t\t      Win game : " + Results.Count(x => x.Outcome == GameOutcome.WIN));
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\t\t\t\t\t      Lose game : " + Results.Count(x => x.Outcome == GameOutcome.LOSE));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t\t\t      Tie game : " + Results.Count(x => x.Outcome == GameOutcome.TIE) +
                              "\n");

            Console.ResetColor();
        }
        public void GetStats()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{"Stats about",65} " + UserName);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("_________________________________________________________________________________________________________________\n" +
                              "| № |       |Name game|       |  ID  |       |RATING GAME|       |     RESULT     |       |CHANGE|       |RATING|\n" +
                              "-----------------------------------------------------------------------------------------------------------------");

            foreach (var result in Results)
            {
                Console.WriteLine(
                    $"|{PlayerHistory.Number,2} |  -->  |  {result.NameGame} |  -->  |{result.Id,6}|  -->  |     " +
                    $"{result.Rating}     |  -->  |{UserName,5} {result.Outcome,-4} {result.Oponent.UserName,-5}|" +
                    $"  -->  |{result.BeforeRating,2} {(result.Outcome == GameOutcome.LOSE ? "-" : "+")}{result.Rating,2}|" +
                    $"  -->  |  {result.AfterRating,2}  |");
                PlayerHistory.Number++;
            }

            PlayerHistory.Number = 1;
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        public void WinGame(string nameGame, string id, int rating, GameAccount player)
        {
            if (rating < 0)
            {
                throw new ArgumentException("rating < 0");
            }

            int beforeRating = CurrentRating;
            CurrentRating += rating;
            Results.Add(new PlayerHistory(nameGame, id, rating, GameOutcome.WIN, player, beforeRating, CurrentRating));
        }

        public void LoseGame(string nameGame, string id, int rating, GameAccount player)
        {
            if (rating < 0)
            {
                throw new ArgumentException("rating < 0");
            }

            int beforeRating = CurrentRating;


            if (CurrentRating - rating < 1)
            {
                CurrentRating = 1;
            }
            else
            {
                CurrentRating -= rating;
            }

            Results.Add(new PlayerHistory(nameGame, id, rating, GameOutcome.LOSE, player, beforeRating, CurrentRating));
        }


        public void TieGame(string nameGame, string id, int rating, GameAccount player)
        {
            Results.Add(new PlayerHistory(nameGame, id, rating, GameOutcome.TIE, player, CurrentRating, CurrentRating));
        }


    }
}