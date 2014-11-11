using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class MazeFactory
    {
        public MazeFactory()
        {
            
        }

        public Room[,] makeMaze(int size)
        {
            Room[,] maze = new Room[size,size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    maze[i, j] = new Room(i, j, size-1, size-1);
                }
            }//end outer loop
            return maze;
        }
    }
}
