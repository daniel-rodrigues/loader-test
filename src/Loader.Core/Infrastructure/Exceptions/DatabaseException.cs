namespace Loader.Core.Infrastructure.Exceptions
{
    [Serializable]
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message) { }

        public DatabaseException(string? message = null, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
