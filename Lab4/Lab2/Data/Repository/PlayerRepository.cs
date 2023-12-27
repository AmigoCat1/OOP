using System;
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

        public void Create(string userName, string accountType)
        {
            Account account;
            switch (accountType)
            {
                case "Simple":
                    account = new Account(userName);
                    break;
                case "Premium":
                    account = new PremiumAccount(userName);
                    break;
                case "PremiumMiddle":
                    account = new PremiumMiddleAccount(userName);
                    break;
                default:
                    throw new ArgumentException();
            }
            _dbContext.Players.Add(account);
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