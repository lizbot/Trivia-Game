using System;
using System.Collections.Generic;
using Domain.Extensions;

namespace Domain.Model
{
    public class GameSaved
    {
        public Int32 GameId { get; set; }

        public IEnumerable<Question> Questions { get; set; }

        public IEnumerable<Answer> Answer { get; set; }

        public Boolean IsRight { get; set; }
    }
}