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
    public class DoorFactory
    {
        protected List<AbstractQuestion> _questions;

        public DoorFactory(List<AbstractQuestion> other_quest)
        {
            if (other_quest == null)
                throw new NullReferenceException();

            _questions = other_quest;
        }

#region Main Behaviors
        public Door[,] makeHDoors(int other_size)
        {
            if (other_size <= 0)
                throw new ArgumentOutOfRangeException();

            Door[,] hDoors = new Door[other_size - 1, other_size];
            for (int i = 0; i < other_size - 1; i++)
            {
                for (int j = 0; j < other_size; j++)
                {
                    hDoors[i, j] = new Door(_questions[0]);       //q is question
                    _questions.RemoveAt(0);
                }//end inner loop
            }//end outer loop
            return hDoors;
        }

        public Door[,] makeVDoors(int other_size)
        {
            if (other_size <= 0)
                throw new ArgumentOutOfRangeException();

            Door[,] vDoors = new Door[other_size, other_size - 1];
            for (int i = 0; i < other_size; i++)
            {
                for (int j = 0; j < other_size - 1; j++)
                {
                    vDoors[i, j] = new Door(_questions[0]);
                    _questions.RemoveAt(0);//q is question
                }//end inner loop
            }//end outer loop
            return vDoors;
        }
#endregion

#region Accessors/Mutators
        public List<AbstractQuestion> Questions 
        { 
            get { return this._questions; } 
        }
#endregion

    }
}
