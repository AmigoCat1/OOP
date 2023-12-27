using System.Collections.Generic;
using System.Linq;
using Lab2.MyAccounts;

namespace Lab2.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DbContext _dbContext;

        public PlayerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(string userName)
        {
            _dbContext.Players.Add(new Account(userName));
        }

        public Account Read(string userName)
        {
            return _dbContext.Players.First(player => player.UserName == userName);
        }

        public List<Account> ReadAll()
        {
            return _dbContext.Players;
        }
    }
}