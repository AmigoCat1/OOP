using System.Collections.Generic;
using Lab2.Data.Repository;
using Lab2.MyAccounts;

namespace Lab2.Data.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void CreateAccount(string userName)
        {
            _playerRepository.Create(userName);
        }

        public List<Account> ReadAccounts()
        {
            return _playerRepository.ReadAll();
        }

        public Account ReadAccountBytId(string userName)
        {
            return _playerRepository.Read(userName);
        }
    }
}