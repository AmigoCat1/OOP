using System.Collections.Generic;
using Lab2.Data.Repository;
using Lab2.MyGames;

namespace Lab2.Data.Service
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void CreateGame(string gameType)
        {
            _gameRepository.Create(gameType);
        }

        public List<Game> ReadGames()
        {
            return _gameRepository.ReadAll();
        }

        public Game ReadGameBytId(string gameType)
        {
            return _gameRepository.Read(gameType);
        }
    }
}