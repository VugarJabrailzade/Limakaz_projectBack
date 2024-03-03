using System.Runtime.Serialization;

namespace Limakaz.Exceptions
{
    public class LoginException : ApplicationException
    {
        public LoginException() : base()
        {
        }

        public LoginException(string message) : base(message) { }

        public LoginException(string message, Exception innerexception) : base(message, innerexception)
        {

        }
        protected LoginException(SerializationInfo info, StreamingContext context)
             : base(info, context)
        { } 

    }
}
