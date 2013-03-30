using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    class Options
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 OptionId { get; set; }
    }
}
