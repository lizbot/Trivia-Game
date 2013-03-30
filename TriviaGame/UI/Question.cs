using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Question
    {
        public String QText {get; set;}
        public String[] PossibleAnswers { get; set; }
        public int CorrectAnswerIndex { get; set; } 


        public Question(String text, String[] answers, int ind)
        {
            QText = text;
            PossibleAnswers = answers;
            CorrectAnswerIndex = ind;
        }
    }
}
