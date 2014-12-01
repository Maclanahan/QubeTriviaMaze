using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace TriviaMaze
{
    class MazeFactory : MonoBehaviour
    {
        protected Transform prefabFloor;

        public MazeFactory(Transform _prefabFloor)
        {
            prefabFloor = _prefabFloor;
        }

        public Maze makeMaze(int size, Door[,] xDoors, Door[,]yDoors)
        {
            

            Room[,] rooms = new Room[size,size];
            Transform[,] rooms3D = new Transform[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    rooms[i, j] = new Room(i, j, size-1, size-1);

                }
            }//end outer loop

            Maze maze = new Maze(rooms, xDoors, yDoors, size);

            return maze;
        }
    }
}
