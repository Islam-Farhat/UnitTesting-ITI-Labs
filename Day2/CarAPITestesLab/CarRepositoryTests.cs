using CarAPI.Entities;
using CarAPI.Repositories_DAL;
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
    public class CarRepositoryTests
    {
        private static Mock<InMemoryContext> _context;
        private static CarsRepository _carRepository;
        private static List<Car> _carslist;


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _context = new Mock<InMemoryContext>();
            _carRepository = new CarsRepository(_context.Object);
            _carslist = new List<Car>
            {
                new Car (1 , CarType.Audi , 10),
                new Car (2, CarType.BMW , 10),
                new Car (3, CarType.Audi , 10),

            };
        }

        [TestMethod]
        public void AddCar_Car_ConatinCar()
        {
            var car = new Car(1, CarType.Audi, 0);
            _context.Setup(a => a.Cars).Returns(_carslist);

            _carRepository.AddCar(car);

            CollectionAssert.Contains(_carslist, car);

        }

        [TestMethod]
        public void RemoveCar_Car_DoesnotConatinCar()
        {
            var car = new Car(1, CarType.Audi, 0);
            _context.Setup(a => a.Cars).Returns(_carslist);

            _carRepository.Remove(car.Id);

            CollectionAssert.DoesNotContain(_carslist, car);

        }
        [TestMethod]
        public void GetAllCars_MultipleCars_NotNull()
        {
            _context.Setup(a => a.Cars).Returns(_carslist);

            var cars = _carRepository.GetAllCars();

            Assert.IsNotNull(cars);

        }

        [TestMethod]
        public void GetCarById_ExistingCar_NotNull()
        {
            var car = new Car(1, CarType.Audi, 0);
            _context.Setup(a => a.Cars).Returns(_carslist);

            var carId = _carRepository.GetCarById(car.Id);

            Assert.IsNotNull(carId);

        }


    }
}
