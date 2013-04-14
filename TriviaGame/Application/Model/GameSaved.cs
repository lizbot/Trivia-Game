using System;
using System.Collections.Generic;

namespace Application.Model
{
    public class GameSaved
    {
        public IEnumerable<Question> Questions { get; set; }

        public Int32 QuestionToResumeId { get; set; }
    }
}