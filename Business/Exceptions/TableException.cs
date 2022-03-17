using System;

namespace Business.Exceptions
{
    public class TableException : Exception
    {
        public TableException(string msg) : base(msg)
        {
        }
    }
}