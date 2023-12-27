using Lab2.Data;
using Lab2.Data.Repository;
using Lab2.Data.Service;
using Lab2.MyAccounts;

namespace Lab2.Menu
{
    public class CommandController : ICommandController
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;

        public CommandController()
        {
            var db = new DbContext();
            _playerService = new PlayerService(new PlayerRepository(db));
            _gameService = new GameService(new GameRepository(db));
        }

        public void ShowPLayers()
        {
            foreach (var readAccount in _playerService.ReadAccounts())
            {
                readAccount.InformationForPlayer();
                readAccount.GetStats();
            }
        }

        public void AddPLayer(string account, string accountType)
        {
            _playerService.CreateAccount(account, accountType);
        }

        public void ShowStatsForPlayer(string userName)
        {
            var player = _playerService.ReadAccountBytId(userName);
            player.InformationForPlayer();
            player.GetStats();
        }

        public void PlayGame(string gameType, string player1, string player2)
        {
            _gameService.CreateGame(gameType);
            var game = _gameService.ReadGameBytId(gameType);
            game.PlayingGame(_playerService.ReadAccountBytId(player1), _playerService.ReadAccountBytId(player2));
            game.Information();
        }

        public void PlayGame(string gameType, string player1)
        {
            _gameService.CreateGame(gameType);
            var game = _gameService.ReadGameBytId(gameType);
            game.PlayingGame(_playerService.ReadAccountBytId(player1), new Account("Computer"));
            game.Information();        
        }
    }
}