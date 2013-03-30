using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    class Answer
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 AnswerId { get; set; }

        public Int32 QuestionId { get; set; }

        public String Name { get; set; }

        public Boolean IsCorrect { get; set; }
    }
}
