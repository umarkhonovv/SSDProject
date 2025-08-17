﻿#pragma warning disable SYSLIB0051
using System.Runtime.Serialization;

namespace WebApiA.Exceptions;

[Serializable]
public class BaseException : Exception
{
    public BaseException() { }

    public BaseException(string message) : base(message) { }

    public BaseException(string message, Exception inner) : base(message, inner) { }

    protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
