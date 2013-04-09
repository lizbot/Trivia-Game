using System;
using System.Collections.Generic;

namespace Application.Model
{
    public class GameSaved
    {
        public IEnumerable<Question> Questions { get; set; }

        public Int32 AnswerId { get; set; }

        public Boolean IsRight { get; set; }
    }
}