using System;

namespace PosSender
{
    class InvalidMealException : Exception
    {
        public InvalidMealException()
        {}
        
        public InvalidMealException(string message) : base(message)
        {}
    }
}