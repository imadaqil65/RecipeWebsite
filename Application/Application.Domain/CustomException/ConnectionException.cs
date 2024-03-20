using System.Runtime.Serialization;

namespace MyApplication.Domain.CustomException
{
    [Serializable]
    public class ConnectionException : Exception
    {
        public ConnectionException()
        {
        }

        public ConnectionException(string? message) : base(message)
        {
        }
    }
}