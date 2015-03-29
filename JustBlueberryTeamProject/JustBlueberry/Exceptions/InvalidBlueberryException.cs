namespace JustBlueberry
{
    using System;
    using System.Runtime.Serialization;
    public class InvalidBlueberryException : ApplicationException, ISerializable
    {
        private string message;

        public InvalidBlueberryException()
        {
            // TODO: Add implementation.
        }

        public InvalidBlueberryException(string message)
        {
            this.message = message;
        }

        public InvalidBlueberryException(string message, Exception inner)
        {
            // TODO: Add implementation.
        }

        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
