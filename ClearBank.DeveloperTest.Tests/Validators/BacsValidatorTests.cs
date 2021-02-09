using System;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    [TestClass]
    public class BacsValidatorTests
    {
        private BacsValidator _bacsValidator;

        [TestInitialize]
        public void SetUp()
        {
            _bacsValidator = new BacsValidator();
        }

        [TestMethod]
        public void IsValid_Should_Return_True_When_Account_Is_Allowed_In_Payment_Scheme_Bacs()
        {
           
            var result = _bacsValidator.IsValid(new MakePaymentRequest(), new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs });

           
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_Not_Allowed_In_Payment_Scheme_Bacs()
        {
           
            var result = _bacsValidator.IsValid(new MakePaymentRequest(), new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments });
           
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_Should_Return_False_When_Account_Is_Null()
        {
            
            var result = _bacsValidator.IsValid(new MakePaymentRequest(), null);

           
            Assert.IsFalse(result);
        }
    }
}
