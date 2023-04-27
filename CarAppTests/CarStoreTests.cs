using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CarAppTests
{
    [TestClass]
    public class CarStoreTests
    {

        #region Collection Assert

        [TestMethod]
        public void GetAllStoreCars_MultipleCars_TypeCar()
        {
            // Arrange
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            CarStore store = new CarStore(new List<Car> { car1, car2, car3 });

            var cars = store.GetAllStoreCars();

            CollectionAssert.AllItemsAreInstancesOfType(cars, typeof(Car));
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_Equal()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store1 = new CarStore(new List<Car> { car1, car2});
            
            Car car3 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car4 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store2 = new CarStore(new List<Car> { car3, car4});

            // Act
            var store1Cars = store1.GetAllStoreCars();
            var store2Cars = store2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEqual(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsDifferentOrder_NotEqual()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store1 = new CarStore(new List<Car> { car1, car2});
            
            Car car3 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car4 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store2 = new CarStore(new List<Car> { car4, car3});

            // Act
            var store1Cars = store1.GetAllStoreCars();
            var store2Cars = store2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreNotEqual(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_SameCarsSameOrder_Equivalent()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store1 = new CarStore(new List<Car> { car1, car2});
            var store2 = new CarStore(new List<Car> { car1, car2});

            // Act
            var store1Cars = store1.GetAllStoreCars();
            var store2Cars = store2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_SameCarsDifferentOrder_Equivalent()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store1 = new CarStore(new List<Car> { car1, car2});
            var store2 = new CarStore(new List<Car> { car2, car1});

            // Act
            var store1Cars = store1.GetAllStoreCars();
            var store2Cars = store2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_NotEquivalent()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store1 = new CarStore(new List<Car> { car1, car2 });

            Car car3 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car4 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = store1.GetAllStoreCars();
            var store2Cars = store2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreNotEquivalent(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_AddingCar_IsSubset()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            List<Car> cars = new List<Car>() { car1, car2 };
            var store = new CarStore(new List<Car>() { car1, car2, car3 });

            var storeCars = store.GetAllStoreCars();

            CollectionAssert.IsSubsetOf(cars, storeCars);
        }
        #endregion

        #region Assert
        [TestMethod]
        public void DifferentStores_EqualCarsSameOrder_NotEqual()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store1 = new CarStore(new List<Car> { car1, car2 });

            Car car3 = new Car(CarType.Toyota, 10, DrivingMode.Forward);
            Car car4 = new Car(CarType.Audi, 20, DrivingMode.Reverse);
            var store2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = store1.GetAllStoreCars();
            var store2Cars = store2.GetAllStoreCars();

            // Assert 
            Assert.AreNotEqual(store1Cars, store2Cars); // Different List Objects
        } 
        #endregion


    }
}
