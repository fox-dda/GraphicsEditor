using System;

namespace SDKTests.Exceptions
{
    internal class GetInstanceExeption : Exception
    {
        public GetInstanceExeption(string message)
            : base(message)
        {
        }
    }
}