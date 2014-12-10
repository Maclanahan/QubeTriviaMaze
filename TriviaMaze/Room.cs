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
    public class Room : ISerializable
    {
        private int _xpos;
        private int _ypos;
        private bool _endRoom = false;

        public Room(int other_xpos, int other_ypos, int other_endxpos, int other_endypos)
        {
            if (other_xpos < 0 || other_ypos < 0 ||
                other_endxpos < 0 || other_endypos < 0)
                throw new ArgumentOutOfRangeException();

            _xpos = other_xpos;
            _ypos = other_ypos;

            if (_xpos == other_endxpos && _ypos == other_endypos)
                _endRoom = true;
        }

#region Accessors / Mutators
        public int getXpos() 
        { 
            return _xpos; 
        }

        public int getYpos() 
        { 
            return _ypos; 
        }
#endregion

        public bool isEndRoom()
        {
            return _endRoom;
        }

#region Serializable
        public Room(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            this._xpos = (int)other_info.GetValue("xpos", typeof(int));
            this._ypos = (int)other_info.GetValue("ypos", typeof(int));
            this._endRoom = (bool)other_info.GetValue("endRoom", typeof(bool));
        }

        public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            other_info.AddValue("xpos", this._xpos);
            other_info.AddValue("ypos", this._ypos);
            other_info.AddValue("endRoom", this._endRoom);
        }
#endregion

    }
}