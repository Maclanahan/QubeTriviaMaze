using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class QuestionTool
    {

        public QuestionTool()
        {
            manageQuestions();
        }

        private void manageQuestions()
        {
            bool repeat = true;
            MultipleChoiceManager mcm;
            TrueFalseManager tfm;
            ShortAnswerManager sam;

            while (repeat)
            {
                Console.WriteLine("Which would you like to manage?\n" + 
                                    "1: Multiple Choice\n" +
                                    "2: True/False\n" +
                                    "3: Short Answer\n" +
                                    "4: Exit\n");

                string input = Console.ReadLine();

                if (input.Equals("1"))
                    mcm = new MultipleChoiceManager();
                else if (input.Equals("2"))
                    tfm = new TrueFalseManager();
                else if (input.Equals("3"))
                    sam = new ShortAnswerManager();
                else if (input.Equals("4"))
                    repeat = false;
                else
                    Console.WriteLine("Input was invalid.");
            }

        }

        

        private void manageTrueFalse()
        {

        }

        private void manageShortAnswer()
        {

        }
    }
}
