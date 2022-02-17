using System;

namespace Lesson30_WebApi
{
    public interface ISingletonOperation
    {
        public Guid Id { get; }
    }

    public interface ITransientOperation
    {
        public Guid Id { get; }
    }

    public interface IScopedOperation
    {
        public Guid Id { get; }
    }

    public class Operation : ISingletonOperation, ITransientOperation, IScopedOperation
    {
        public Guid Id { get; }

        public Operation()
        {
            Id = Guid.NewGuid();
        }
    }
}
