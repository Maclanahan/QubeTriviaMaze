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
    public class TrueFalseQuestion :AbstractQuestion
    {
        public TrueFalseQuestion(string other_quest, string other_answer)
            : base(other_quest, other_answer)
        { 
        
        }

        override protected void displayChoices()
        {
            Console.WriteLine("1: T");
            Console.WriteLine("2: F");

            Console.WriteLine("Answer by typing 1 or 2.");
        }

#region Serializable
        public TrueFalseQuestion(SerializationInfo other_info, StreamingContext other_ctxt)
            : base(other_info, other_ctxt)
        {
            
        }

        override public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            other_info.AddValue("sQuest", _sQuest);
            other_info.AddValue("sAnswer", _sAnswer);
        }
#endregion

    }
}
