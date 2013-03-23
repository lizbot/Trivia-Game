using System;
using Domain.Model;
using SQLite;

namespace Infrastructure.Initialization
{
    public class DatabaseInitialization  
    {

        public static Question Question { get; set; }

        /// <summary>
        /// Initializes the database tables and configuration.
        /// </summary>
        public static void Database()
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.CreateTable<Question>();
                db.CreateTable<Answer>();
                db.CreateTable<Options>();
                db.CreateTable<Statistics>();
                db.CreateTable<GameSaved>();
                db.CreateTable<Category>();

                // Tried creating custom attributes in the domain to have them use the primary key attribute of sqlite
                // but couldn't figure out how that would work but we don't want those attributes in the domain
                // because the domain shouldn't have to know how we're persisting the data so it shouldn't have a 
                // sqlite attribute setting the primary key.
                SetPrimaryKey(db);
            }


            //Use for testing.
            //return DoesQuestionNameInTableExist("Hello?");
        }

        public static void SetPrimaryKey(SQLiteConnection db)
        {
            // Figure out how to set primary auto incrementing keys and columns
        }

        /// <summary>
        /// Use this for testing only.
        /// </summary>
        /// <param name="questionName"></param>
        /// <returns>
        /// Whether or not the question exists.
        /// </returns>
        public static Boolean DoesQuestionNameInTableExist(String questionName)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                db.BeginTransaction();
                db.Insert(new Question
                    {
                        CorrectAnswer =
                            {
                                AnswerId = 1,
                                IsCorrect = true,
                                Name = "Answer1",
                                QuestionId = 1
                            },
                        QuestionId = 1,
                        QuestionName = "Hello?"
                    });

                db.Get<Question>(q => q.QuestionName == questionName );
            }

            return true;
        }
    }
}