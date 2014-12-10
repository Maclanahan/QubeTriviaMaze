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
    class Solvable
    {
        protected Maze _maze;

        protected bool [,] _mazeCheck;

        protected Room _tracker;

        public Solvable(int other_size)
        {
            _mazeCheck = new bool[other_size, other_size];

            resetMazeCheck();
        }

#region Main Behaviors
        private void resetMazeCheck()
        {
            for(int i = 0; i < _mazeCheck.GetLength(0); i++)
                for (int j = 0; j < _mazeCheck.GetLength(1); j++)
                {
                    _mazeCheck[i,j] = false;
                }//end for loop
        }

        public bool checkIfMazeIsSolvable(Maze other_maze, Room other_currentRoom)
        {
            _maze = other_maze;

            resetMazeCheck();

            return checkIfMazeIsSolvableRec(other_currentRoom);
        }

        public bool checkIfMazeIsSolvableRec(Room other_currentRoom)
        {
            _tracker = other_currentRoom;

            int xPos = _tracker.getXpos();
            int yPos = _tracker.getYpos();

            _mazeCheck[xPos, yPos] = true;

            //printMazeCheck();

            if (_tracker.isEndRoom())
                return true;

            //down
            if (canGo(xPos + 0, yPos + 1, false, false, false))
            {
                //tracker = maze.getCurrentRoom(xPos + 0, yPos + 1);
                if (checkIfMazeIsSolvableRec(_maze.getCurrentRoom(xPos + 0, yPos + 1)))
                    return true;
            }

            //right
            if (canGo(xPos + 1, yPos + 0, true, false, false))
            {
                //tracker = maze.getCurrentRoom(xPos + 1, yPos + 0);
                if (checkIfMazeIsSolvableRec(_maze.getCurrentRoom(xPos + 1, yPos + 0)))
                    return true;    
            }

            //up
            if (canGo(xPos + 0, yPos - 1, false, false, true))
            {
                //tracker = maze.getCurrentRoom(xPos + 0, yPos - 1);
                if (checkIfMazeIsSolvableRec(_maze.getCurrentRoom(xPos + 0, yPos - 1)))
                    return true;
            }

            //left
            if (canGo(xPos - 1, yPos + 0, true, true, false))
            {
                //tracker = maze.getCurrentRoom(xPos - 1, yPos + 0);
                if (checkIfMazeIsSolvableRec(_maze.getCurrentRoom(xPos - 1, yPos + 0)))
                    return true;
            }

            return false;
        }

        private bool canGo(int other_x, int other_y, bool other_moveHorizontal, bool other_moveLeft, bool other_moveUp)
        {
            if (other_x >= _mazeCheck.GetLength(0) || other_y >= _mazeCheck.GetLength(1) || other_x < 0 || other_y < 0)
                return false;

            if (_mazeCheck[other_x, other_y] == true)
                return false;

            if (other_moveHorizontal && other_x > 0)
            {
                if (!other_moveLeft)
                    if (_maze.isHDoorLocked(other_x - 1, other_y))
                    {
                        return false;
                    }

                if (other_moveLeft)
                    if (_maze.isHDoorLocked(other_x, other_y))
                    {
                        return false;
                    }
            }

            if (!other_moveHorizontal && other_y > 0)
            {
                if (!other_moveUp)
                    if (_maze.isVDoorLocked(other_x, other_y - 1))
                    {
                        return false;
                    }

                if (other_moveUp)
                    if (_maze.isVDoorLocked(other_x, other_y))
                    {
                        return false;
                    }
            }

            return true;
        }
#endregion

#region Printing
        private void printMazeCheck()
        {
            for (int i = 0; i < _mazeCheck.GetLength(0); i++)
            {
                for (int j = 0; j < _mazeCheck.GetLength(1); j++)
                {
                    if(_mazeCheck[j,i] == true)
                        Console.Write("1 ");
                    else
                        Console.Write("0 ");   

                }//end for loop

                Console.WriteLine();
            }//end for loop

            Console.WriteLine();
        }
#endregion

    }
}
