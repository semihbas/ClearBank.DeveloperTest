using System;
using ClearBank.DeveloperTest.Data.Interfaces;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests
{
    [TestClass]
    public class PaymentServiceTests
    {

        private Mock<IPaymentValidatorFactory> _paymentValidatorFactoryMock;
        private Mock<IPaymentValidator> _paymentValidatorMock;
        private Mock<IAccountService> _accountServiceMock;
        private PaymentService _paymentService;

        [TestInitialize]
        public void SetUp()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _paymentValidatorMock = new Mock<IPaymentValidator>();

            _paymentValidatorFactoryMock = new Mock<IPaymentValidatorFactory>();

            _paymentService = new PaymentService(_accountServiceMock.Object, _paymentValidatorFactoryMock.Object);
        }

        [TestMethod]
        public void MakePayment_Should_Return_Response_False()
        {
            
            _paymentValidatorMock
                .Setup(validator => validator.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
                .Returns(false);

            _paymentValidatorFactoryMock.Setup(factory => factory.GetInstance(It.IsAny<MakePaymentRequest>()))
                .Returns(_paymentValidatorMock.Object);

           
            var result = _paymentService.MakePayment(new MakePaymentRequest());

           
            Assert.IsFalse(result.Success);

            _accountServiceMock.Verify(store => store.UpdateAccount(It.IsAny<Account>(), It.IsAny<MakePaymentRequest>()), Times.Never);
        }

        [TestMethod]
        public void MakePayment_Should_Return_Response_True()
        {
            
            _paymentValidatorMock
                .Setup(validator => validator.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
                .Returns(true);

            _paymentValidatorFactoryMock.Setup(factory => factory.GetInstance(It.IsAny<MakePaymentRequest>()))
                .Returns(_paymentValidatorMock.Object);        


            var result = _paymentService.MakePayment(new MakePaymentRequest());

            
            Assert.IsTrue(result.Success);

            _accountServiceMock.Verify(store => store.UpdateAccount(It.IsAny<Account>(), It.IsAny<MakePaymentRequest>()), Times.Once);

        }
    }
}
