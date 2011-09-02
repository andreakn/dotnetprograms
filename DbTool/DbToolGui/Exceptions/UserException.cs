using System;
using DbToolGui.ExtensionMethods;

namespace DbToolGui.Exceptions
{
    public class UserException : Exception
    {
        public ExceptionType Type { get; private set; }

        public UserException(Exception innerException, ExceptionType type, params object[] args) : base(type.GetDescription(args), innerException)
        {
            Type = type;
        }

        public UserException(ExceptionType type, params object[] args) : base(type.GetDescription(args))
        {
            Type = type;
        }
    }
}