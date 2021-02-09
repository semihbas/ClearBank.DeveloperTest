using System;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    [TestClass]
    public class FasterPaymentsValidatorTests
    {
        private FasterPaymentsValidator _fasterPaymentsValidator;

        [TestInitialize]
        public void SetUp()
        {
            _fasterPaymentsValidator = new FasterPaymentsValidator();
        }

        [TestMethod]
        public void IsValid_Should_Return_True_When_Account_Has_Sufficient_Funds()
        {

            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest { Amount = 20 },
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                    Balance = 30
                });


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Has_Insufficient_Funds()
        {

            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest { Amount = 20 },
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                    Balance = 19
                });


            Assert.IsFalse(result);
        }   



        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_Not_Allowed_In_Payment_Scheme_FasterPayments()
        {

            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest { Amount = 20 },
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Balance = 30
                });


            Assert.IsFalse(result);
        }

        

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_Null()
        {

            var result = _fasterPaymentsValidator.IsValid(
                new MakePaymentRequest { Amount = 20 },
                null);


            Assert.IsFalse(result);
        }
    }
}
