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
    public class ShortAnswerQuestion :AbstractQuestion
    {
        public ShortAnswerQuestion(string other_quest, string other_answer)
            : base(other_quest, other_answer)
        { }

        override protected void displayChoices()
        {
            Console.WriteLine("Please Type in your 1 word answer.");
        }

#region Serializable
        public ShortAnswerQuestion(SerializationInfo other_info, StreamingContext other_ctxt)
            : base(other_info, other_ctxt)
        {
            
        }

        override public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            other_info.AddValue("sQuest", this._sQuest);
            other_info.AddValue("sAnswer", this._sAnswer);
        }
#endregion

    }
}
