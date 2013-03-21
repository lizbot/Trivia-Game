namespace Domain.Services
{
    using System.Collections.Generic;
    using Domain.Model;

    public class QuestionService
    {
        public IEnumerable<Question> GetQuestions()
        {
            // how will i resolve the concrete type of QuestionRepository?
        }
    }
}