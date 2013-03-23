using System;
using System.Collections.Generic;
using Domain.Model;
using Domain.Persistence;
using Infrastructure.Initialization;

namespace Infrastructure.Persistence
{
    public class QuestionRepository : IQuestionRepository
    {
        /// <summary>
        /// This gets the number of questions specified from the database.
        /// </summary>
        /// <param name="amountOfQuestions">
        /// The amount of questions.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of the questions.
        /// </returns>
        public IEnumerable<Question> GetQuestions(Int32 amountOfQuestions)
        {
            using (var db = new SQLite.SQLiteConnection(PersistenceConfiguration.Database))
            {
                IEnumerable<Question> questionsToGet =
                    (from question in db.Table<Question>()
                     select question
                     ).Take(amountOfQuestions)
                      .OrderByDescending(quest => quest.TimesViewed)
                      .OrderByDescending(quest => quest.TimesCorrect);

                foreach (var question in questionsToGet)
                {
                    question.CorrectAnswer = GetRightAnswerFromQuestion (question.QuestionId);
                    question.WrongAnswers = GetWrongAnswersFromQuestion (question.QuestionId);
                }

                return questionsToGet;
            }
        }

        /// <summary>
        /// This gets the wrong answer from the question needed.
        /// </summary>
        /// <param name="questionId">
        /// 
        /// </param>
        /// <returns></returns>
        private IEnumerable<Answer> GetWrongAnswersFromQuestion(Int32 questionId)
        {
            using (var db = new SQLite.SQLiteConnection (PersistenceConfiguration.Database))
            {
                return db.Table<Answer>()
                         .Where(answer => answer.QuestionId == questionId &&
                                          answer.IsCorrect == false);
            }
        }

        /// <summary>
        /// Gets the right answer for the question.
        /// </summary>
        /// <param name="questionId">
        /// The question Id.
        /// </param>
        /// <returns>
        /// Returns answer object populated with correct answer.
        /// </returns>
        private Answer GetRightAnswerFromQuestion(Int32 questionId)
        {
            using (var db = new SQLite.SQLiteConnection (PersistenceConfiguration.Database))
            {
                return db.Table<Answer> ()
                         .Where(answer => answer.QuestionId == questionId &&
                                          answer.IsCorrect == true).First();
            }
        }
    }
}