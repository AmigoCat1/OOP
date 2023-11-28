using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class GameHistory
    {
        public string Id { get; }

        public GameAccount Player1 { get; }

        public GameAccount Player2 { get; }

        public int Rating { get; }

        public GameOutcome Outcome { get; }

        public GameHistory(string id, GameAccount player1, GameAccount player2, int rating, GameOutcome outcome)
        {
            Id = id;
            Player1 = player1;
            Player2 = player2;
            Rating = rating;
            Outcome = outcome;
        }
    }
}
