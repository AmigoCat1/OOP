using System;
using Lab2;
using Lab2.MyAccounts;
using Lab2.MyGames;
using System.Security.Principal;

namespace Lab2.MyGames
{
    public class GameForOne : Game
    {
        public GameForOne()
        {
            TypeGame = GetType().ToString().Substring(GetType().ToString().LastIndexOf('.') + 1);
        }

        public override void Information()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t\t\t\t\t\t      Stats about " + TypeGame);
            Console.WriteLine("\t\t\t\t\t\t\t\t      Games count: " + Results.Count);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "\t\t\t__________________________________________________________________________________________________________\n" +
                "\t\t\t|                 ID                 |       |    PLAYERS   |       |RATING GAME|       |     RESULT     |\n" +
                "\t\t\t----------------------------------------------------------------------------------------------------------");
            foreach (var result in Results)
            {
                Console.Write(
                    $"\t\t\t|{result.Id,6}|  -->  |");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{result.Player1.UserName,5}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($" VS {result.Player2.UserName,-5}|  -->  |     {result.Rating}     |  -->  |{result.Player1.UserName,5} {result.Outcome,-4} {result.Player2.UserName,-5}|");

            }

            Console.WriteLine(
                "\t\t\t----------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        public override void PlayingGame(Account player1, Account player2)
        {
            var random = Random.Next(1, 3);
            var rating = Random.Next(2, 8);

            if (random == 1)
            {
                var game = new GameHistory(player1, player2, 0, GameOutcome.WIN);
                player2.LoseGame(TypeGame, game, player1);
                game.Rating = rating;
                player1.WinGame(TypeGame, game, player2);
                Results.Add(game);
            }
            else
            {

                var game = new GameHistory(player1, player2, 0, GameOutcome.LOSE);
                player2.WinGame(TypeGame, game, player1);
                game.Rating = rating;
                player1.LoseGame(TypeGame, game, player2);
                Results.Add(game);

            }
        }
    }
}