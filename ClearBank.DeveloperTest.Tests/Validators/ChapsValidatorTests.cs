using System;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    [TestClass]
    public class ChapsValidatorTests
    {
        private ChapsValidator _chapsValidator;

        [TestInitialize]
        public void SetUp()
        {
            _chapsValidator = new ChapsValidator();
        }

        [TestMethod]
        public void IsValid_Should_Return_True_When_Account_Is_In_State_Live()
        {

            var result = _chapsValidator.IsValid(
                new MakePaymentRequest(),
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Status = AccountStatus.Live
                });


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_Not_Allowed_In_Payment_Scheme_Chaps()
        {

            var result = _chapsValidator.IsValid(
                 new MakePaymentRequest(),
                 new Account
                 {
                     AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                     Status = AccountStatus.Live
                 });


            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_In_State_Disabled()
        {

            var result = _chapsValidator.IsValid(
                new MakePaymentRequest(),
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Status = AccountStatus.Disabled
                });


            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_In_State_Live()
        {

            var result = _chapsValidator.IsValid(
                new MakePaymentRequest(),
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Status = AccountStatus.InboundPaymentsOnly
                });


            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_Null()
        {

            var result = _chapsValidator.IsValid(new MakePaymentRequest(), null);

            Assert.IsFalse(result);
        }
    }
}
