using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLab
{
    [TestClass]
    public class CarTests
    {
        #region Assert

        [TestMethod]
        public void IsStopped_VelocityEqualZero_True()
        {
            Car car = new Car(CarType.Honda, 0, DrivingMode.Forward);

            var result = car.IsStopped();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Brake_ToyotaVelocity40_Velocity30()
        {
            Car car = new Car(CarType.Toyota, 40, DrivingMode.Forward);
            double expectedVelocity = 30;
            car.Brake();

            Assert.AreEqual(expectedVelocity, car.Velocity);
        }

        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void Brake_Honda_ThrowException()
        {
            Car car = new Car(CarType.Honda, 10, DrivingMode.Forward);

            car.Brake();
        }
        [TestMethod]
        public void GetMyCar_ExistingInstance_IsCar()
        {
            var car = new Car();

            Car actualCar = car.GetMyCar();

            Assert.IsInstanceOfType(actualCar, typeof(Car));
        }

        #endregion

        #region String Assert

        [TestMethod]
        public void StartsWith_CarForward_ReturnF()
        {
            Car car = new Car(CarType.Audi, 10, DrivingMode.Forward);
            string expected = "F";

            var actual = car.GetDirection();
            StringAssert.StartsWith(actual, expected);

        }

        [TestMethod]
        public void GetDirection_Stopped_PrintStopped()
        {
            Car car = new Car(CarType.Audi, 10, DrivingMode.Stopped);
            string expected = "Stopped";

            var actual = car.GetDirection();


            StringAssert.Matches(actual, new System.Text.RegularExpressions.Regex(expected));
        }

        #endregion

        
    }
}
