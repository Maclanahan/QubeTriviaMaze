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
    public class Driver
    {
        private int _xpos;
        private int _ypos;
        private int _endXPos;
        private int _endYPos;
        private int _size;

        private Room currentRoom;

        public Driver(int other_xpos, int other_ypos, int other_endXPos, int other_endYPos, int other_size)
        {
            if (other_xpos < 0 || other_xpos >= other_size ||
                other_ypos < 0 || other_xpos >= other_size ||
                other_endXPos < 0 || other_endXPos >= other_size ||
                other_endYPos < 0 || other_endYPos >= other_size ||
                other_size < 0)
                throw new ArgumentOutOfRangeException();

            _xpos = other_xpos;
            _ypos = other_ypos;
            _endXPos = other_endXPos;
            _endYPos = other_endYPos;
            _size = other_size;
            currentRoom = new Room(0, 0, other_endXPos, other_endYPos);
        }

#region Main Behaviors
        public void enterMaze(Maze other_maze)
        {   
            bool play = true;
            _xpos = currentRoom.getXpos();
            _ypos = currentRoom.getYpos();

            currentRoom = other_maze.getCurrentRoom(_xpos, _ypos);

            Solvable solver = new Solvable(_size);

            while (!other_maze.isFinalRoom(currentRoom.getXpos(), currentRoom.getYpos()) && play)
            {
                other_maze.PrintMaze(currentRoom);
                Console.WriteLine("Where would you like to go?\n" +
                    "Enter 1(Up), 2(Right), 3(Down), 4(Left), 9(Quit), 0(Save)");

                play = playerAct(other_maze);
                if (solver.checkIfMazeIsSolvable(other_maze, currentRoom) == false)
                {
                    Console.WriteLine("Unsolvable");
                    break;
                }

            }

            if (currentRoom.getXpos() == _endXPos && currentRoom.getYpos() == _endYPos)
                Console.WriteLine("You won!");

        }

        private bool playerAct(Maze other_maze)
        {
            string input = Console.ReadLine();

            if (input != "")
            {
                if ((input.Equals("1") || input.ToLower().Equals("up") || input.ToLower().Equals("u")) && currentRoom.getYpos() != 0)
                    this.moveUp(other_maze);
                else if ((input.Equals("2") || input.ToLower().Equals("right") || input.ToLower().Equals("r")) && currentRoom.getXpos() != _size - 1)
                    this.moveRight(other_maze);
                else if ((input.Equals("3") || input.ToLower().Equals("down") || input.ToLower().Equals("d")) && currentRoom.getYpos() != _size - 1)
                    this.moveDown(other_maze);
                else if ((input.Equals("4") || input.ToLower().Equals("left") || input.ToLower().Equals("l")) && currentRoom.getXpos() != 0)
                    this.moveLeft(other_maze);
                else if (input.Equals("9") || input.ToLower().Equals("quit") || input.ToLower().Equals("q"))
                    return false;
                else if (input.Equals("0") || input.ToLower().Equals("save") || input.ToLower().Equals("s"))
                    saveGame(other_maze);
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
                            Door[,] xDoors = other_maze.getDoors("x");
                            Door[,] yDoors = other_maze.getDoors("y");
                            input = input.Substring(cheatLength, input.Length - cheatLength).ToLower();

                            if ((input.Equals("1") || input.Equals("up") || input.Equals("u")) && currentRoom.getYpos() != 0)
                            {
                                yDoors[currentRoom.getXpos(), currentRoom.getYpos() - 1].State = 0;
                                this.moveUp(other_maze);
                            }
                            else if ((input.Equals("2") || input.Equals("right") || input.Equals("r")) && currentRoom.getXpos() != _size - 1)
                            {
                                xDoors[currentRoom.getXpos(), currentRoom.getYpos()].State = 0;
                                this.moveRight(other_maze);
                            }
                            else if ((input.Equals("3") || input.Equals("down") || input.Equals("d")) && currentRoom.getYpos() != _size - 1)
                            {
                                yDoors[currentRoom.getXpos(), currentRoom.getYpos()].State = 0;
                                this.moveDown(other_maze);
                            }
                            else if ((input.Equals("4") || input.Equals("left") || input.Equals("l")) && currentRoom.getXpos() != 0)
                            {
                                xDoors[currentRoom.getXpos() - 1, currentRoom.getYpos()].State = 0;
                                this.moveLeft(other_maze);
                            }
                            else if (int.Parse(input.Substring(0, 1)) < xDoors.Length && int.Parse(input.Substring(0, 1)) >= 0 &&
                                    int.Parse(input.Substring(2, 1)) < yDoors.Length && int.Parse(input.Substring(2, 1)) >= 0)
                            {
                                int x = int.Parse(input.Substring(0, 1));
                                int y = int.Parse(input.Substring(2, 1));

                                if (x < _size && y < _size)
                                    currentRoom = new Room(x, y, _endXPos, _endYPos);

                                else
                                    Console.WriteLine("Invalid Cheat");
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

        private void moveUp(Maze other_maze)
        {
            _ypos -= 1;
            currentRoom = other_maze.Move(currentRoom, 0, -1);
        }

        private void moveRight(Maze other_maze)
        {
            _xpos += 1;
            currentRoom = other_maze.Move(currentRoom, 1, 0);
        }

        private void moveDown(Maze other_maze)
        {
            _ypos += 1;
            currentRoom = other_maze.Move(currentRoom, 0, 1);
        }

        private void moveLeft(Maze other_maze)
        {
            _xpos -= 1;
            currentRoom = other_maze.Move(currentRoom, -1, 0);
        }

#endregion

#region Accessors/Mutators
        public void setCurrentRoom(Room other_current)
        {
            if (other_current == null)
                throw new NullReferenceException();

            currentRoom = other_current;
        }
#endregion

#region Serializable
        private void saveGame(Maze other_maze)
        {
            SaveData save = new SaveData(other_maze, currentRoom, _size);

            Serializer serializer = new Serializer();
            serializer.Serialize("output.txt", save);
        }
#endregion

    }
}
