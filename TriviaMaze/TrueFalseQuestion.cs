using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class TrueFalseQuestion :AbstractQuestion
    {
        public TrueFalseQuestion(string quest, string answer)
            : base(quest, answer)
        { }

        override protected void displayChoices()
        {
            Console.WriteLine("1: T");
            Console.WriteLine("2: F");

            Console.WriteLine("Answer by typing 1 or 2.");

        }

    }
}
