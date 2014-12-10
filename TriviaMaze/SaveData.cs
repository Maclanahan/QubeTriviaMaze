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
        private Maze maze;
        private Room position;


        public SaveData(Maze _maze, Room _position)
        {
            if (_maze == null || _position == null)
                throw new NullReferenceException();

            maze = _maze;
            position = _position;
        }

        public Maze getMaze()
        {
            return maze;
        }

        public Room getPosition()
        {
            return position;
        }

        public SaveData(SerializationInfo info, StreamingContext ctxt)
        {
            this.maze = (Maze)info.GetValue("Maze", typeof(Maze));
            this.position = (Room)info.GetValue("position", typeof(Room));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Maze", this.maze);
            info.AddValue("position", this.position);
        }
    }
}
