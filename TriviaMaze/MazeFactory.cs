using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class MazeFactory
    {
        public MazeFactory(){ }

        public Maze makeMaze(int size, Door[,] xDoors, Door[,]yDoors)
        {
            

            Room[,] rooms = new Room[size,size];
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
