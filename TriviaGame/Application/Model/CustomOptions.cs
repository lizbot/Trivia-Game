using System;

namespace Application.Model
{
    public class CustomOptions
    {
        public Int32 OptionId { set; get; }

        public Boolean IsTimerOn { set; get; }

        public Int32 NumberOfAnswersDisplayed { set; get; }

        public Int32 CategoryId { set; get; }

        public Int32 NumberOfQuestionsDesired { get; set; }
    }
}
