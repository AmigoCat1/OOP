using System.Collections.Generic;
using Lab2.MyAccounts;
using Lab2.MyGames;

namespace Lab2.Data
{
    public class DbContext
    {
        public List<Account> Players { get; } = new List<Account>();
        public List<Game> Games { get; } = new List<Game>();

        public void AddPlayer(Account player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Account player)
        {
            Players.Remove(player);
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        public void RemoveGame(Game game)
        {
            Games.Remove(game);
        }
    }
}