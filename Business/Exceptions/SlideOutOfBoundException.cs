using System;

namespace Business.Exceptions
{
    public class SlideOutOfBoundException:Exception
    {
        public SlideOutOfBoundException(string msg):base(msg)
        {
            
        }
    }
}