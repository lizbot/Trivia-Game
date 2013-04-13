using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class GeneralOptions
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 GeneralOptionId { get; set; }

        public Boolean IsMusicOn { get; set; }

        public Boolean IsSoundEffectsOn { get; set; }
    }
}
