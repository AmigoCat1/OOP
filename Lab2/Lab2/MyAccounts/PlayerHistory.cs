using Lab2;
using Lab2.MyAccounts;

namespace Lab2.MyAccounts
{
    public class PlayerHistory
    {
        public PlayerHistory(string typeGame, string id, int rating, GameOutcome outcome, Account oponent,
            int beforeRating, int afterRating, int bonus)
        {
            TypeGame = typeGame;
            Id = id;
            Rating = rating;
            Outcome = outcome;
            Oponent = oponent;
            BeforeRating = beforeRating;
            AfterRating = afterRating;
            Bonus = bonus;
        }

        public static int Number = 1;

        public string TypeGame { get; }

        public string Id { get; }

        public int Rating { get; }

        public GameOutcome Outcome { get; }

        public Account Oponent { get; }

        public int BeforeRating { get; }

        public int AfterRating { get; }

        public int Bonus { get; }

    }
}