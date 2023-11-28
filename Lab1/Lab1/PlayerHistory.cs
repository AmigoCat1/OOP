using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class PlayerHistory
    {
        public PlayerHistory(string nameGame, string id, int rating, GameOutcome outcome, GameAccount oponent,
            int beforeRating, int afterRating)
        {
            NameGame = nameGame;
            Id = id;
            Rating = rating;
            Outcome = outcome;
            Oponent = oponent;
            BeforeRating = beforeRating;
            AfterRating = afterRating;
        }

        public static int Number = 1;

        public string NameGame { get; }

        public string Id { get; }

        public int Rating { get; }

        public GameOutcome Outcome { get; }

        public GameAccount Oponent { get; }

        public int BeforeRating { get; }

        public int AfterRating { get; }
    }
}
