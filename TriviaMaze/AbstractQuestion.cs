using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TriviaMaze
{
    abstract class AbstractQuestion
    {
        protected string sQuest;
        protected string sAnswer;
        //protected List<String> sChoices;


        public AbstractQuestion(string quest, string answer)
        {
            sQuest = quest;
            sAnswer = answer;
            //sChoices = choices;

        }

        public bool knock()
        {
            askQuestion();
            displayChoices();
            return readInAnswer();
        }

        protected void askQuestion()
        {
            Console.WriteLine(sQuest);
        }

        abstract protected void displayChoices();

        protected Boolean readInAnswer()
        {
            string ans = Console.ReadLine();

            return checkAnswer(ans);
        }

        protected Boolean checkAnswer(string ans)
        {
            if (ans.ToLower().Equals(sAnswer.ToLower()))
            {
                Console.WriteLine("CORRECT!");
                return true;
            }

            Console.WriteLine("wrong");
            return false;
        }

        public void toString()
        {
            askQuestion();

            displayChoices();

        }

    }
}
