using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarAPITests.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CarAPITests
{
    [TestClass]
    public class OwnerServiceTests
    {
        private static Mock<IOwnersRepository> _ownersRepositoryMock;
        private static Mock<ICarsRepository> _carsRepositoryMock;
        private static OwnersService _ownersService;
        private static Mock<IPaymentService> _paymentServiceMock;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _ownersRepositoryMock = new Mock<IOwnersRepository>();
            _carsRepositoryMock = new Mock<ICarsRepository>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _ownersService = new OwnersService(
                _ownersRepositoryMock.Object,
                _carsRepositoryMock.Object,
                _paymentServiceMock.Object
                );
        }

        #region Tightly coupled
        [TestMethod]
        public void GetById_ExistingId1_NotNull_TightlyCoupled()
        {
            // Arrange
            var ownerService = new OwnersService(
                new OwnersRepository(new CarAPI.Entities.InMemoryContext()),
                new CarsRepository(new CarAPI.Entities.InMemoryContext()),
                new CashService()
                );

            // Act
            var owner = ownerService.GetById(1);

            // Assert
            Assert.IsNotNull(owner);
        }

        [TestMethod]
        public void BuyCar_UnsoldCar3Owner3_PrintSuccessfull_TightlyCoupled()
        {
            // Arrange
            var ownerService = new OwnersService(
                new OwnersRepository(new CarAPI.Entities.InMemoryContext()),
                new CarsRepository(new CarAPI.Entities.InMemoryContext()),
                new CashService()
                );
            var input = new BuyCarInput()
            {
                Amount = 100,
                CarId = 3,
                OwnerId = 3
            };
            var expectedResult = "Successfull";

            // Act
            var result = ownerService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expectedResult);
        }

        // Unit test depends on dependencies function directly  
        // Change te state in DB
        #endregion

        #region Fake Context (Stub)
        [TestMethod]
        public void BuyCar_UnsoldCar3Owner3_PrintSuccessfull_Fake()
        {
            // Arrange
            var ownerService = new OwnersService(
                new FakeOwnersRepository(new FakeInMemoryContext()),
                new FakeCarsRepository(new FakeInMemoryContext()),
                new FakePaymentService()
                );
            var input = new BuyCarInput()
            {
                Amount = 100,
                CarId = 3,
                OwnerId = 3
            };
            var expectedResult = "Successfull";

            // Act
            var result = ownerService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expectedResult);
        }
        #endregion

        #region Mocking
        [TestMethod]
        public void BuyCar_UnsoldCar3Owner3_PrintSuccessfull_Mocking()
        {
            // Arrange
            var input = new BuyCarInput()
            {
                Amount = 100,
                CarId = 3,
                OwnerId = 3
            };
            var owner = new Owner(input.OwnerId, "Mahmoud");
            var car = new Car(input.CarId, CarType.Audi, 0);
            _ownersRepositoryMock.Setup(m => m.GetOwnerById(input.OwnerId)).Returns(owner);
            _carsRepositoryMock.Setup(m => m.GetCarById(input.CarId)).Returns(car);
            _paymentServiceMock.Setup(m => m.Pay(input.Amount)).Returns("Amount in paid");

            var expectedResult = "Successfull";

            // Act
            var result = _ownersService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expectedResult);
        }
        
        [TestMethod]
        public void BuyCar_SoldCar3Owner3_PrintAlreadySold_Mocking()
        {
            // Arrange
            var input = new BuyCarInput()
            {
                Amount = 100,
                CarId = 3,
                OwnerId = 3
            };
            var owner = new Owner(input.OwnerId, "Mahmoud");
            var car = new Car(input.CarId, CarType.Audi, 0);
            car.Owner = owner;
            _carsRepositoryMock.Setup(m => m.GetCarById(input.CarId)).Returns(car);

            var expectedResult = "Already sold";

            // Act
            var result = _ownersService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expectedResult);
        }
        #endregion
    }
}
