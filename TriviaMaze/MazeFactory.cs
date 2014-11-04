using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class MazeFacotry
    {
        public MazeFacotry()
        {

        }

        public Room[,] makeMaze(int size)
        {
            Room[,] maze = new Room[size,size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    maze[i, j] = new Room(i, j);
                }
            }//end outer loop
            return maze;
        }
    }
}
