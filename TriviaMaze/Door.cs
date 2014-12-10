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
    public class Door : ISerializable
    {
        private int _state; // 0 = open, 1 = closed, 2 = locked
        private AbstractQuestion _question;

        public Door(AbstractQuestion other_question)
        {
            if (other_question == null)
                throw new NullReferenceException();

            _state = 1;
            _question = other_question;
        }

#region Accessors / Mutators
        public int State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }

        public string getState()
        {
            if (_state == 0)
                return "=";
            if (_state == 1)
                return "/";
            if (_state == 2)
                return "x";

            return " ";
        }
#endregion

#region Check Methods
        public bool isDoorOpen()
        {
            // return false if locked
            if (_state == 2)
                return false;

            // return true if open
            if (_state == 0)
                return true;

            if (_question.knock())
            {
                _state = 0;
                return true;
            }
            else
            {
                _state = 2;
                return false;
            }

            //return isDoorOpen(); //return true if answered correctly
        }

        public bool isDoorLocked()
        {
            if (_state == 2)
                return true;

            return false;
        }
#endregion

#region Serializable
        public Door(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            this._state = (int)other_info.GetValue("state", typeof(int));
            this._question = (AbstractQuestion)other_info.GetValue("question", typeof(AbstractQuestion));
            
        }

        public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            other_info.AddValue("state", this._state);
            other_info.AddValue("question", this._question);
        }
#endregion

    }
}