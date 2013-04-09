using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class Category
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public Int32 CategoryId { get; set; }

        public String Name { get; set; }
    }
}
