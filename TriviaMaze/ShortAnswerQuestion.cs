using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class ShortAnswerQuestion :AbstractQuestion
    {
        public ShortAnswerQuestion(string quest, string answer)
            : base(quest, answer)
        { }

        override protected void displayChoices()
        {
            Console.WriteLine("Please Type in your 1 word answer.");
            Console.WriteLine("Answer: " + sAnswer);
        }

    }
}
