using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class DoorFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void doorFactoryConstructorTest()
        {
            List<AbstractQuestion> quest = new List<AbstractQuestion>();

            DoorFactory df = new DoorFactory(quest);
            Assert.AreEqual(quest, df.Questions);

            df = new DoorFactory(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void makeHDoorsTest()
        {
            List<AbstractQuestion> questions = new List<AbstractQuestion>();
            DoorFactory df = new DoorFactory(questions);

            df.makeHDoors(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void makeVDoorsTest()
        {
            List<AbstractQuestion> questions = new List<AbstractQuestion>();
            DoorFactory df = new DoorFactory(questions);

            df.makeVDoors(-1);
        }
    }
}
