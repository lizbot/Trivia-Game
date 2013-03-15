using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
namespace Testing
{
    class TestingDatabaseStuffff
    {
        static void Main(string[] args)
        {
            var db = new DatabaseRepository();

            db.DoMe();
        }
    }
}
