using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1
{
    public class Game
    {
        private readonly Random _random = new Random();

        private List<GameHistory> Results { get; }
        private string NameGame { get; }
        private Dictionary<GameAccount, int> Players { get; }


        public Game(string nameGame)
        {
            NameGame = nameGame;
            Results = new List<GameHistory>();
            Players = new Dictionary<GameAccount, int>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "\t\t\t\t\t\t/-----------------------------\\\n\t\t\t\t\t\t|\\/\\/ Game created " + nameGame + " \\/\\/|");
            Console.WriteLine(
                "\t\t\t\t\t\t\\-----------------------------/");
            Console.ResetColor();
        }

        public void Information()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t      Stats about " + NameGame);
            Console.WriteLine("\t\t\t\t\t\t      Games count: " + Results.Count);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t____________________________________________________________________________\n" +
                              "\t\t\t|  ID  |       |    PLAYERS   |       |RATING GAME|       |     RESULT     |\n" +
                              "\t\t\t----------------------------------------------------------------------------");
            foreach (var result in Results)
            {
                Console.WriteLine(
                    $"\t\t\t|{result.Id,6}|  -->  |{result.Player1.UserName,5} VS {result.Player2.UserName,-5}|  -->  |     {result.Rating}     |  -->  |{result.Player1.UserName,5} {result.Outcome,-4} {result.Player2.UserName,-5}|");
            }
            Console.WriteLine("\t\t\t----------------------------------------------------------------------------");
            Console.ResetColor();
        }

        public void Top3()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t\t\t\t\t\t      ___________________\n\t\t\t\t\t\t      Top 3 for \"{NameGame}\"");
            var sortedDict = Players.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int top3 = 0;
            for (int i = sortedDict.Count - 1; i >= 0; i--)
            {
                top3++;
                if (top3 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (top3 == 2)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine(
                    $"\t\t\t\t\t\t      {top3} place: {sortedDict.ElementAt(i).Key.UserName,5} ({sortedDict.ElementAt(i).Value,2})");
                if (top3 == 3)
                {
                    break;
                }
            }
            Console.ResetColor();
            for (int i = top3; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("\t\t\t\t\t\t      Game clear");
                    break;
                }

                if (i == 2)
                {
                    Console.WriteLine("\t\t\t\t\t\t      3 place: --------");
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t      -------------------\n");
            Console.ResetColor();

        }

        public void PlayingGame(GameAccount player1, GameAccount player2, int rating)
        {
            var random = _random.Next(1, 101);

            Regex shabl = new Regex(@"\D");
            string id = shabl.Replace(Guid.NewGuid().ToString(), "").Substring(0, 6);

            if (random % 10 == 0)
            {
                player1.TieGame(NameGame, id, rating, player2);
                player2.TieGame(NameGame, id, rating, player1);
                Results.Add(new GameHistory(id, player1, player2, rating, GameOutcome.TIE));
            }
            else if (random % 2 != 0)
            {
                player1.WinGame(NameGame, id, rating, player2);
                player2.LoseGame(NameGame, id, rating, player1);
                Results.Add(new GameHistory(id, player1, player2, rating, GameOutcome.WIN));
            }
            else
            {
                player1.LoseGame(NameGame, id, rating, player2);
                player2.WinGame(NameGame, id, rating, player1);
                Results.Add(new GameHistory(id, player1, player2, rating, GameOutcome.LOSE));
            }

            AddPlayersToTop(player1);
            AddPlayersToTop(player2);
        }

        private void AddPlayersToTop(GameAccount player)
        {
            if (Players.Keys.ToList().IndexOf(player) == -1)
            {
                Players.Add(player, player.CurrentRating);
            }
            else
            {
                Players[player] = player.CurrentRating;
            }
        }



    }
}
