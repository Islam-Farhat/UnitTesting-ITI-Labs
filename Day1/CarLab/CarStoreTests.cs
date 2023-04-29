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
    public class CarStoreTests
    {
        #region Collection Assert
        [TestMethod]
        public void AllItemsAreUnique_TwoCars_TwoCarsUnique()
        {
            Car car1 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Reverse);

            var store1 = new CarStore(new List<Car> { car1, car2 });

            var store1Cars = store1.GetAllStoreCars();

            CollectionAssert.AllItemsAreUnique(store1Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_DifferentOrderCars_Equivalent()
        {
            Car car1 = new Car(CarType.Mercedes, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Mercedes, 20, DrivingMode.Reverse);

            var store1 = new CarStore(new List<Car> { car1, car2 });
            var store2 = new CarStore(new List<Car> { car2, car1 });

            var store1Cars = store1.GetAllStoreCars();
            var store2Cars = store2.GetAllStoreCars();

            CollectionAssert.AreEquivalent(store1Cars, store2Cars);
        }
        #endregion
    }
}
