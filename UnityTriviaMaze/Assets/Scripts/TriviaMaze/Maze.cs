using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;

namespace TriviaMaze
{
    [Serializable()]
    public class Maze : ISerializable
    {
        private Room[,] rooms;
        private Door[,] xDoors;
        private Door[,] yDoors;

        private Room finalRoom;


        public Maze(Room[,] _rooms, Door[,] _xDoors, Door[,] _yDoors, int size)
        {
            rooms = _rooms;
            xDoors = _xDoors;
            yDoors = _yDoors;

            finalRoom = new Room(size, size, size, size);
        }

        public Room Move(Room currentPos, int xDir, int yDir)
        {
            if (xDir != 0)
            {
                if (xDir == -1 && xDoors[currentPos.getXpos() + xDir, currentPos.getYpos()].isDoorOpen())
                    return rooms[currentPos.getXpos() + xDir, currentPos.getYpos()];

                if(xDir == 1 && xDoors[currentPos.getXpos(), currentPos.getYpos()].isDoorOpen())
                    return rooms[currentPos.getXpos() + xDir, currentPos.getYpos()];
            }

            else if (yDir != 0)
            {
                if (yDir == -1 && yDoors[currentPos.getXpos(), currentPos.getYpos() + yDir].isDoorOpen())
                    return rooms[currentPos.getXpos(), currentPos.getYpos() + yDir];
                
                if (yDir == 1 && yDoors[currentPos.getXpos(), currentPos.getYpos()].isDoorOpen())
                    return rooms[currentPos.getXpos(), currentPos.getYpos() + yDir];
            }


            return currentPos;
        }

        public bool isFinalRoom(int x, int y)
        {
            return rooms[x, y].isEndRoom();
        }

        public Room getCurrentRoom(int x, int y)
        {
            return rooms[x, y];
        }

        public void setCurrentRoom(Room cur)
        {
            
        }


        public void PrintMaze(Room playerRoom)
        {
            for (int i = 0; i < rooms.GetLength(0); i++)
            {
                for (int j = 0; j < rooms.GetLength(1); j++)
                {
                    Console.Write("[" + checkIfPlayerRoom(playerRoom, rooms[j,i]) + "]");

                    Console.Write(checkDoorState(j, i, xDoors));
                }
                Console.Write("\n");

                for (int j = 0; j < rooms.GetLength(1); j++)
                {
                    Console.Write(" " + checkDoorState(j, i, yDoors) + "  ");
                }
                Console.Write("\n");
            }
        }

        private string checkDoorState(int x, int y, Door[,] doors)
        {
            if(x < doors.GetLength(0) && y < doors.GetLength(1))
            //if(xDoors[x, y] != null)
                return doors[x, y].getState();

            return "";
        }

        private string checkIfPlayerRoom(Room playerRoom, Room cur)
        {
            //Console.WriteLine(playerRoom.getXpos() + " " cur.getXpos() + " " + playerRoom.getYpos() + " " + playerRoom.getYpos());

            if (playerRoom.getXpos() == cur.getXpos() && playerRoom.getYpos() == cur.getYpos())
                return "P";

            return " ";
        }

        public Maze(SerializationInfo info, StreamingContext ctxt)
        {
            this.rooms = (Room[,])info.GetValue("rooms", typeof(Room[,]));
            this.xDoors = (Door[,])info.GetValue("xDoors", typeof(Door[,]));
            this.yDoors = (Door[,])info.GetValue("yDoors", typeof(Door[,]));
            this.finalRoom = (Room)info.GetValue("finalRoom", typeof(Room));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("rooms", this.rooms);
            info.AddValue("xDoors", this.xDoors);
            info.AddValue("yDoors", this.yDoors);
            info.AddValue("finalRoom", this.finalRoom);
        }
    }
}
