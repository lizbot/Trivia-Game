using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    class CustomOptions
    {
        public Boolean IsTimerOn { set; get; }

        public Int32 NumberOfAnswersDisplayed { set; get; }

        public Int32? CategoryId { set; get; }

        public Int32 NumberOfQuestionsDesired { set; get; }
    }
}
