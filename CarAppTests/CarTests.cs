using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarAppTests
{
    [TestClass]
    public class CarTests
    {
        public TestContext TestContext { get; set; }
        //public static Car car;
        #region Initialize

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            //car = new Car(CarType.Audi, 25, DrivingMode.Forward);
            context.WriteLine("Class init");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestInitialize] 
        public void Init() 
        {
            TestContext.WriteLine("Test init");
        }

        [TestCleanup]
        public void Cleanup() 
        {
            TestContext.WriteLine("Test cleanup");
        }

        public CarTests()
        {
            Console.WriteLine("CTOR");
        }
        #endregion

        #region Assert Class
        [Owner("Mahmoud")]
        [TestCategory("Equality")]
        [Priority(2)]
        [TestMethod]
        public void TimeToCoverProvidedDistance_Distance100Velocity25_Time4()
        {
            // Arrange
            Car car = new Car(CarType.Audi, 25, DrivingMode.Forward);
            double providedDistance = 100;
            double expectedResult = 4;

            // Act
            var actualResult = car.TimeToCoverProvidedDistance(providedDistance);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Owner("Maghawry")]
        [TestCategory("Equality")]
        [TestMethod]
        public void TwoCars_DifferentInstancesSameState_EqualCars()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 25, DrivingMode.Forward);
            Car car2 = new Car(CarType.Toyota, 25, DrivingMode.Forward);

            // Act

            // Assert
            Assert.AreEqual(car1, car2);
        }

        [Owner("Mahmoud")]
        [Priority(1)]
        [TestMethod]
        public void TwoCars_DifferentInstancesSameState_NotSame()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 25, DrivingMode.Forward);
            Car car2 = new Car(CarType.Toyota, 25, DrivingMode.Forward);

            // Act

            // Assert
            Assert.AreNotSame(car1, car2);
        }

        [TestMethod]
        public void GetMyCar_ExistingInstance_IsCar()
        {
            // Arrange
            Car car = new Car();

            // Act
            Car actualCar = car.GetMyCar();

            // Assert
            Assert.IsInstanceOfType(actualCar, typeof(Car));
        }

        [Ignore]
        [TestMethod]
        public void GetMyCar_ExistingInstance_IsNotNull()
        {
            // Arrange
            Car car = new Car();

            // Act
            Car actualCar = car.GetMyCar();

            // Assert
            Assert.IsNotNull(actualCar);
        }

        [TestMethod]
        public void IsStopped_Velocity10_False()
        {
            Car car = new Car(CarType.Honda, 10, DrivingMode.Forward);

            var result = car.IsStopped();

            Assert.IsFalse(result);
        }
        #endregion

        #region String Assert
        [TestMethod]
        public void GetDirection_Forward_PrintForward()
        {
            Car car = new Car(CarType.Audi, 10, DrivingMode.Forward);
            string expected = "Forward";

            var actual = car.GetDirection();

            StringAssert.Matches(actual, new System.Text.RegularExpressions.Regex(expected));
        }

        #endregion

        #region Exception
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void Accelerate_Honda_ThrowException()
        {
            Car car = new Car(CarType.Honda, 10, DrivingMode.Forward);

            car.Accelerate();
        }
        #endregion
    }
}
