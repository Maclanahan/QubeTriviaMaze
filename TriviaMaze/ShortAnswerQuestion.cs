using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TriviaMaze
{
    [Serializable()]
    class ShortAnswerQuestion :AbstractQuestion
    {
        public ShortAnswerQuestion(string quest, string answer)
            : base(quest, answer)
        { }

        override protected void displayChoices()
        {
            Console.WriteLine("Please Type in your 1 word answer.");
        }

        public ShortAnswerQuestion(SerializationInfo info, StreamingContext ctxt)
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
