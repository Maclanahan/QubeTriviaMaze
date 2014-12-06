using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class QuestionManagerTests
    {
        [TestMethod]
        public void constructorTest()
        {
            QuestionManager manager = new QuestionManager("MCQuestions");
            StringAssert.Contains(manager.getType(), "MCQuestions");

            //Assert.Fail();
        }

        [TestMethod]
        public void failingTest()
        {
            Assert.Fail();
        }
    }
}

// NOTE: To make more tests, just copy this template and make sure it's in this project. 
//      Or, right-click on TriviaMazeTests -> Add -> New Item -> Visual C# Items -> Test -> Unit Test
// Also, for Unit Testing to work, the classes that are called need to be public,
// and be careful for user input. It can't check a method if it requires user input. Though I'm sure there's a way to.
