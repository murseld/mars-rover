using System;

namespace mars_rover.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException() : base(@"Invalid Command.")
        {
            
        }
    }
}
