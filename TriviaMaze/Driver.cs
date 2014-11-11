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

        public Driver(int xpos, int ypos, int endXPos, int endYPos)
        {
            _xpos = xpos;
            _ypos = ypos;
            _endXPos = endXPos;
            _endYPos = endYPos;
        }

        public void enterMaze()
        {
            int n;

            while(_xpos != _endXPos || _ypos != _endYPos)
            {
                Console.WriteLine("You are in room: x-" + _xpos + " y-" + _ypos + 
                    "\nWhere would you like to go?" +
                    "\nThe end is at x-" + _endXPos + " y-" + _endYPos + 
                    "\nEnter 1(Up), 2(Right), 3(Down), 4(Left)");
                n = int.Parse(Console.ReadLine());

                if (n == 1)
                    this.moveUp();
                else if (n == 2)
                    this.moveRight();
                else if (n == 3)
                    this.moveDown();
                else if (n == 4)
                    this.moveLeft();
                else
                    Console.WriteLine("Input was not valid.");

            }

            Console.WriteLine("You won!");
        }

        private void moveUp()
        {
            _ypos -= 1;
        }

        private void moveRight()
        {
            _xpos += 1;
        }

        private void moveDown()
        {
            _ypos += 1;
        }

        private void moveLeft()
        {
            _xpos -= 1;
        }
    }
}
