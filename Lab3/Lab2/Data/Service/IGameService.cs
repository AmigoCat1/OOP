using System.Collections.Generic;
using Lab2.MyAccounts;
using Lab2.MyGames;

namespace Lab2.Data.Service
{
    public interface IGameService
    {
        void CreateGame(string gameType);
        List<Game> ReadGames();
        Game ReadGameBytId(string gameType);
    }
}