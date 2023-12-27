using System.Collections.Generic;
using Lab2.MyAccounts;
using Lab2.MyGames;

namespace Lab2.Data.Repository
{
    public interface IPlayerRepository
    {
        void Create(string userName, string accountType);
        Account Read(string userName);
        List<Account> ReadAll();
    }
}