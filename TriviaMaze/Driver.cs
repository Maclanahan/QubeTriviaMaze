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
            currentRoom = new Room(0, 0, endXPos, endYPos);
        }

        public void enterMaze(Maze maze)
        {   
            bool play = true;
            _xpos = currentRoom.getXpos();
            _ypos = currentRoom.getYpos();

            currentRoom = maze.getCurrentRoom(_xpos, _ypos);

            while(!maze.isFinalRoom(currentRoom.getXpos(), currentRoom.getYpos() ) && play )
            {
                maze.PrintMaze(currentRoom);
                Console.WriteLine("Where would you like to go?\n" +
                    "Enter 1(Up), 2(Right), 3(Down), 4(Left), 9(Quit), 0(Save)");

                play = playerAct(maze);
            }

            if (currentRoom.getXpos() == _endXPos && currentRoom.getYpos() == _endYPos)
                Console.WriteLine("You won!");

        }

        public void setCurrentRoom(Room current)
        {
            currentRoom = current;
        }

        private bool playerAct(Maze maze)
        {
            string input = Console.ReadLine();

            if (input != "")
            {
                if ((input.Equals("1") || input.ToLower().Equals("up") || input.ToLower().Equals("u")) && currentRoom.getYpos() != 0)
                    this.moveUp(maze);
                else if ((input.Equals("2") || input.ToLower().Equals("right") || input.ToLower().Equals("r")) && currentRoom.getXpos() != _size - 1)
                    this.moveRight(maze);
                else if ((input.Equals("3") || input.ToLower().Equals("down") || input.ToLower().Equals("d")) && currentRoom.getYpos() != _size - 1)
                    this.moveDown(maze);
                else if ((input.Equals("4") || input.ToLower().Equals("left") || input.ToLower().Equals("l")) && currentRoom.getXpos() != 0)
                    this.moveLeft(maze);
                else if (input.Equals("9") || input.ToLower().Equals("quit") || input.ToLower().Equals("q"))
                    return false;
                else if (input.Equals("0") || input.ToLower().Equals("save") || input.ToLower().Equals("s"))
                    saveGame(maze);
                else if (input.ToLower().Equals("cheat") || input.ToLower().Equals("cheat help"))
                    Console.WriteLine("Cheats:\n" +
                                        "Teleport(move to rooms coordinates): cheat 1,1/c 2,1 \n" +
                                        "Forced Move(Force way through door): cheat right/c r");
                else
                {
                    try
                    {
                        int cheatLength = 0;

                        if (input.Substring(0, 2).ToLower().Equals("c "))
                            cheatLength = 2;
                        else if (input.Substring(0, 6).ToLower().Equals("cheat "))
                            cheatLength = 6;

                        if (cheatLength != 0)
                        {
                            Door[,] xDoors = maze.getDoors("x");
                            Door[,] yDoors = maze.getDoors("y");
                            input = input.Substring(cheatLength, input.Length - cheatLength).ToLower();

                            if ((input.Equals("1") || input.Equals("up") || input.Equals("u")) && currentRoom.getYpos() != 0)
                            {
                                yDoors[currentRoom.getXpos(), currentRoom.getYpos() - 1].State = 0;
                                this.moveUp(maze);
                            }
                            else if ((input.Equals("2") || input.Equals("right") || input.Equals("r")) && currentRoom.getXpos() != _size - 1)
                            {
                                xDoors[currentRoom.getXpos(), currentRoom.getYpos()].State = 0;
                                this.moveRight(maze);
                            }
                            else if ((input.Equals("3") || input.Equals("down") || input.Equals("d")) && currentRoom.getYpos() != _size - 1)
                            {
                                yDoors[currentRoom.getXpos(), currentRoom.getYpos()].State = 0;
                                this.moveDown(maze);
                            }
                            else if ((input.Equals("4") || input.Equals("left") || input.Equals("l")) && currentRoom.getXpos() != 0)
                            {
                                xDoors[currentRoom.getXpos() - 1, currentRoom.getYpos()].State = 0;
                                this.moveLeft(maze);
                            }
                            else if (int.Parse(input.Substring(0, 1)) < xDoors.Length && int.Parse(input.Substring(0, 1)) >= 0 &&
                                    int.Parse(input.Substring(2, 1)) < yDoors.Length && int.Parse(input.Substring(2,1)) >= 0)
                            {
                                currentRoom = new Room(int.Parse(input.Substring(0, 1)), int.Parse(input.Substring(2, 1)), _endXPos, _endYPos);
                            }   
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Input was not valid.");
                    }
                }
            }

            return true;
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
