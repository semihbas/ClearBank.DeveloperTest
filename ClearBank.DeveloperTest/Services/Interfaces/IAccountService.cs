using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account, MakePaymentRequest request);

    }
}
