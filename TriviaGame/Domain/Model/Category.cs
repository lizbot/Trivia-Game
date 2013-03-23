using System;
using Domain.Extensions;

namespace Domain.Model
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public Int32 CategoryId { get; set; }

        public String Name { get; set; }
    }
}