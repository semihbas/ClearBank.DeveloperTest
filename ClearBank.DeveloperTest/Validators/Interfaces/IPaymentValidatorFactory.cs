using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentValidatorFactory
    {

        IPaymentValidator GetInstance(MakePaymentRequest request);

    }
}
