using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class GameSavedDto
    {
        public Int32 GameId { get; set; }

        public IEnumerable<QuestionDto> Questions { get; set; }

        public IEnumerable<AnswerDto> Answer { get; set; }

        public Boolean IsRight { get; set; }
    }
}