using System;
using System.Collections.Generic;
using System.Linq;
using Application.Model;
using Domain.Persistence;
using Infrastructure.Initialization;
using Infrastructure.Model;
using SQLite;
using Answer = Application.Model.Answer;
using AutoMapper;

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
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                IEnumerable<Questions> questionsToGet =
                    (from question in db.Table<Questions>()
                     select question
                     ).Take(amountOfQuestions)
                      .OrderByDescending(quest => quest.TimesViewed)
                      .OrderByDescending(quest => quest.TimesCorrect);

                var domainQuestions = new List<Question>();
                var dQuestion = new Question();
                foreach (var question in questionsToGet)
                {
                    dQuestion.CategoryId = question.CategoryId;
                    dQuestion.QuestionId = question.QuestionId;
                    dQuestion.QuestionName = question.QuestionName;
                    dQuestion.TimesCorrect = question.TimesCorrect;
                    dQuestion.TimesViewed = question.TimesViewed;
                    dQuestion.CorrectAnswer = new Answer();
                    dQuestion.WrongAnswers = new List<Answer>();
                    domainQuestions.Add(dQuestion);
                }

                var questionsWithAnswers = GetAnswersToQuestions(domainQuestions);

                return questionsWithAnswers;
            }
        }

        public void StoreQuestionToGameInProgress(AnsweredQuestion question)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                var game = new Model.GameSaved
                    {
                        AnswerId = question.SelectedAnswerId,
                        QuestionId = question.QuestionId
                    };

                db.Insert(game);
            }
        }

        private IEnumerable<Question> GetAnswersToQuestions(IEnumerable<Question> questionsForDomain)
        {
            var answersToQuestions = questionsForDomain as IList<Question> ?? questionsForDomain.ToList();

            foreach (var question in answersToQuestions)
            {
                question.CorrectAnswer = GetRightAnswerFromQuestion(question.QuestionId);
                    
                question.WrongAnswers = GetWrongAnswersFromQuestion(question.QuestionId);
            }

            return answersToQuestions;
        }

        /// <summary>
        /// This gets the wrong answer from the question needed.
        /// </summary>
        /// <param name="questionId"> </param>
        /// <returns></returns>
        private IEnumerable<Answer> GetWrongAnswersFromQuestion(Int32 questionId)
        {
            using (var db = new SQLiteConnection (PersistenceConfiguration.Database))
            {
                return db.Table<Answer>()
                         .Where(answer => answer.QuestionId == questionId &&
                                          answer.IsCorrect == false).ToList();
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
            using (var db = new SQLiteConnection (PersistenceConfiguration.Database))
            {
                return db.Table<Answer> ()
                         .Where(answer => answer.QuestionId == questionId &&
                                          answer.IsCorrect).First();
            }
        }
    }
}