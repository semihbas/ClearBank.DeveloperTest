using System;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentValidatorFactory :IPaymentValidatorFactory
    {

     public IPaymentValidator GetInstance(MakePaymentRequest request)
        {
            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    return new BacsValidator();
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsValidator();
                case PaymentScheme.Chaps:
                    return new ChapsValidator();
                default:
                    return new DefaultValidator();
            }
        }
       
    }
}
