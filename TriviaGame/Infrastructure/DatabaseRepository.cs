using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Infrastructure
{
    public class DatabaseRepository
    {
        public void DoMe()
        {
            try
            {
                // New=True means that it's creating the database inside of the application.
                var connection = new SQLiteConnection("Data Source=TriviaGame.s3db;Version=3;New=True");

                connection.Open();

                var QuestionTableCreation = @"CREATE TABLE Questions
                                                (QuestionId INTEGER PRIMARY KEY,
                                                CorrectAnswerId INTEGER NOT NULL,
                                                FirstIncorrectAnswerId INTEGER NOT NULL,
                                                SecondIncorrectAnswerId INTEGER NOT NULL,
                                                ThirdIncorrectAnswerId INTEGER NOT NULL,
                                                Question TEXT NOT NULL,
                                                CategoryId INTEGER NOT NULL);
                                                ";

                var InsertQuestionOne = @"INSERT INTO 
                                          Questions(CorrectAnswerId, 
                                          FirstIncorrectAnswerId, 
                                          SecondIncorrectAnswerId, 
                                          ThirdIncorrectAnswerId, 
                                          Question, 
                                          CategoryId)
                                          VALUES(1, 2, 3, 4, 'What is the capital of Colombia?', 1');";
                var InsertQuestionTwo = @"INSERT INTO Questions(CorrectAnswerId, FirstIncorrectAnswerId, SecondIncorrectAnswerId, ThirdIncorrectAnswerId, Question, CategoryId)
                                          VALUES(5, 6, 7, 8, 'Which basketball team is based in Miami?', 9);";

                var command = new SQLiteCommand(QuestionTableCreation, connection);

                command.ExecuteNonQuery();

                SQLiteDataAdapter adapter;
                var set = new DataSet();
                var table = new DataTable();

                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        Debug.WriteLine(row[i]);
                    }

                    Debug.WriteLine("\n");
                }

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
