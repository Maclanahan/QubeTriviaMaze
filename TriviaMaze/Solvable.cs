using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class Solvable
    {
        Maze maze;

        bool [,] mazeCheck;

        Room tracker;

        public Solvable(int _size)
        {
            //maze = _maze;

            mazeCheck = new bool[_size, _size];

            resetMazeCheck();
        }

        private void resetMazeCheck()
        {
            for(int i = 0; i < mazeCheck.GetLength(0); i++)
                for (int j = 0; j < mazeCheck.GetLength(1); j++)
                {
                    mazeCheck[i,j] = false;
                }
        }

        public bool checkIfMazeIsSolvable(Maze _maze, Room currentRoom)
        {
            maze = _maze;

            resetMazeCheck();

            return checkIfMazeIsSolvableRec(currentRoom);
        }

        public bool checkIfMazeIsSolvableRec(Room currentRoom)
        {
            tracker = currentRoom;

            int xPos = tracker.getXpos();
            int yPos = tracker.getYpos();

            mazeCheck[xPos, yPos] = true;

            printMazeCheck();

            if (tracker.isEndRoom())
                return true;
            //down
            if (canGo(xPos + 0, yPos + 1, false))
            {
                //tracker = maze.getCurrentRoom(xPos + 0, yPos + 1);
                if (checkIfMazeIsSolvableRec(maze.getCurrentRoom(xPos + 0, yPos + 1)))
                    return true;
            }
            //right
            if (canGo(xPos + 1, yPos + 0, true))
            {
                //tracker = maze.getCurrentRoom(xPos + 1, yPos + 0);
                if (checkIfMazeIsSolvableRec(maze.getCurrentRoom(xPos + 1, yPos + 0)))
                    return true;    
            }
            //up
            if (canGo(xPos + 0, yPos - 1, false))
            {
                //tracker = maze.getCurrentRoom(xPos + 0, yPos - 1);
                if (checkIfMazeIsSolvableRec(maze.getCurrentRoom(xPos + 0, yPos - 1)))
                    return true;
            }

            //left
            if (canGo(xPos - 1, yPos + 0, true))
            {
                //tracker = maze.getCurrentRoom(xPos - 1, yPos + 0);
                if (checkIfMazeIsSolvableRec(maze.getCurrentRoom(xPos - 1, yPos + 0)))
                    return true;
            }

            return false;
        }

        private bool canGo(int x, int y, bool moveHorizontal)
        {
            if (x >= mazeCheck.GetLength(0) || y >= mazeCheck.GetLength(1) || x < 0 || y < 0)
                return false;

            //Console.WriteLine(x + " " + mazeCheck.GetLength(0));
            //Console.WriteLine(y + " " + mazeCheck.GetLength(1));

            if (mazeCheck[x, y] == true)
                return false;

            if (moveHorizontal && x > 0)
                if (maze.isHDoorLocked(x - 1, y))
                    return false;

            if(!moveHorizontal && y > 0)
                if (maze.isVDoorLocked(x, y - 1))
                     return false;

            return true;
        }

        private void printMazeCheck()
        {
            for (int i = 0; i < mazeCheck.GetLength(0); i++)
            {
                for (int j = 0; j < mazeCheck.GetLength(1); j++)
                {
                    if(mazeCheck[j,i] == true)
                        Console.Write("1 ");
                    else
                        Console.Write("0 ");   

                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

    }
}
