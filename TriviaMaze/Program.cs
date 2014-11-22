using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Finisar.SQLite;

namespace TriviaMaze
{
    class Program
    {
        private const int _size = 3;

        static void Main(string[] args)
        {
            bool repeat = true;
            string str;
            Driver driver;
            QuestionTool qt;
            QuestionFactory qs = new QuestionFactory();
            DoorFactory df;
            MazeFactory mf;

            while (repeat)
            {
                Console.WriteLine("What would you like to do?\n" +
                                   "1: Play Trivia Maze\n" +
                                   "2: Manage Questions\n" +
                                   "3: Quit");

                str = Console.ReadLine();

                if (str.Equals("1"))
                {
                    bool play = true;

                    while (play)
                    {
                        qs.CreateList();
                        df = new DoorFactory(qs.getQuestions());
                        mf = new MazeFactory();

                        driver = new Driver(0, 0, _size - 1, _size - 1, _size); //coords for start room and then end room

                        driver.enterMaze(mf.makeMaze(_size, df.makeHDoors(_size), df.makeVDoors(_size)));

                        Console.WriteLine("Would you like to play again?(Y/N)");
                        str = Console.ReadLine().ToUpper();

                        if (str.Equals("N"))
                            play = false;
                    }
                }
                else if (str.Equals("2"))
                    qt = new QuestionTool();
                else if (str.Equals("3"))
                    repeat = false;
                else
                    Console.WriteLine("Input was invalid.");

            }
        }
    }
}
