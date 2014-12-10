using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void roomConstructorTest()
        {
            Room room = new Room(0, -1, 2, 2);
        }

        [TestMethod]
        public void isEndRoomTest()
        {
            Room room = new Room(2, 2, 2, 2);
            Assert.AreEqual(room.isEndRoom(), true);

            room = new Room(0, 1, 2, 2);
            Assert.AreEqual(room.isEndRoom(), false);
        }
    }
}