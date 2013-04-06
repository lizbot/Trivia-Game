﻿using System;
using Application.Domain;
using Application.Model;
using AutoMapper;
using Domain.Persistence;

namespace Domain.Services
{
    using System.Collections.Generic;

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _QuestionRepository;

        // Change this when we implement default settings to program against.
        private Int32 _DefaultNumber = 20;
        private IOptionsRepository _OptionsRepository;

        // this is a type of constructor injection for dependency injection.
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
            var userPreferredQuestionOption = _OptionsRepository.GetCustomOptions().NumberOfQuestionsDesired;

            if (userPreferredQuestionOption == null)
                userPreferredQuestionOption = 20;

            // this gets the IEnumerable<Question> of all the questions that you want from the database.
            var questions = _QuestionRepository.GetQuestions(userPreferredQuestionOption);

            return questions;
        }

        //Gets the questions as a parameter and gets them back to the repository
        //Statistics service to know about the user. Percent correct (calculate this somewhere else)
    }
}