using System;

namespace Core.Exceptions
{
    public class UnregisteredObjectTypeException : Exception
    {
        public UnregisteredObjectTypeException(string message) : base(message)
        {
            
        }
    }
}