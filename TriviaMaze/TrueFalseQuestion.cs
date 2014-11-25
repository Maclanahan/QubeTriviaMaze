using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TriviaMaze
{
    [Serializable()]
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
            Console.WriteLine("Answer: " + sAnswer);
        }

        public TrueFalseQuestion(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
            
        }

        override public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("sQuest", this.sQuest);
            info.AddValue("sAnswer", this.sAnswer);
        }
    }
}
