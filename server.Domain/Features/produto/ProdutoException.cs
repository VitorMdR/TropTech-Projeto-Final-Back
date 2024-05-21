using System;
using System.Runtime.Serialization;

namespace server.Domain.Features.produto
{
    [Serializable]
    public class ProdutoException : Exception
    {
        public ProdutoException()
        {
        }

        public ProdutoException(string message) : base(message)
        {
        }

        public ProdutoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProdutoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}