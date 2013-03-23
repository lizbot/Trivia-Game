using System;

namespace Domain.Persistence
{
    using System.Collections.Generic;

    using Model;

    public interface IQuestionRepository
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
        IEnumerable<Question> GetQuestions(Int32 amountOfQuestions);
    }
}