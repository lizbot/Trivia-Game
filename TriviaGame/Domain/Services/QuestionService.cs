using Application.Domain;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _QuestionRepository;

        private readonly IOptionsRepository _OptionsRepository;

        public QuestionService(
            IQuestionRepository questionRepository, 
            IOptionsRepository optionsRepository)
        {
            _QuestionRepository = questionRepository;
            _OptionsRepository = optionsRepository;
        }
        
        /// <summary>
        /// This method is written to get 20 generic questions, specific to quick-play.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Question> GetQuestions()
        {
            // Do we want this just for getting questions for a specific category 
            //or apply user settings every time they play game, regardless of type?
            var userPreferredQuestionOption = 20;// _OptionsRepository.GetCustomOptions().NumberOfQuestionsDesired;

            if (userPreferredQuestionOption == null)
                userPreferredQuestionOption = 20;

            // this gets the IEnumerable<Question> of all the questions that you want from the database.
            var questions = _QuestionRepository.GetQuestions(userPreferredQuestionOption);

            return questions;
        }

        public void StoreAnsweredQuestion(AnsweredQuestion question)
        {
            _QuestionRepository.StoreQuestionToGameInProgress(question);
        }

        //Gets the questions as a parameter and gets them back to the repository
        //Statistics service to know about the user. Percent correct (calculate this somewhere else)
    }
}