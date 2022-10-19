using System;

namespace Diploma.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
