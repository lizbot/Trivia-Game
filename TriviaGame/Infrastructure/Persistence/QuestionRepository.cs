using System;
using System.Collections.Generic;
using System.Linq;
using Application.Model;
using Domain.Persistence;
using Infrastructure.Initialization;
using Infrastructure.Model;
using Answer = Application.Model.Answer;

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
        /// An <see cref="IEnumerable{T}"/> of the questions mapped to the domain.
        /// </returns>
        public IEnumerable<Question> GetQuestions(Int32 amountOfQuestions)
        {
            using (var db = new SQLite.SQLiteConnection(PersistenceConfiguration.Database))
            {
                IEnumerable<Question> domainQuestions = new List<Question>();

                IEnumerable<Questions> questionsToGet =
                    (from question in db.Table<Questions>()
                     select question
                     ).Take(amountOfQuestions)
                      .OrderByDescending(quest => quest.TimesViewed)
                      .OrderByDescending(quest => quest.TimesCorrect);

                foreach (var question in questionsToGet)
                {
                    foreach (var domainQuestion in domainQuestions)
                    {
                        domainQuestion.CategoryId = question.CategoryId;
                        domainQuestion.QuestionId = question.QuestionId;
                        domainQuestion.QuestionName = question.QuestionName;
                        domainQuestion.TimesCorrect = question.TimesCorrect;
                        domainQuestion.TimesViewed = question.TimesViewed;
                    }
                }

                var questionsWithAnswers = GetAnswersToQuestions(domainQuestions);

                return questionsWithAnswers;
            }
        }

        private IEnumerable<Question> GetAnswersToQuestions(IEnumerable<Question> questionsForDomain)
        {
            using (var db = new SQLite.SQLiteConnection(PersistenceConfiguration.Database))
            {
                //IEnumerable<Answer> answers = null;
                foreach (var question in questionsForDomain)
                {
                    question.CorrectAnswer = (from answer in db.Table<Answer>() select answer)
                                              .Where(answer => 
                                                  answer.QuestionId == question.QuestionId 
                                                  && answer.IsCorrect)
                                              .First();

                    foreach (var answer in question.WrongAnswers)
                    {
                        question.WrongAnswers = (from a in db.Table<Answer>() select a)
                            .Where(a => a.QuestionId == question.QuestionId && !a.IsCorrect);
                    }
                }

                return questionsForDomain;
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