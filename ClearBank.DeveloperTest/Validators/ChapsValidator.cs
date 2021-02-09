using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators.Interfaces
{
    public class ChapsValidator : IPaymentValidator
    {
        public bool IsValid(MakePaymentRequest request, Account account)
        {
            return account != null &&
                  account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) &&
                  account.Status == AccountStatus.Live;
        }
    }
}
