using System;


namespace AppiumFlipkart.CustomException
{
    public class Exceptions :Exception
    {
        /// <summary>
        /// Exception type
        /// </summary>
        public ExceptionType ExceptionTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Exceptions"/> class
        /// </summary>
        /// <param name="message"> Exception message </param>
        /// <param name="type"> type of exception</param>
        public Exceptions(string message, ExceptionType type) : base(message)
        {
            this.ExceptionTypes = type;
        }

        public enum ExceptionType
        {
            EMAIL_NOT_SEND,SCRRENSHOT_NOT_CAPTURED
        }
    }
}
