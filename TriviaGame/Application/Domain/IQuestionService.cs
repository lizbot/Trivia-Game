﻿using System;
using System.Collections.Generic;
using Application.Model;

namespace Application.Domain
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions(Int32? categoryId = 0);

        void StoreAnsweredQuestion(AnsweredQuestion question);
    }
}