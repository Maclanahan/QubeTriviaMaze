//Daniel Heffley
//Sam Gronhovd
//Kevin Reynolds
//Triva Maze / Final Project
//Last Modified: 12/9/12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    public class MazeFactory
    {
        public MazeFactory(){ }

        public Maze makeMaze(int other_size, Door[,] other_xDoors, Door[,] other_yDoors)
        {
            if (other_xDoors == null || other_yDoors == null || other_size <= 0)
                throw new Exception();

            Room[,] rooms = new Room[other_size, other_size];
            
            for (int i = 0; i < other_size; i++)
            {
                for (int j = 0; j < other_size; j++)
                {
                    rooms[i, j] = new Room(i, j, other_size - 1, other_size - 1);
                }//end inner loop
            }//end outer loop

            Maze maze = new Maze(rooms, other_xDoors, other_yDoors, other_size);

            return maze;
        }
    }
}
