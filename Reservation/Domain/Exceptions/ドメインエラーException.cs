using System;

namespace Reservation.Domain.Exceptions
{
    public class ドメインエラーException : Exception
    {
        public ドメインエラーException() : base()
        {
        }

        public ドメインエラーException(string message) : base(message)
        {
        }

        public ドメインエラーException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ドメインエラーException(Exception innerException) : base("", innerException)
        {
        }
    }

}