using System;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    [TestClass]
    public class DefaultValidatorTests
    {

        private DefaultValidator _defaultValidator;

        [TestInitialize]
        public void SetUp()
        {
            _defaultValidator = new DefaultValidator();
        }
        [TestMethod]
        public void IsValid_Should_Return_False()
        {

            var result = _defaultValidator.IsValid(
                new MakePaymentRequest(),
                new Account
                {
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                    Status = AccountStatus.Live
                });


            Assert.IsFalse(result);
        }
    }
    
}
