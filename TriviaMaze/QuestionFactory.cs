//Daniel Heffley
//Sam Gronhovd
//Kevin Reynolds
//Triva Maze / Final Project
//Last Modified: 12/9/12

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
        private List<AbstractQuestion> _questions;

        private SQLiteConnection _sql_con;
        private SQLiteCommand _sql_cmd;

        public QuestionFactory(int other_size)
        {
            _questions = new List<AbstractQuestion>();

            LoadData();

            CreateList(other_size);
        }

#region Accessors / Mutators
        public List<AbstractQuestion> getQuestions()
        {
            return _questions;
        }
#endregion

#region Main Behavior
        private void LoadData()
        {
            SetConnection();
        }

        private void SetConnection()
        {
            if (!File.Exists("questions.db"))
            {
                _sql_con = new SQLiteConnection("Data Source=questions.db;Version=3;New=True;Compress=True;");
                _sql_con.Open();
                _sql_cmd = _sql_con.CreateCommand();

                _sql_cmd.CommandText = @"CREATE TABLE MCQuestions (Question varchar(500), ChoiceA varchar(100), ChoiceB varchar(100), ChoiceC varchar(100), ChoiceD varchar(100), Answer varchar(100));";

                _sql_cmd.ExecuteNonQuery();

                _sql_cmd.CommandText = @"INSERT INTO MCQuestions (Question, ChoiceA, ChoiceB, ChoiceC, ChoiceD, Answer) VALUES ('Q1', 'A', 'B', 'C', 'D', 'A');";

                _sql_cmd.ExecuteNonQuery();

                _sql_cmd.CommandText = @"CREATE TABLE TFQuestions (Question varchar(500), Answer varchar(5));";

                _sql_cmd.ExecuteNonQuery();

                _sql_cmd.CommandText = @"INSERT INTO TFQuestions (Question, Answer) VALUES ('Q2', 'F');";

                _sql_cmd.ExecuteNonQuery();

                _sql_cmd.CommandText = @"CREATE TABLE SAQuestions (Question varchar(500), Answer varchar(100));";

                _sql_cmd.ExecuteNonQuery();

                _sql_cmd.CommandText = @"INSERT INTO SAQuestions (Question, Answer) VALUES ('Q3', 'Hello');";

                _sql_cmd.ExecuteNonQuery();
            }

            else
            {
                _sql_con = new SQLiteConnection("Data Source=questions.db;Version=3;New=False;Compress=True;");
                _sql_con.Open();
               // Console.WriteLine("here");
            }
        }

        public void CreateList(int other_size)
        {
            getMCQuestion();
            getTFQuestions();
            getSAQuestions();

            if(_questions.Count < 2 * (other_size - 1) * other_size)
                populateQuestions(other_size);
            
            shuffleQuestion();

            _sql_con.Close();
        }

        private void getMCQuestion()
        {
            string stm = "SELECT * FROM MCQuestions";
            _sql_con.Close();
            _sql_con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(stm, _sql_con))
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

                        _questions.Add(new MultipleChoiceQuestion((string)rdr["Question"], (string)rdr["Answer"], choices));

                    }//end while loop
                }
            }
        }

        private void getTFQuestions()
        {
            string stm = "SELECT * FROM TFQuestions";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, _sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        _questions.Add(new TrueFalseQuestion((string)rdr["Question"], (string)rdr["Answer"]));
                    }//end while loop
                }
            }
        }

        private void getSAQuestions()
        {
            string stm = "SELECT * FROM SAQuestions";

            using (SQLiteCommand cmd = new SQLiteCommand(stm, _sql_con))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        _questions.Add(new ShortAnswerQuestion((string)rdr["Question"], (string)rdr["Answer"]));
                    }//end while loop
                }
            }
        }

        private void populateQuestions(int other_size)
        {
            int originalCount = _questions.Count;

            int questionsNeeded = 2 * (other_size - 1) * other_size;

            int quotient = questionsNeeded/originalCount;

            for (int i = 0; i < originalCount; i++)
            {
                for (int j = 0; j < quotient + 1; j++)
                {
                    _questions.Add(_questions[i]);
                }//end inner loop
            }//emd outer loop
        }

        private void shuffleQuestion()
        {
            Random rand = new Random();

            for(int i = 0; i < _questions.Count; i++)
            {
                swapQuestions(i, rand.Next(i, _questions.Count));
            }//end for loop

        }

        private void swapQuestions(int other_i, int other_j)
        {
            AbstractQuestion temp = _questions[other_i];
            _questions[other_i] = _questions[other_j];
            _questions[other_j] = temp;
        }
#endregion

    }
}
