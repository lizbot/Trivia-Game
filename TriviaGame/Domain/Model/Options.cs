using System;
using Domain.Extensions;

namespace Domain.Model
{
    public class Options
    {
        [PrimaryKey, AutoIncrement]
        public Int32 OptionId { get; set; } 
    }
}