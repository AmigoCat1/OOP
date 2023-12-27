using System;
using Lab2;
using Lab2.MyAccounts;
using System.Security.Principal;

namespace Lab2.MyGames
{
    public class GameHistory
    {
        public string Id { get; }

        public Account Player1 { get; }

        public Account Player2 { get; }

        public int Rating { get; set; }

        public GameOutcome Outcome { get; }

        public GameHistory(Account player1, Account player2, int rating, GameOutcome outcome)
        {
            Id = GetId();
            Player1 = player1;
            Player2 = player2;
            Rating = rating;
            Outcome = outcome;
        }

        private static string GetId()
        {
            return Guid.NewGuid().ToString();

        }
    }
}