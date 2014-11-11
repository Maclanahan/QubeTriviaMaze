using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class Room
    {
        private int _xpos;
        private int _ypos;
        private bool _endRoom = false;

        public Room(int xpos, int ypos, int endxpos, int endypos)
        {
            _xpos = xpos;
            _ypos = ypos;

            if (_xpos == endxpos && _ypos == endypos)
                _endRoom = true;
        }

        public bool isEndRoom()
        {
            return _endRoom;
        }
    }
}