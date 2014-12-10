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
    public class SaveData :ISerializable
    {
        private Maze _maze;
        private Room _position;
        int _size;


        public SaveData(Maze other_maze, Room other_position, int other_size)
        {
            if (other_maze == null || other_position == null || other_size <= 0)
                throw new NullReferenceException();

            _maze = other_maze;
            _position = other_position;
            _size = other_size;
        }

#region Accessors / Mutators
        public Maze getMaze()
        {
            return _maze;
        }

        public Room getPosition()
        {
            return _position;
        }

        public int getSize()
        {
            return _size;
        }

#endregion

#region Serializable
        public SaveData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            this._maze = (Maze)other_info.GetValue("Maze", typeof(Maze));
            this._position = (Room)other_info.GetValue("position", typeof(Room));
            this._size = (int)other_info.GetValue("size", typeof(int));
        }

        public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            other_info.AddValue("Maze", _maze);
            other_info.AddValue("position", _position);
            other_info.AddValue("size", _size);
        }
#endregion

    }
}
