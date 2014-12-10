using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class SaveDataTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void saveDataConstructorTest()
        {
            Maze maze = null;
            Room room = null;
            SaveData sd = new SaveData(maze, room);
        }
    }
}