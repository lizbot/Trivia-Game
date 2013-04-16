using System;

namespace Application.Model
{
    public class CustomOptions
    {
        public Int32 CustomOptionId { get; set; }

        public Int32 NumberOfQuestionsDesired { get; set; }

        public Int32 NumberOfAnswersDisplayed {  get; set; }

        public Int32? CategoryId { set; get; }

        public Boolean IsTimerOn { set; get; }
    }
}
