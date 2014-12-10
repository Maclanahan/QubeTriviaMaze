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
    public class Maze : ISerializable
    {
        private Room[,] _rooms;
        private Door[,] _xDoors;
        private Door[,] _yDoors;
        private int _size;

        private Room finalRoom;

        public Maze(Room[,] other_rooms, Door[,] other_xDoors, Door[,] other_yDoors, int other_size)
        {
            if (other_rooms == null || other_xDoors == null || other_yDoors == null || other_size <= 0)
                throw new NullReferenceException();

            _rooms = other_rooms;
            _xDoors = other_xDoors;
            _yDoors = other_yDoors;

            finalRoom = new Room(other_size, other_size, other_size, other_size);
        }

#region Accesors/Mutators
        public Door[,] getDoors(string other_doors)
        {
            if (other_doors.Equals("x"))
                return _xDoors;

            return _yDoors;
        }

        public Room getCurrentRoom(int other_x, int other_y)
        {
            return _rooms[other_x, other_y];
        }

        internal int getSize()
        {
            return _size;
        }
#endregion

#region Main Behaviors
        public Room Move(Room currentPos, int other_xDir, int other_yDir)
        {
            if (other_xDir != 0)
            {
                if (other_xDir == -1 && _xDoors[currentPos.getXpos() + other_xDir, currentPos.getYpos()].isDoorOpen())
                    return _rooms[currentPos.getXpos() + other_xDir, currentPos.getYpos()];

                if (other_xDir == 1 && _xDoors[currentPos.getXpos(), currentPos.getYpos()].isDoorOpen())
                    return _rooms[currentPos.getXpos() + other_xDir, currentPos.getYpos()];
            }

            else if (other_yDir != 0)
            {
                if (other_yDir == -1 && _yDoors[currentPos.getXpos(), currentPos.getYpos() + other_yDir].isDoorOpen())
                    return _rooms[currentPos.getXpos(), currentPos.getYpos() + other_yDir];

                if (other_yDir == 1 && _yDoors[currentPos.getXpos(), currentPos.getYpos()].isDoorOpen())
                    return _rooms[currentPos.getXpos(), currentPos.getYpos() + other_yDir];
            }


            return currentPos;
        }

        public void PrintMaze(Room other_playerRoom)
        {
            for (int i = 0; i < _rooms.GetLength(0); i++)
            {
                for (int j = 0; j < _rooms.GetLength(1); j++)
                {
                    Console.Write("[" + checkRoom(other_playerRoom, _rooms[j, i]) + "]");

                    Console.Write(checkDoorState(j, i, _xDoors));
                }//end for loop
                Console.Write("\n");

                for (int j = 0; j < _rooms.GetLength(1); j++)
                {
                    Console.Write(" " + checkDoorState(j, i, _yDoors) + "  ");
                }//end for loop
                Console.Write("\n");
            }
        }
#endregion

#region checkingMethods
        public bool isFinalRoom(int other_x, int other_y)
        {
            return _rooms[other_x, other_y].isEndRoom();
        }

        private string checkDoorState(int other_x, int other_y, Door[,] other_doors)
        {
            if (other_x < other_doors.GetLength(0) && other_y < other_doors.GetLength(1))
            //if(_xDoors[x, y] != null)
                return other_doors[other_x, other_y].getState();

            return "";
        }


        private string checkRoom(Room other_playerRoom, Room other_cur)
        {
            //Console.WriteLine(playerRoom.getXpos() + " " cur.getXpos() + " " + playerRoom.getYpos() + " " + playerRoom.getYpos());

            if (other_playerRoom.getXpos() == other_cur.getXpos() && other_playerRoom.getYpos() == other_cur.getYpos())
                return "P";
            else if (finalRoom.getXpos() - 1 == other_cur.getXpos() && finalRoom.getYpos() - 1 == other_cur.getYpos())
                return "G";

            return " ";
        }

        public bool isHDoorLocked(int other_x, int other_y)
        {
            return _xDoors[other_x, other_y].isDoorLocked();
        }

        public bool isVDoorLocked(int other_x, int other_y)
        {
            return _yDoors[other_x, other_y].isDoorLocked();
        }
#endregion

#region Serializable
        public Maze(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            this._rooms = (Room[,])other_info.GetValue("_rooms", typeof(Room[,]));
            this._xDoors = (Door[,])other_info.GetValue("_xDoors", typeof(Door[,]));
            this._yDoors = (Door[,])other_info.GetValue("_yDoors", typeof(Door[,]));
            this.finalRoom = (Room)other_info.GetValue("finalRoom", typeof(Room));
            this._size = (int)other_info.GetValue("_size", typeof(int));
        }

        public void GetObjectData(SerializationInfo other_info, StreamingContext other_ctxt)
        {
            other_info.AddValue("_rooms", this._rooms);
            other_info.AddValue("_xDoors", this._xDoors);
            other_info.AddValue("_yDoors", this._yDoors);
            other_info.AddValue("finalRoom", this.finalRoom);
            other_info.AddValue("_size", this._size);
        }
#endregion

    }
}
