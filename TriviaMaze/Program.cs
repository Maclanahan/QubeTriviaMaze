using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Finisar.SQLite;

namespace TriviaMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            string str;
            Driver driver; 
            QuestionFactory qs = new QuestionFactory();

            while (play)
            {
                driver = new Driver(0, 0, 2, 2); //Room Class should know if it's the endroom or not

                driver.enterMaze();

                Console.WriteLine("Would you like to play again?(Y/N)");
                str = Console.ReadLine().ToUpper();

                if (str.Equals("N"))
                    play = false;
            }
        }
    }
}
