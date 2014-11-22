using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;

namespace TriviaMaze
{
    class MultipleChoiceManager
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        public MultipleChoiceManager()
        {   
            sql_con = new SQLiteConnection("Data Source=questions.db;Version=3;New=False;Compress=True;");
            sql_con.Open();

            manage();

            sql_con.Close();
        }

        private void manage()
        {
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("You're currently managing MultipleChoice questions.\n" +
                                    "What would you like to do?\n" +
                                    "1: Add\n" +
                                    "2: Remove\n" +
                                    "3: Display Questions\n" +
                                    "4: Exit");

                string input = Console.ReadLine();

                if (input.Equals("1"))
                    this.add();
                else if (input.Equals("2"))
                    this.remove();
                else if (input.Equals("3"))
                    this.display();
                else if (input.Equals("4"))
                    repeat = false;
                else
                    Console.WriteLine("Input was invalid.");

                Console.WriteLine("\n");
            }
        }

        private void add()
        {
            bool correct = false;
            string answer = "";

            Console.Write("Question: ");
            string question = Console.ReadLine();

            Console.Write("1: ");
            string one = Console.ReadLine();

            Console.Write("2: ");
            string two = Console.ReadLine();

            Console.Write("3: ");
            string three = Console.ReadLine();

            Console.Write("4: ");
            string four = Console.ReadLine();

            while (!correct)
            {
                Console.Write("Answer: ");
                answer = Console.ReadLine();

                if (answer.Equals("1") || answer.Equals("2") || answer.Equals("3") || answer.Equals("4"))
                    correct = true;
                else
                    Console.WriteLine("Answer was invalid. Try again.");
            }

            sql_cmd = new SQLiteCommand("INSERT INTO MCQuestions (Question, ChoiceA, ChoiceB, ChoiceC, ChoiceD, Answer) VALUES (@question, @one, @two, @three, @four, @answer)", sql_con);

            SQLiteParameter pQuestion = new SQLiteParameter("@question", DbType.String ) { Value = question };
            SQLiteParameter pOne = new SQLiteParameter("@one", DbType.String) { Value = one };
            SQLiteParameter pTwo = new SQLiteParameter("@two", DbType.String) { Value = two };
            SQLiteParameter pThree = new SQLiteParameter("@three", DbType.String) { Value = three };
            SQLiteParameter pFour = new SQLiteParameter("@four", DbType.String) { Value = four };
            SQLiteParameter pAnswer = new SQLiteParameter("@answer", DbType.String) { Value = answer };

            sql_cmd.Parameters.Add(pQuestion);
            sql_cmd.Parameters.Add(pOne);
            sql_cmd.Parameters.Add(pTwo);
            sql_cmd.Parameters.Add(pThree);
            sql_cmd.Parameters.Add(pFour);
            sql_cmd.Parameters.Add(pAnswer);

            sql_cmd.ExecuteNonQuery();
        }

        private void remove()
        {
            int i, num = 0;
            string stm = "SELECT * FROM MCQuestions";
            string str = "";
            bool repeat = true;

            using (SQLiteCommand cmd = new SQLiteCommand(stm, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    i = 1;
                    while (rdr.Read())
                    {
                        Console.WriteLine(i + ") Question: " + (string)rdr["Question"]);

                        i += 1;
                    }
                }

                while (repeat)
                {
                    Console.WriteLine("Which question would you like to remove?\n" +
                                        "Enter the question's number or enter 0 to exit.");

                    num = int.Parse(Console.ReadLine());

                    if (num <= i && num > 0)
                        repeat = false;
                    else if (num == 0)
                        return;
                    else
                        Console.WriteLine("Invalid input. Please try again.");

                }

                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    i = 1;
                    while (rdr.Read())
                    {
                        if (i == num)
                        {
                            str = (string)rdr["Question"];
                            
                        }

                        i += 1;
                    }
                }
            }

            Console.WriteLine("Removed: " + num + ") Question: " + str);

            sql_cmd = new SQLiteCommand("DELETE FROM MCQuestions WHERE Question=@Question", sql_con);

            SQLiteParameter pQuestion = new SQLiteParameter("@Question", DbType.String) { Value = str };
            sql_cmd.Parameters.Add(pQuestion);

            sql_cmd.ExecuteNonQuery();
        }

        private void display()
        {
            string stm = "SELECT * FROM MCQuestions";
            
            using (SQLiteCommand cmd = new SQLiteCommand(stm, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    int i = 1;
                    while (rdr.Read())
                    {
                        Console.WriteLine(i + ")");
                        Console.WriteLine("Question: " + (string)rdr["Question"]);
                        Console.WriteLine("1: " + (string)rdr["ChoiceA"]);
                        Console.WriteLine("2: " + (string)rdr["ChoiceB"]);
                        Console.WriteLine("3: " + (string)rdr["ChoiceC"]);
                        Console.WriteLine("4: " + (string)rdr["ChoiceD"]);
                        Console.WriteLine("Answer: " + (string)rdr["Answer"]);

                        i += 1;
                    }
                }
            }
        }
    }
}
