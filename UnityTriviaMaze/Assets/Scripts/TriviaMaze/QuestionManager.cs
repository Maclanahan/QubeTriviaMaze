﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Data;

namespace TriviaMaze
{
    class QuestionManager
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private string _type;

        public QuestionManager(string type)
        {
            _type = type;
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
                Console.WriteLine("You're currently managing " + _type + "\n" +
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
            }
        }

        private void add()
        {
            bool correct = false;
            string answer = "";
            string one = "";
            string two = "";
            string three = "";
            string four = " ";

            Console.Write("Question: ");
            string question = Console.ReadLine();

            if (_type.Equals("MCQuestions"))
            {
                Console.Write("1: ");
                one = Console.ReadLine();

                Console.Write("2: ");
                two = Console.ReadLine();

                Console.Write("3: ");
                three = Console.ReadLine();

                Console.Write("4: ");
                four = Console.ReadLine();
            }
            
            // Makes sure that answer inputted matches the question
            while (!correct )
            {
                Console.Write("Answer: ");
                answer = Console.ReadLine();

                if(_type.Equals("TFQuestions"))
                {
                    if (answer.Equals("t") || answer.Equals("true"))
                        answer = "1";

                    if (answer.Equals("f") || answer.Equals("false"))
                        answer = "2";
                }

                if (answer.Equals("1") || answer.Equals("2") || answer.Equals("3") || answer.Equals("4") || _type.Equals("SAQuestions"))
                    correct = true;
                else
                    Console.WriteLine("Answer was invalid. Try again.");
            }


            if (_type.Equals("MCQuestions"))
            {
                sql_cmd = new SQLiteCommand("INSERT INTO " + _type + " (Question, ChoiceA, ChoiceB, ChoiceC, ChoiceD, Answer) VALUES (@question, @one, @two, @three, @four, @answer)", sql_con);

                SQLiteParameter pOne = new SQLiteParameter("@one", DbType.String) { Value = one };
                SQLiteParameter pTwo = new SQLiteParameter("@two", DbType.String) { Value = two };
                SQLiteParameter pThree = new SQLiteParameter("@three", DbType.String) { Value = three };
                SQLiteParameter pFour = new SQLiteParameter("@four", DbType.String) { Value = four };

                sql_cmd.Parameters.Add(pOne);
                sql_cmd.Parameters.Add(pTwo);
                sql_cmd.Parameters.Add(pThree);
                sql_cmd.Parameters.Add(pFour);
            }
            else if ( _type.Equals("TFQuestions") || _type.Equals("SAQuestions"))
                sql_cmd = new SQLiteCommand("INSERT INTO " + _type + " (Question, Answer) VALUES (@question, @answer)", sql_con);
            else
            {
                Console.WriteLine("Invalid Type.");
                return;
            }

            SQLiteParameter pQuestion = new SQLiteParameter("@question", DbType.String ) { Value = question };
            SQLiteParameter pAnswer = new SQLiteParameter("@answer", DbType.String) { Value = answer };

            sql_cmd.Parameters.Add(pQuestion);
            sql_cmd.Parameters.Add(pAnswer);

            sql_cmd.ExecuteNonQuery();
        }

        private void remove()
        {
            int i, num = 0;
            string stm = "SELECT * FROM " + _type;
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

            sql_cmd = new SQLiteCommand("DELETE FROM " + _type + " WHERE Question=@Question", sql_con);

            SQLiteParameter pQuestion = new SQLiteParameter("@Question", DbType.String) { Value = str };
            sql_cmd.Parameters.Add(pQuestion);

            sql_cmd.ExecuteNonQuery();
        }

        private void display()
        {
            string stm = "SELECT * FROM " + _type;
            
            using (SQLiteCommand cmd = new SQLiteCommand(stm, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    int i = 1;
                    while (rdr.Read())
                    {
                        Console.WriteLine(i + ")");
                        Console.WriteLine("Question: " + (string)rdr["Question"]);

                        if (_type.Equals("MCQuestions"))
                        {
                            Console.WriteLine("1: " + (string)rdr["ChoiceA"]);
                            Console.WriteLine("2: " + (string)rdr["ChoiceB"]);
                            Console.WriteLine("3: " + (string)rdr["ChoiceC"]);
                            Console.WriteLine("4: " + (string)rdr["ChoiceD"]);
                        }
                        
                        Console.WriteLine("Answer: " + (string)rdr["Answer"]);

                        i += 1;
                    }
                }
            }
        }
    }
}
