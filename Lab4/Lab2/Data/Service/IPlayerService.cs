using System.Collections.Generic;
using Lab2.MyAccounts;

namespace Lab2.Data.Service
{
    public interface IPlayerService
    {
        void CreateAccount(string userName, string accountType);
        List<Account> ReadAccounts();
        Account ReadAccountBytId(string userName);
    }
}