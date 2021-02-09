using System;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    [TestClass]
    public class PaymentValidatorFactoryTests
    {
        private PaymentValidatorFactory _paymentValidatorFactory;

        [TestInitialize]
        public void SetUp()
        {
            _paymentValidatorFactory = new PaymentValidatorFactory();
        }

        [TestMethod]
        public void GetInstance_Should_Return_BacsValidator()
        {
            var result = _paymentValidatorFactory.GetInstance(new MakePaymentRequest { PaymentScheme = PaymentScheme.Bacs });

            Assert.IsInstanceOfType(result, typeof(BacsValidator));
        }

        [TestMethod]
        public void GetInstance_Should_Return_FasterPaymentsValidator()
        {
            var result = _paymentValidatorFactory.GetInstance(new MakePaymentRequest { PaymentScheme = PaymentScheme.FasterPayments });

            Assert.IsInstanceOfType(result, typeof(FasterPaymentsValidator));
        }

        [TestMethod]
        public void GetInstance_Should_Return_ChapsValidator()
        {
            var result = _paymentValidatorFactory.GetInstance(new MakePaymentRequest { PaymentScheme = PaymentScheme.Chaps });

            Assert.IsInstanceOfType(result, typeof(ChapsValidator));
        }

       
    }
}
