namespace Infrastructure
{
    using System.Collections.Generic;
    using Domain.Model;
    using Domain.Persistence;

    public class QuestionRepository : IQuestionRepository
    {
        public IEnumerable<Question> GetQuestions()
        {
            using (var db = new SQLite.SQLiteConnection(PersistenceConfiguration.Database))
            {
                return db.Table<Question>();
            }
        }
    }
}