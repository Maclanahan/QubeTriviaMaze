using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class QuestionFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(DllNotFoundException))]
        public void getQuestionsTest()
        {
            List<AbstractQuestion> questions = new List<AbstractQuestion>();

            QuestionFactory qf = new QuestionFactory(3);
        }
    }
}