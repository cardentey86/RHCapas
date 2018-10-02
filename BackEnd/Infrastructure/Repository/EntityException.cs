using System;
using System.Runtime.Serialization;

namespace Infrastructure.Repository
{
    [Serializable]
    internal class EntityException : Exception
    {
        private object entity;
        private string v;
        private Exception ex;

        public EntityException()
        {
        }

        public EntityException(string message) : base(message)
        {
        }

        public EntityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EntityException(object entity, string v, Exception ex)
        {
            this.entity = entity;
            this.v = v;
            this.ex = ex;
        }

        protected EntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}