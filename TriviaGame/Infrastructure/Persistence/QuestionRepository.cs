using System;
using System.Collections.Generic;
using Application.Model;
using Domain.Persistence;
using Infrastructure.Initialization;
using Infrastructure.Model;
using Answer = Application.Model.Answer;
using System.Linq;
using AutoMapper;

namespace Infrastructure.Persistence
{
    using System.Collections.ObjectModel;

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
                //Mapper.CreateMap<Model.Answer, Answer>();

                //Mapper.CreateMap<Questions, Question>()
                //      .ForMember(dest => dest.CorrectAnswer, opt => opt.UseValue(default(Answer)))
                //      .ForMember(dest => dest.WrongAnswers, opt => opt.UseValue(default(Answer)));

                //      //.ConstructUsing(q => new Question
                //      //    {
                //      //        QuestionId = q.QuestionId,
                //      //        QuestionName = q.QuestionName,
                //      //        CorrectAnswer = Mapper.Map<Infrastructure.Model.Answer, Application.Model.Answer>()
                //      //    });
                
                //Mapper.AssertConfigurationIsValid();



                IEnumerable<Questions> questionsToGet =
                    (from question in db.Table<Questions>()
                     select question
                     ).Take(amountOfQuestions)
                      .OrderByDescending(quest => quest.TimesViewed)
                      .OrderByDescending(quest => quest.TimesCorrect);

                var domainQuestions = new List<Question>();

                foreach (var question in questionsToGet)
                {
                    //domainQuestions.Add();
                }

                var questionsWithAnswers = GetAnswersToQuestions(domainQuestions);

                throw new NotImplementedException();
                return questionsWithAnswers;
            }
        }

        private IEnumerable<Question> GetAnswersToQuestions(IEnumerable<Question> questionsForDomain)
        {
                //IEnumerable<Answer> answers = null;
                foreach (var question in questionsForDomain)
                {
                    question.CorrectAnswer = GetRightAnswerFromQuestion(question.QuestionId);

                    question.WrongAnswers = GetWrongAnswersFromQuestion(question.QuestionId);
                }

                return questionsForDomain;
        }

        /// <summary>
        /// This gets the wrong answer from the question needed.
        /// </summary>
        /// <param name="questionId"> </param>
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