using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPITestesLab
{
    [TestClass]
    public class OwnerServiceTests
    {
        private static Mock<InMemoryContext> _context;
        private static Mock<IOwnersRepository> _ownersRepositoryMock;
        private static Mock<ICarsRepository> _carsRepositoryMock;
        private static OwnersService _ownersService;
        private static Mock<IPaymentService> _paymentServiceMock;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _context = new Mock<InMemoryContext>();
            _ownersRepositoryMock = new Mock<IOwnersRepository>();
            _carsRepositoryMock = new Mock<ICarsRepository>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _ownersService = new OwnersService(
                _ownersRepositoryMock.Object,
                _carsRepositoryMock.Object,
                _paymentServiceMock.Object
                );
        }


        [TestMethod]
        public void GetById_OwnerId1_NotNull()
        {
            var ownerinput = new Owner(1, "Islam");
            _ownersRepositoryMock.Setup(m => m.GetOwnerById(1)).Returns(ownerinput);

            var owner = _ownersService.GetById(1);

            Assert.IsNotNull(owner);
        }

        [TestMethod]
        public void GetOwners_MulpipleOwners_NotNull()
        {
            var ownersinput = new List<Owner>()
            {
                new Owner(1, "Islam"),
                new Owner(2, "Farhat"),
            };
            _ownersRepositoryMock.Setup(m => m.GetAllOwners()).Returns(ownersinput);

            var owners = _ownersService.GetOwners();

            Assert.IsNotNull(owners);
        }

        [TestMethod]
        public void BuyCar_SoldCar3Owner3_PrintAlreadySold()
        {
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

            var result = _ownersService.BuyCar(input);

            StringAssert.Contains(result, expectedResult);
        }
    }
}
