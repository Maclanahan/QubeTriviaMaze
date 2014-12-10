using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
using System.Collections;
using System.Data;
using System.IO;

namespace TriviaMaze
{
    public class QuestionFactory
    {
        private List<AbstractQuestion> questions;

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
        //private DataSet DS;
        //private DataTable DT;

        public QuestionFactory()
        {
            questions = new List<AbstractQuestion>();

            LoadData();

            CreateList();
        }

        public List<AbstractQuestion> getQuestions()
        {
            return questions;
        }

        private void LoadData()
        {
            SetConnection();
        }

        private void SetConnection()
        {
            if (!File.Exists("questions.db"))
            {
                sql_con = new SQLiteConnection("Data Source=questions.db;Version=3;New=True;Compress=True;");
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();

                // Let the SQLiteCommand object know our SQL-Query:
                sql_cmd.CommandText = @"CREATE TABLE MCQuestions (Question varchar(500), ChoiceA varchar(100), ChoiceB varchar(100), ChoiceC varchar(100), ChoiceD varchar(100), Answer varchar(100));";

                // Now lets execute the SQL ;D
                sql_cmd.ExecuteNonQuery();

                // Lets insert something into our new table:
                sql_cmd.CommandText = @"INSERT INTO MCQuestions (Question, ChoiceA, ChoiceB, ChoiceC, ChoiceD, Answer) VALUES ('Q1', 'A', 'B', 'C', 'D', 'A');";

                // And execute this again ;D
                sql_cmd.ExecuteNonQuery();

                // Let the SQLiteCommand object know our SQL-Query:
                sql_cmd.CommandText = @"CREATE TABLE TFQuestions (Question varchar(500), Answer varchar(5));";

                // Now lets execute the SQL ;D
                sql_cmd.ExecuteNonQuery();

                // Lets insert something into our new table:
                sql_cmd.CommandText = @"INSERT INTO TFQuestions (Question, Answer) VALUES ('Q2', 'F');";

                // And execute this again ;D
                sql_cmd.ExecuteNonQuery();

                // Let the SQLiteCommand object know our SQL-Query:
                sql_cmd.CommandText = @"CREATE TABLE SAQuestions (Question varchar(500), Answer varchar(100));";

                // Now lets execute the SQL ;D
                sql_cmd.ExecuteNonQuery();

                // Lets insert something into our new table:
                sql_cmd.CommandText = @"INSERT INTO SAQuestions (Question, Answer) VALUES ('Q3', 'Hello');";

                // And execute this again ;D
                sql_cmd.ExecuteNonQuery();

                /*
                // ...and inserting another line:
                sql_cmd.CommandText = "INSERT INTO mains (id, desc) VALUES (2, 'Test Text 2');";

                // And execute this again ;D
                sql_cmd.ExecuteNonQuery();
                */

                // sql_con.Close();
            }

            else
            {
                sql_con = new SQLiteConnection("Data Source=questions.db;Version=3;New=False;Compress=True;");
                sql_con.Open();
               // Console.WriteLine("here");
            }
        }

        public void CreateList()
        {
            getMCQuestion();
            getTFQuestions();
            getSAQuestions();

            populateQuestions();
            shuffleQuestion();

            //questions.

            /*for (int i = 0; i < questions.Count; i++)
                questions[i].toString();*/ //reads questions


                sql_con.Close();
        }

        private void getMCQuestion()
        {
            string stm = "SELECT * FROM MCQuestions";
            sql_con.Close();
            sql_con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(stm, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        List<string> choices = new List<string>();
                       
                        choices.Add((string)rdr["ChoiceA"]);
                        choices.Add((string)rdr["ChoiceB"]);
                        choices.Add((string)rdr["ChoiceC"]);
                        choices.Add((string)rdr["ChoiceD"]);

                        questions.Add(new MultipleChoiceQuestion((string)rdr["Question"], (string)rdr["Answer"], choices));

                    }
                }
            }
        }

        private void getTFQuestions()
        {
            string stm = "SELECT * FROM TFQuestions";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        questions.Add(new TrueFalseQuestion((string)rdr["Question"], (string)rdr["Answer"]));
                    }
                }
            }
        }

        private void getSAQuestions()
        {
            string stm = "SELECT * FROM SAQuestions";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        questions.Add(new ShortAnswerQuestion((string)rdr["Question"], (string)rdr["Answer"]));
                    }
                }
            }
        }

        private void populateQuestions()
        {
            int originalCount = questions.Count;

            for (int i = 0; i < originalCount; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    questions.Add(questions[i]);
                }
            }
        }

        private void shuffleQuestion()
        {
            Random rand = new Random();

            for(int i = 0; i < questions.Count; i++)
            {
                swapQuestions(i, rand.Next(i, questions.Count));
            }

        }

        private void swapQuestions(int i, int j)
        {
            AbstractQuestion temp = questions[i];
            questions[i] = questions[j];
            questions[j] = temp;
        }

    }
}
