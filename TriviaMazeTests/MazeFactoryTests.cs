using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class MazeFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void makeMazeTest()
        {
            MazeFactory mf = new MazeFactory();
            Door[,] door = null;
            
            Maze maze = mf.makeMaze(3,door,door);
        }
    }
}
