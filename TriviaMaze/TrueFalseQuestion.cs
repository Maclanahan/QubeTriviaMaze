using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class TrueFalseQuestion :AbstractQuestion
    {
        public TrueFalseQuestion(string quest, string answer, List<String> choices)
            : base(quest, answer, choices)
        { }

        override protected void displayChoices()
        {
            for (int i = 0; i < sChoices.Count; i++)
            {
                int count = i + 1;

                Console.WriteLine(count + ": " + sChoices[i]);
            }

            Console.WriteLine("Answer by typing 1 or 2.");

        }

    }
}
