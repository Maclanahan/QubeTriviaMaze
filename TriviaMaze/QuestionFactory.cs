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
    class QuestionFactory
    {
        private List<AbstractQuestion> questions;

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS;
        private DataTable DT;

        public QuestionFactory()
        {
            LoadData();

            PrintData();

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
            }
        }

        public void PrintData()
        {
            string stm = "SELECT * FROM MCQuestions";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.Write("{0} ", rdr["Question"]);
                        Console.Write("{0} ", rdr["ChoiceA"]);
                        Console.Write("{0} ", rdr["ChoiceB"]);
                        Console.Write("{0} ", rdr["ChoiceC"]);
                        Console.Write("{0} ", rdr["ChoiceD"]);
                        Console.Write("{0} ", rdr["Answer"]);


                    }
                }
            }

            sql_con.Close();

            Console.ReadLine();
        }
    }
}
