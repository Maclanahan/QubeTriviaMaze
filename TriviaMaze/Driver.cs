using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaMaze
{
    class Driver
    {
        private int _xpos;
        private int _ypos;
        private int _endXPos;
        private int _endYPos;
        private int _size;

        private Room currentRoom;

        public Driver(int xpos, int ypos, int endXPos, int endYPos, int size)
        {
            _xpos = xpos;
            _ypos = ypos;
            _endXPos = endXPos;
            _endYPos = endYPos;
            _size = size;
        }

        public void enterMaze(Maze maze)
        {
            int n;

            currentRoom = maze.getCurrentRoom(_xpos, _ypos);

            while(!maze.isFinalRoom(currentRoom.getXpos(), currentRoom.getYpos() ) )
            {
                maze.PrintMaze(currentRoom);
                Console.WriteLine("You are in room: x-" + currentRoom.getXpos() + " y-" + currentRoom.getYpos() + 
                    "\nWhere would you like to go?" +
                    "\nThe end is at x-" + _endXPos + " y-" + _endYPos + 
                    "\nEnter 1(Up), 2(Right), 3(Down), 4(Left), 0(Save)");

                string input = Console.ReadLine();

                if(input != "")
                {
                    n = int.Parse(input);

                    if (n == 1 && currentRoom.getYpos() != 0)
                        this.moveUp(maze);
                    else if (n == 2 && currentRoom.getXpos() != _size - 1)
                        this.moveRight(maze);
                    else if (n == 3 && currentRoom.getYpos() != _size - 1)
                        this.moveDown(maze);
                    else if (n == 4 && currentRoom.getXpos() != 0)
                        this.moveLeft(maze);
                    else if (n == 0)
                        saveGame(maze);
                    else
                        Console.WriteLine("Input was not valid.");
                }   

            }

            Console.WriteLine("You won!");
        }

        public void setCurrentRoom(Room current)
        {
            currentRoom = current;
        }

        private void moveUp(Maze maze)
        {
            _ypos -= 1;
            currentRoom = maze.Move(currentRoom, 0, -1);
        }

        private void moveRight(Maze maze)
        {
            _xpos += 1;
            currentRoom = maze.Move(currentRoom, 1, 0);
        }

        private void moveDown(Maze maze)
        {
            _ypos += 1;
            currentRoom = maze.Move(currentRoom, 0, 1);
        }

        private void moveLeft(Maze maze)
        {
            _xpos -= 1;
            currentRoom = maze.Move(currentRoom, -1, 0);
        }

        private void saveGame(Maze maze)
        {
            SaveData save = new SaveData(maze, currentRoom);

            Serializer serializer = new Serializer();
            serializer.Serialize("output.txt", save);
        }
    }
}
