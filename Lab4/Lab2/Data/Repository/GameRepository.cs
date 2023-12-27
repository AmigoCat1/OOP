using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.MyGames;

namespace Lab2.Data.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DbContext _dbContext;

        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(string gameType)
        {
            Game game;
            var fabricGame = new FabricGame();
            
            switch (gameType)
            {
                case "ClassicGame":
                    game = fabricGame.GetClassic();
                    break;
                case "TrainingGame":
                    game = fabricGame.GetTraining();
                    break;
                case "GameForOne":
                    game = fabricGame.GetGameForOne();
                    break;
                default:
                    throw new ArgumentException();
            }
            
            _dbContext.Games.Add(game);
        }

        public Game Read(string gameType)
        {
            return _dbContext.Games.First(game => game.TypeGame == gameType);
        }

        public List<Game> ReadAll()
        {
            return _dbContext.Games;
        }
    }
}