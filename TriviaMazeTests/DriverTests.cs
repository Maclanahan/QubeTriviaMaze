using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class DriverTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void driverConstructorTest()
        {
            Driver driver = new Driver(0, 0, 2, 2, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void setCurrentRoomTest()
        {
            Driver driver = new Driver(0, 0, 2, 2, 3);
            Room room = null;

            driver.setCurrentRoom(room);
        }
    }
}