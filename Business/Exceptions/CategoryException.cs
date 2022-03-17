using System;

namespace Business.Exceptions
{
    public class CategoryException : Exception
    {
        public CategoryException(string msg) : base(msg)
        {
        }
    }
}