using System;

namespace Domain.Extensions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoIncrement : Attribute
    {
    }
}