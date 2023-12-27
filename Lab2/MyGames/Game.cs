using System;
using System.Collections.Generic;
using System.Security.Principal;
using Lab2.MyAccounts;

namespace Lab2.MyGames
{
    public abstract class Game
    {
        protected Game()
        {
            Results = new List<GameHistory>();
            Random = new Random();
        }

        public string TypeGame { get; set; }

        protected readonly Random Random;
        protected List<GameHistory> Results { get; }
        public abstract void PlayingGame(Account player1, Account player2, int rating);

        public virtual void Information()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t\t\t\t\t\t      Stats about " + TypeGame);
            Console.WriteLine("\t\t\t\t\t\t\t\t      Games count: " + Results.Count);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t__________________________________________________________________________________________________________\n" +
                              "\t\t\t|                 ID                 |       |    PLAYERS   |       |RATING GAME|       |     RESULT     |\n" +
                              "\t\t\t----------------------------------------------------------------------------------------------------------");
            foreach (var result in Results)
            {
                Console.WriteLine(
                    $"\t\t\t|{result.Id,6}|  -->  |{result.Player1.UserName,5} VS {result.Player2.UserName,-5}|  -->  |     {result.Rating}     |  -->  |{result.Player1.UserName,5} {result.Outcome,-4} {result.Player2.UserName,-5}|");
            }

            Console.WriteLine("\t\t\t----------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }


    }
}