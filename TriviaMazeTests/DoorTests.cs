using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class DoorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void doorConstructorTest()
        {
            TrueFalseQuestion question = new TrueFalseQuestion("question","answer");
            Door door = new Door(question);

            door = new Door(null);
        }
    }
}