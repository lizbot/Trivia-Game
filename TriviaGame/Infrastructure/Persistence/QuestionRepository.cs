using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Model;
using Domain.Persistence;
using Infrastructure.Initialization;
using Infrastructure.Model;
using SQLite;
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
        /// <param name="categoryId">
        /// The categoryId if needed.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of the questions mapped to the domain.
        /// </returns>
        public IEnumerable<Question> GetQuestions(Int32 amountOfQuestions, Int32 categoryId = 0)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                IEnumerable<Questions> questionsToGet;
                if(categoryId == 0)
                {
                    questionsToGet =
                    (from question in db.Table<Questions>()
                     select question
                    ).Take(amountOfQuestions)
                     .OrderByDescending(quest => quest.TimesViewed)
                     .OrderByDescending(quest => quest.TimesCorrect);
                }
                else
                {
                    questionsToGet =
                    (from question in db.Table<Questions>()
                     select question
                    ).Where(q => q.CategoryId == categoryId)
                     .Take(amountOfQuestions)
                     .OrderByDescending(quest => quest.TimesViewed)
                     .OrderByDescending(quest => quest.TimesCorrect);
                }

                var domainQuestions = questionsToGet
                    .Select(question => 
                        new Question
                        {
                            CategoryId = question.CategoryId, 
                            QuestionId = question.QuestionId, 
                            QuestionName = question.QuestionName, 
                            TimesCorrect = question.TimesCorrect, 
                            TimesViewed = question.TimesViewed, 
                            CorrectAnswer = new Answer(), 
                            WrongAnswers = new List<Answer>()
                        }).ToList();

                var questionsWithAnswers = GetAnswersToQuestions(domainQuestions);

                //_GameRepository.StoreGameInProgress(questionsWithAnswers);

                return questionsWithAnswers;
            }
        }

        public Question GetQuestion(Int32 questionId)
        {
            using (var db = new SQLiteConnection(PersistenceConfiguration.Database))
            {
                Question returnedQuestion;

                var q =
                    (from question in db.Table<Model.GameSaved>()
                     select question
                    ).Join(db.Table<Questions>(), 
                           game => game.QuestionId, 
                           questionObject => questionObject.QuestionId,
                           (game,questionObject) => questionObject).First();

                returnedQuestion = new Question
                    {
                        CategoryId = q.CategoryId,
                        CorrectAnswer = new Answer(),
                        QuestionId = q.QuestionId,
                        QuestionName = q.QuestionName,
                        TimesCorrect = q.TimesCorrect,
                        TimesViewed = q.TimesViewed,
                        WrongAnswers = new List<Answer>()
                    };

                return returnedQuestion;
            }
        }

        /// <summary>
        /// This stores the question answered to a game in progress so the user can pick up where they left off if they log off.
        /// </summary>
        /// <param name="question"></param>
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

        /// <summary>
        /// This populates the question domain objects with answers associated to each question.
        /// </summary>
        /// <param name="questionsForDomain"></param>
        /// <returns></returns>
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