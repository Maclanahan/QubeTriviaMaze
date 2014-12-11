//Daniel Heffley
//Sam Gronhovd
//Kevin Reynolds
//Triva Maze / Final Project
//Last Modified: 12/9/12

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Finisar.SQLite;

namespace TriviaMaze
{
    class Program
    {
        //private const int _size = 4;

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
            }//end while loop
        }

#region Main Behavior
        private static void playGame(bool other_isLoaded)
        {
            int size = 4;

            if (!other_isLoaded)
                size = askForMazeSize();
            else
                size = loadSize();

            Driver driver;
            
            QuestionFactory qs = new QuestionFactory(size);
            DoorFactory df;
            MazeFactory mf;

            string str;

            bool play = true;

            while (play)
            {
                qs.CreateList(size);
                df = new DoorFactory(qs.getQuestions());
                mf = new MazeFactory();

                driver = new Driver(0, 0, size - 1, size - 1, size); //coords for start room and then end room

                if (other_isLoaded)
                    loadGame(driver);
                else
                    driver.enterMaze(mf.makeMaze(size, df.makeHDoors(size), df.makeVDoors(size)));

                Console.WriteLine("Would you like to play again?(Y/N)");
                str = Console.ReadLine().ToUpper();

                other_isLoaded = false;

                if (str.Equals("N"))
                    play = false;
            }//end while loop
        }

        private static int askForMazeSize()
        {
            Console.WriteLine("Choose Difficulty\nEnter any Integer between the values of 2 and 9\n2 being the easiest, and 9 being the hardest");

            string str = Console.ReadLine();
            
            if (str == "2")
                return 2;
            if (str == "3")
                return 3;
            if (str == "4")
                return 4;
            if (str == "5")
                return 5;
            if (str == "6")
                return 6;
            if (str == "7")
                return 7;
            if (str == "8")
                return 8;
            if (str == "9")
                return 9;
            else
            {
                Console.WriteLine("Invalid Difficulty Rating.");
                return askForMazeSize();
            }

            
        }
#endregion

#region Serializable
        private static void loadGame(Driver other_driver)
        {
            Serializer serializer = new Serializer();
            SaveData load = serializer.Deserialize("output.txt");

            other_driver.setCurrentRoom(load.getPosition());
            other_driver.enterMaze(load.getMaze());
        }

        private static int loadSize()
        {
            Serializer serializer = new Serializer();
            SaveData load = serializer.Deserialize("output.txt");

            return load.getSize();
        }
#endregion

    }
}
