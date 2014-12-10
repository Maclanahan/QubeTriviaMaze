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

        public int getXpos() { return _xpos; }
        public int getYpos() { return _ypos; }

        public Room(int xpos, int ypos, int endxpos, int endypos)
        {
            if (xpos < 0 || ypos < 0 ||
                endxpos < 0 || endypos < 0)
                throw new ArgumentOutOfRangeException();

            _xpos = xpos;
            _ypos = ypos;

            if (_xpos == endxpos && _ypos == endypos)
                _endRoom = true;
        }

        public bool isEndRoom()
        {
            return _endRoom;
        }

        public Room(SerializationInfo info, StreamingContext ctxt)
        {
            this._xpos = (int)info.GetValue("xpos", typeof(int));
            this._ypos = (int)info.GetValue("ypos", typeof(int));
            this._endRoom = (bool)info.GetValue("endRoom", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("xpos", this._xpos);
            info.AddValue("ypos", this._ypos);
            info.AddValue("endRoom", this._endRoom);
        }
    }
}