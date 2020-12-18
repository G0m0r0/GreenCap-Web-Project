namespace GreenCap.Services.Data.Exceptions
{
    using System;

    public class NegativeNumberNotAllowedException : Exception
    {
        public NegativeNumberNotAllowedException(string message)
            : base(message)
        {
        }
    }
}
