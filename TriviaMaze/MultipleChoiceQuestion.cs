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
    public class MultipleChoiceQuestion : AbstractQuestion
    {
        protected List<string> _sChoices;

#region Class Code
        public MultipleChoiceQuestion(string other_quest, string other_answer, List<string> other_choices)
            : base(other_quest, other_answer)
        {
            if (other_quest == null || other_answer == null || other_choices == null)
                throw new NullReferenceException();

            _sChoices = other_choices;
        }

        override protected void displayChoices()
        {
            for (int i = 0; i < _sChoices.Count; i++)
            {
                int count = i + 1;

                Console.WriteLine(count + ": " + _sChoices[i]);
            }//end for loop

            Console.WriteLine("Answer by typing 1, 2, 3, or 4.");
        }
#endregion

#region Serializable
        public MultipleChoiceQuestion(SerializationInfo other_info, StreamingContext other_ctxt)
            : base(other_info, other_ctxt)
        {
            this._sChoices = (List<string>)other_info.GetValue("_sChoices", typeof(List<string>));
        }

        override public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            other_info.AddValue("_sChoices", _sChoices);
            other_info.AddValue("sQuest", _sQuest);
            other_info.AddValue("sAnswer", _sAnswer);
        }
#endregion
    }
}
