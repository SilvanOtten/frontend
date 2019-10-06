using System;
using System.Runtime.Serialization;

namespace FrontEnd.Errors
{
    [Serializable]
    public class FunctionalException : Exception
    {
        public ErrorList Errors { get; set; }

        public FunctionalException()
        {

        }

        public FunctionalException(ErrorList result)
        {
            Errors = result;
        }

        // TO-DO: Check if following functionality is needed
        //public FunctionalException(string message) : base(message)
        //{
        //}

        //public FunctionalException(string message, Exception innerException) : base(message, innerException)
        //{
        //}

        //protected FunctionalException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}
