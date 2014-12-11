using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class MazeTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void mazeConstructorTest()
        {
            Room[,] room = null;
            Door[,] door = null;
            Maze maze = new Maze(room, door, door, 3);
        }
    }
}