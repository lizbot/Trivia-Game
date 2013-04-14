using System;
using Application.Model;

namespace Domain.Persistence
{
    using System.Collections.Generic;

    public interface IQuestionRepository
    {
        /// <summary>
        /// This gets the number of questions specified from the database.
        /// </summary>
        /// <param name="amountOfQuestions">
        /// The amount of questions.
        /// </param>
        /// <param name="categoryId">
        /// The categoryId if needed
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of the questions.
        /// </returns>
        IEnumerable<Question> GetQuestions(Int32 amountOfQuestions, Int32? categoryId = 0);
        
        Question GetQuestion(Int32 questionId);
    }
}