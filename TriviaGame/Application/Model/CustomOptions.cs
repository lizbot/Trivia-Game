using System;

namespace Application.Model
{
    public class CustomOptions
    {
        private Int32 _NumberOfQuestionsDesired = 20;

        public Int32 OptionId { set; get; }

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
