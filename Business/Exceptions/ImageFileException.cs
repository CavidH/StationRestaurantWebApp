using System;

namespace Business.Exceptions
{
    public class ImageFileException:Exception
    {
        public ImageFileException(string msg):base(msg)
        {
            
        }
    }
}