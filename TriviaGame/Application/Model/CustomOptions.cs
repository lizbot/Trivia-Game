using System;

namespace Application.Model
{
    public class CustomOptions
    {
        public Int32 CustomOptionId { get; set; }

        private Int32 _NumberOfQuestionsDesired = 15;

        public Boolean IsTimerOn { set; get; }

        public Int32 NumberOfAnswersDisplayed { set; get; }

        public Int32 CategoryId { set; get; }

        public Int32 NumberOfQuestionsDesired
        {
            get
            {
                return _NumberOfQuestionsDesired;
            }

            set
            {
                _NumberOfQuestionsDesired = value;
            }
        }
    }
}
