using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;

namespace Loader.Core.Infrastructure.Exceptions
{
    [Serializable]
    public abstract class BusinessException : Exception
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        public BusinessException() { }

        public BusinessException(string message) : base(message) { }

        public BusinessException(string? message = null, Exception? innerException = null)
            : base(message, innerException)
        {
        }

        public BusinessException(LogLevel logLevel = LogLevel.Warning, Exception? innerException = null, string? message = null)
            : this(message, innerException)
        {
            LogLevel = logLevel;
        }

        public BusinessException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
        }
    }
}
