using System;


namespace mars_rover.Exceptions
{
    public class OutOfBorderException : Exception
    {
        public OutOfBorderException() : base(@"Out of Border...")
        {

        }
    }
}
