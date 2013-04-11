using System;
using Application.Domain;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _QuestionRepository;

        private readonly IOptionsService _OptionsService;

        public QuestionService(
            IQuestionRepository questionRepository,
            IOptionsService optionsService)
        {
            _QuestionRepository = questionRepository;
            _OptionsService = optionsService;
        }
        
        /// <summary>
        /// This method is written to get 20 generic questions, specific to quick-play.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Question> GetQuestions(Int32? categoryId = 0)
        {
            // Do we want this just for getting questions for a specific category 
            //or apply user settings every time they play game, regardless of type?
            // Daniel: "yes, I would say apply settings to all games types"
            var userPreferredQuestionOption = 15;
 
            //use this to get the userPreferredQuestionOption.
            //var x = _OptionsService.GetCustomOptions().NumberOfQuestionsDesired;

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

        public Question GetExistingQuestion(Int32 questionId)
        {
            return _QuestionRepository.GetQuestion(questionId);
        }

        //Gets the questions as a parameter and gets them back to the repository
        //Statistics service to know about the user. Percent correct (calculate this somewhere else)
    }
}