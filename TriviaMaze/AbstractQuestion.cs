//Daniel Heffley
//Sam Gronhovd
//Kevin Reynolds
//Triva Maze / Final Project
//Last Modified: 12/9/12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace TriviaMaze
{
    [Serializable()]
    public abstract class AbstractQuestion : ISerializable
    {
        protected string _sQuest;
        protected string _sAnswer;
        //protected List<String> sChoices;


        public AbstractQuestion(string other_quest, string other_answer)
        {
            _sQuest = other_quest;
            _sAnswer = other_answer;
        }

#region Accessors / Mutators
        public string Question 
        { 
            get { return this._sQuest; } 
        }

        public string Answer 
        { 
            get { return this._sAnswer; } 
        }
#endregion

#region Main Behaviors
        public bool knock()
        {
            askQuestion();
            displayChoices();
            return readInAnswer();
        }

        protected void askQuestion()
        {
            Console.WriteLine(_sQuest);
        }

        abstract protected void displayChoices();

        protected Boolean readInAnswer()
        {
            bool cheating = true;
            string ans = "";

            while (cheating)
            {
                ans = Console.ReadLine();

                if (ans.Equals("cheat"))
                    Console.WriteLine("Answer: " + _sAnswer);
                else
                    cheating = false;
            }
            return checkAnswer(ans);
        }

        protected Boolean checkAnswer(string other_ans)
        {
            if (other_ans.ToLower().Equals(_sAnswer.ToLower()))
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

        public AbstractQuestion(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            this._sQuest = (string)other_info.GetValue("sQuest", typeof(string));
            this._sAnswer = (string)other_info.GetValue("sAnswer", typeof(string));
            
        }

        abstract public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt);
#endregion

    }
}
