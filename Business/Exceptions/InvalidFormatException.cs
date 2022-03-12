using System;

namespace Business.Exceptions
{
    public class InvalidFormatException:Exception
    {
        public InvalidFormatException(string msg):base(msg)
        {
            
        }
    }
}