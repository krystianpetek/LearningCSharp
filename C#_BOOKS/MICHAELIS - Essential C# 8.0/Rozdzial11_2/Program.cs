using System;
using System.Runtime.Serialization;

namespace Rozdzial11_2
{
    internal class Program
    {
        public static void Main()
        {
        }
    }

    // niestandardowy wyjatek i serializacja

    [Serializable]
    internal class DatabaseException : Exception
    {
        public DatabaseException(string? message, System.Data.SqlClient.SqlException? exception) : base(message, exception)
        {
            // ...
        }

        public DatabaseException(string? message, System.Data.OracleClient.OracleException? exception) : base(message, exception)
        {
            // ...
        }

        public DatabaseException()
        {
            // ...
        }

        public DatabaseException(string? message)
        {
            // ...
        }

        public DatabaseException(string? message, Exception? exception) : base(message, innerException: exception)
        {
            // ...
        }

        // deserializacja wyjatkow
        public DatabaseException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
        {
            // ...
        }
    }
}