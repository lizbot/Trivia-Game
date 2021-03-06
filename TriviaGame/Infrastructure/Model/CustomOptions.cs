﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class CustomOptions
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 CustomOptionId { get; set; }

        public Boolean IsTimerOn { set; get; }

        public Int32 NumberOfAnswersDisplayed { set; get; }

        public Int32? CategoryId { set; get; }

        public Int32 NumberOfQuestionsDesired { set; get; }
    }
}
