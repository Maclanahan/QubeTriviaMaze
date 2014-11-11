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
            bool play = true;
            string str;
            Driver driver; 
            QuestionFactory qs = new QuestionFactory();
            qs.CreateList();
            DoorFactory df = new DoorFactory(qs.getQuestions());
            MazeFactory mf = new MazeFactory();
            

            while (play)
            {
                driver = new Driver(0, 0, _size-1, _size-1, _size); //coords for start room and then end room

                driver.enterMaze(mf.makeMaze(_size, df.makeHDoors(_size), df.makeVDoors(_size) ) );

                Console.WriteLine("Would you like to play again?(Y/N)");// can't play too many times or we will run out of questions to give to the doors
                str = Console.ReadLine().ToUpper();

                if (str.Equals("N"))
                    play = false;
            }
        }
    }
}
