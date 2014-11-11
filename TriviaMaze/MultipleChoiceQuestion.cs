using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class MultipleChoiceQuestion : AbstractQuestion
    {
        protected List<string> sChoices;

        public MultipleChoiceQuestion(string quest, string answer, List<string> choices)
            : base(quest, answer)
        {
            sChoices = choices;
        }

        override protected void displayChoices()
        {
            for (int i = 0; i < sChoices.Count; i++)
            {
                int count = i + 1;

                Console.WriteLine(count + ": " + sChoices[i]);
            }

            Console.WriteLine("Answer by typing 1, 2, 3, or 4.");
            Console.WriteLine("Answer: " + sAnswer);

        }

    }
}
