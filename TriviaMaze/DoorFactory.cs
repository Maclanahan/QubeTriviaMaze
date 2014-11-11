using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class DoorFactory
    {
        List<AbstractQuestion> questions;

        public DoorFactory(List<AbstractQuestion> quest)
        {
            questions = quest;
        }

        public Door[,] makeHDoors(int size)
        {
            Door[,] hDoors = new Door[size - 1, size ];
            for (int i = 0; i < size - 1; i ++)
            {
                for(int j = 0; j < size; j++)
                {
                    hDoors[i, j] = new Door(questions[0]);       //q is question
                    questions.RemoveAt(0);
                }
            }//end outer loop
            return hDoors;
        }

        public Door[,] makeVDoors(int size)
        {
            Door[,] vDoors = new Door[size, size - 1];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    vDoors[i, j] = new Door(questions[0]);
                    questions.RemoveAt(0);//q is question
                }
            }//end outer loop
            return vDoors;
        }
    }
}
