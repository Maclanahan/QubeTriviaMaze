﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TriviaMaze
{
    [Serializable()]
    public class MultipleChoiceQuestion : AbstractQuestion
    {
        protected List<string> sChoices;

        public MultipleChoiceQuestion(string quest, string answer, List<string> choices)
            : base(quest, answer)
        {
            if (quest == null || answer == null || choices == null)
                throw new NullReferenceException();

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

        }

        public MultipleChoiceQuestion(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
            this.sChoices = (List<string>)info.GetValue("sChoices", typeof(List<string>));
        }

        override public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("sChoices", this.sChoices);
            //base.GetObjectData(info, ctxt);
            info.AddValue("sQuest", this.sQuest);
            info.AddValue("sAnswer", this.sAnswer);
        }

    }
}
