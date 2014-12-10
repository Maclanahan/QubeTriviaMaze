﻿//Daniel Heffley
//Sam Gronhovd
//Kevin Reynolds
//Triva Maze / Final Project
//Last Modified: 12/9/12

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
            QuestionManager qm;

            while (repeat)
            {
                Console.WriteLine("Which would you like to manage?\n" + 
                                    "1: Multiple Choice\n" +
                                    "2: True/False\n" +
                                    "3: Short Answer\n" +
                                    "4: Exit");

                string input = Console.ReadLine();

                if (input.Equals("1"))
                {
                    qm = new QuestionManager("MCQuestions");
                    qm.manage();
                }
                else if (input.Equals("2"))
                {
                    qm = new QuestionManager("TFQuestions");
                    qm.manage();
                }
                else if (input.Equals("3"))
                {
                    qm = new QuestionManager("SAQuestions");
                    qm.manage();
                }
                else if (input.Equals("4"))
                    repeat = false;
                else
                    Console.WriteLine("Input was invalid.");
            }
        }
    }
}
