using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Finisar.SQLite;

namespace TriviaMaze
{
    class Program
    {
        private const int _size = 4;

        static void Main(string[] args)
        {
            QuestionTool qt;
            bool repeat = true;
            string str;

            while (repeat)
            {
                Console.WriteLine("What would you like to do?\n" +
                                   "1: Play Trivia Maze\n" +
                                   "2: Manage Questions\n" +
                                   "3: Load Game\n" +
                                   "4: Quit");

                str = Console.ReadLine();

                if (str.Equals("1"))
                {
                    playGame(false);
                }
                else if (str.Equals("2"))
                    qt = new QuestionTool();
                else if (str.Equals("3"))
                    playGame(true);
                else if (str.Equals("4"))
                    repeat = false;
                else
                    Console.WriteLine("Input was invalid.");

            }
        }


        private static void playGame(bool isLoaded)
        {
            Driver driver;
            
            QuestionFactory qs = new QuestionFactory();
            DoorFactory df;
            MazeFactory mf;

            string str;

            bool play = true;

            while (play)
            {
                qs.CreateList();
                df = new DoorFactory(qs.getQuestions());
                mf = new MazeFactory();

                driver = new Driver(0, 0, _size - 1, _size - 1, _size); //coords for start room and then end room

                if (isLoaded)
                    loadGame(driver);
                else
                    driver.enterMaze(mf.makeMaze(_size, df.makeHDoors(_size), df.makeVDoors(_size)));

                Console.WriteLine("Would you like to play again?(Y/N)");
                str = Console.ReadLine().ToUpper();

                isLoaded = false;

                if (str.Equals("N"))
                    play = false;
            }
        }

        private static void loadGame(Driver driver)
        {
            Serializer serializer = new Serializer();
            SaveData load = serializer.Deserialize("output.txt");

            //load.getMaze()
            driver.setCurrentRoom(load.getPosition());
            driver.enterMaze(load.getMaze());
        }
    }
}
