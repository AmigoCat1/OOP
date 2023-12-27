using System.Collections.Generic;
using Lab2.MyGames;

namespace Lab2.Data.Repository
{
    public interface IGameRepository
    {
        void Create(string gameType);
        Game Read(string gameType);
        List<Game> ReadAll();
    }
}