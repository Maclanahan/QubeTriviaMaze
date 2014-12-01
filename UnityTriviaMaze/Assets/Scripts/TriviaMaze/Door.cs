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

        public Door(AbstractQuestion question)
        {
            _state = 1;
            _question = question;
        }

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

        public Door(SerializationInfo info, StreamingContext ctxt)
        {
            this._state = (int)info.GetValue("state", typeof(int));
            this._question = (AbstractQuestion)info.GetValue("question", typeof(AbstractQuestion));
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("state", this._state);
            info.AddValue("question", this._question);
        }
    }
}