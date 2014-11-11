using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class DoorFactory
    {
        

        public DoorFactory()
        {
            
        }

        public Door[,] makeHDoors(int size)
        {
            Door[,] hDoors = new Door[size - 1, size - 1];
            for (int i = 0; i < size - 1; i ++)
            {
                for(int j = 0; j < size - 1; j++)
                {
                    //hDoors[i, j] = new Door(q);       //q is question
                }
            }//end outer loop
            return hDoors;
        }

        public Door[,] makeVDoors(int size)
        {
            Door[,] vDoors = new Door[size - 1, size - 1];
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    //hDoors[i, j] = new Door(q);       //q is question
                }
            }//end outer loop
            return vDoors;
        }
    }
}
