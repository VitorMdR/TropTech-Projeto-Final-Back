using System;
using System.Runtime.Serialization;

namespace server.Domain.Features.cliente
{
    [Serializable]
    public class ClienteException : Exception
    {
        public ClienteException()
        {
        }

        public ClienteException(string message) : base(message)
        {
        }

        public ClienteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClienteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}