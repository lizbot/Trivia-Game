using System;
using Domain.Extensions;

namespace Domain.Model
{
    public class Statistics
    {
        [PrimaryKey, AutoIncrement]
        public Int32 StatisticsId { get; set; } 
    }
}