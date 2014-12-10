using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TriviaMaze;

namespace TriviaMazeTests
{
    [TestClass]
    public class AbstractQuestionTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void abstractQuestionConstructorTest()
        {
            List<string> choices = new List<string>();
            MultipleChoiceQuestion question1 = new MultipleChoiceQuestion("question", "answer", choices);
            StringAssert.Contains(question1.Question, "question");
            StringAssert.Contains(question1.Answer, "answer");
            question1 = new MultipleChoiceQuestion(null, null, null);
            
            TrueFalseQuestion question2 = new TrueFalseQuestion("question", "answer");
            StringAssert.Contains(question2.Question, "question");
            StringAssert.Contains(question2.Answer, "answer");
            question2 = new TrueFalseQuestion(null,null);

            ShortAnswerQuestion question3 = new ShortAnswerQuestion("question", "answer");
            StringAssert.Contains(question3.Question, "question");
            StringAssert.Contains(question3.Answer, "answer");
            question3 = new ShortAnswerQuestion(null,null);
        }

        [TestMethod]
        public void checkAnswerTest()
        {
            TrueFalseQuestion question = new TrueFalseQuestion("question", "answer");

            PrivateObject obj = new PrivateObject(question);
            object retVal = obj.Invoke("checkAnswer", new object[]{"answer"});
            Assert.AreEqual(retVal, true);
        }
    }
}
