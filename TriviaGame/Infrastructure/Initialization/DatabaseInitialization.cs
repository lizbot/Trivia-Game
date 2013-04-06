﻿using System;
using SQLite;
using Infrastructure.Model;
using System.Linq;

namespace Infrastructure.Initialization
{
    public class DatabaseInitialization  
    {

        public Questions Question { get; set; }

        /// <summary>
        /// Initializes the database tables and configuration.
        /// </summary>
        public static void Database()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.CreateTable<Questions>();
                db.CreateTable<Answer>();
               //db.CreateTable<Options>();
               // db.CreateTable<Statistics>();
                db.CreateTable<GameSaved>();
                db.CreateTable<Category>();
            }


            //Use for testing.
           // DoesQuestionNameInTableExist("Hello?");
            //var questions = GetQuestions("How are you?");
            //var categoryId = questions.CategoryId;
        }

        /// <summary>
        /// Use this for testing only.
        /// </summary>
        /// <param name="questionName"></param>
        /// <returns>
        /// Whether or not the question exists.
        /// </returns>
        public static Questions DoesQuestionNameInTableExist(String questionName)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();
                db.Insert(new Questions
                    {
                        CategoryId = 5,
                        QuestionName = "Hello?",
                        TimesCorrect = 2,
                        TimesViewed = 3,
                    });

                db.Insert(new Questions
                {
                    CategoryId = 5,
                    QuestionName = "how are you?",
                    TimesCorrect = 2,
                    TimesViewed = 3,
                });

                // don't forget to fucking commit... liz is a tard.
                db.Commit();

                var questions = GetQuestions("how are you?");
                return questions;

               var returnQuestion1 = db.Get<Questions>(q => q.QuestionName == questionName );
               var returnQuestion2 = db.Get<Questions>(q => q.QuestionName == "how are you?");
               return returnQuestion2;
            }
        }

        private static Questions GetQuestions(String nameOfQuestion)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var returnQuestionsfrom = db.Get<Questions>(q => q.QuestionName == nameOfQuestion);
                return returnQuestionsfrom;
            }
        }
        
    }
}